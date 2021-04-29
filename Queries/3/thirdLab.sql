CLEAR SCREEN;
--Представления
--1. Создать представление, отображающее все товары, число которых
--на «складе 1» менее некоторого числа.
    CREATE OR REPLACE VIEW SORT_GOODS_BY_COUNT AS
        SELECT GOODS.NAME, GOODS.PRIORITY, WAREHOUSE1.GOOD_COUNT
        FROM WAREHOUSE1
        JOIN GOODS ON WAREHOUSE1.GOOD_ID = GOODS.ID
        WHERE WAREHOUSE1.GOOD_COUNT < 20000;
        
    DROP VIEW SORT_GOODS_BY_COUNT;
    
    SELECT *
    FROM SORT_GOODS_BY_COUNT;
    
--2. Создать представление, отображающее 5 самых популярных товаров за заданный месяц.
    CREATE OR REPLACE VIEW TOP_GOODS AS
        SELECT *
        FROM
        (
            SELECT GOOD_ID, SUM(GOOD_COUNT) AS GOOD_COUNT
            FROM SALES
            WHERE EXTRACT(YEAR FROM CREATE_DATE) = 2021 AND EXTRACT(MONTH FROM CREATE_DATE) = 2
            GROUP BY GOOD_ID
            ORDER BY GOOD_COUNT DESC
        )
        WHERE ROWNUM <= 5;
        
    DROP VIEW TOP_GOODS;
    
    SELECT *
    FROM TOP_GOODS;

--Хранимые процедуры
--1. Создать хранимую процедуру, выводящую список товаров для перевоза и его
--количество согласно текущему состоянию приоритетов
    CREATE OR REPLACE PROCEDURE SHIPPING_BY_PRIORITY AS
    CURSOR SHIPPING_CURSOR IS
        SELECT GOODS.NAME, SUM(SALES.GOOD_COUNT) AS TOTAL, GOODS.PRIORITY
        FROM SALES
        JOIN GOODS ON SALES.GOOD_ID = GOODS.ID
        GROUP BY GOODS.NAME, GOODS.PRIORITY
        ORDER BY PRIORITY DESC;
        
    GOOD_NAME VARCHAR2(50 BYTE);
    TOTAL NUMBER;
    GOOD_PRIORITY NUMBER;
    
    BEGIN
        OPEN SHIPPING_CURSOR;
        LOOP
            FETCH SHIPPING_CURSOR
            INTO GOOD_NAME, TOTAL, GOOD_PRIORITY;
            EXIT WHEN SHIPPING_CURSOR%NOTFOUND;
            DBMS_OUTPUT.PUT_LINE('Name=' || GOOD_NAME  ||
                                 ', Total='  || TOTAL ||
                                 ', Priority=' || GOOD_PRIORITY);
        END LOOP;
        CLOSE SHIPPING_CURSOR;
    END;
    
    SET SERVEROUTPUT ON;
    EXECUTE SHIPPING_BY_PRIORITY;
    
    DROP PROCEDURE SHIPPING_BY_PRIORITY;
    
--2. Создать хранимую процедуру с параметром «количество перевозимого товара за
--ближайший рейс» и выводящую все товары, которые необходимо привезти, и их количество.
    CREATE OR REPLACE PROCEDURE COUNT_GOODS_BY_DATE(TRIP_DATE IN TIMESTAMP)
    IS
        CURSOR TRIP_CURSOR IS
            SELECT GOODS.NAME, GOODS.PRIORITY, SUM(SALES.GOOD_COUNT) AS TOTAL
            FROM SALES
            JOIN GOODS ON SALES.GOOD_ID = GOODS.ID
            WHERE SALES.CREATE_DATE = TRIP_DATE
            GROUP BY GOODS.NAME, GOODS.PRIORITY
            ORDER BY PRIORITY DESC;

        GOOD_NAME VARCHAR2(50 BYTE);
        GOOD_PRIORITY NUMBER;
        TOTAL NUMBER;
    
    BEGIN
        OPEN TRIP_CURSOR;
        LOOP
            FETCH TRIP_CURSOR
            INTO GOOD_NAME, GOOD_PRIORITY, TOTAL;
            EXIT WHEN TRIP_CURSOR%NOTFOUND;
            DBMS_OUTPUT.PUT_LINE('Name=' || GOOD_NAME  ||
                                 ', Priority='  || GOOD_PRIORITY ||
                                 ', Total=' || TOTAL);
        END LOOP;
    END;
    
    SET SERVEROUTPUT ON;
    EXECUTE COUNT_GOODS_BY_DATE('24-01-01 00:00');
    
    DROP PROCEDURE COUNT_GOODS_BY_DATE;

--3. Создать хранимую процедуру, имеющую два параметра «товар1» и «товар2».
--Она должна возвращать даты, спрос в которые на «товар1» был больше чем на «товар2».
--Если в какой-либо день один из товаров не продавался, такой день не рассматривается.
    SET SERVEROUTPUT ON;
    CREATE OR REPLACE PROCEDURE DEMAND_FOR_GOOD
    (GOOD_ID1 IN VARCHAR2, GOOD_ID2 IN VARCHAR2)
    IS
        CURSOR DEMAND_CURSOR1 IS
            SELECT GOOD_ID, CREATE_DATE, SUM(GOOD_COUNT) AS CNT
            FROM SALES
            WHERE GOOD_ID = GOOD_ID1
            GROUP BY GOOD_ID, CREATE_DATE;
            
            
        CURSOR DEMAND_CURSOR2 IS
            SELECT GOOD_ID, CREATE_DATE, SUM(GOOD_COUNT) AS CNT
            FROM SALES
            WHERE GOOD_ID = GOOD_ID2
            GROUP BY GOOD_ID, CREATE_DATE;
    
    BEGIN
        FOR FIRST IN DEMAND_CURSOR1
        LOOP
            FOR SECOND IN DEMAND_CURSOR2
            LOOP            
                IF FIRST.CREATE_DATE = SECOND.CREATE_DATE
                    AND FIRST.CNT > SECOND.CNT THEN
                    DBMS_OUTPUT.PUT_LINE('Date=' || FIRST.CREATE_DATE);
                END IF;
            END LOOP;
        END LOOP;
    END;
    
    EXECUTE DEMAND_FOR_GOOD(1, 2);
    
--4. Создать хранимую процедуру с входными параметрами, задающими интервал
--времени, и выходным – идентификатором товара. Процедура должна возвращать
--товар с максимальным приростом спроса.
    SET SERVEROUTPUT ON;
    CREATE OR REPLACE PROCEDURE DEMAND_FOR_GOOD_BY_DATE
    (FROM_DATE IN TIMESTAMP, TO_DATE IN TIMESTAMP, ID OUT NUMBER)
    IS
        CURSOR DEMAND_CURSOR IS
            SELECT GOOD_ID
            FROM
            (
                SELECT GOOD_ID
                FROM SALES
                WHERE CREATE_DATE BETWEEN FROM_DATE AND TO_DATE
                GROUP BY GOOD_ID
                ORDER BY SUM(GOOD_COUNT) DESC
            )
            WHERE ROWNUM <= 1;
    
    BEGIN
        OPEN DEMAND_CURSOR;
        LOOP
            FETCH DEMAND_CURSOR
            INTO ID;
            EXIT WHEN DEMAND_CURSOR%NOTFOUND;
            DBMS_OUTPUT.PUT_LINE('Id=' || ID);
        END LOOP;
        CLOSE DEMAND_CURSOR;
    END;
    
    SET SERVEROUTPUT ON;
    DECLARE TEST_ID NUMBER;
    EXECUTE DEMAND_FOR_GOOD_BY_DATE('', '', TEST_ID);
    DBMS_OUTPUT.PUT_LINE(TEST_ID);
    
--Триггера
--1. Создать триггер, который не позволяет добавить заявку на товар, число
--которого на обоих складах меньше указанного в заявке. 
    CREATE TRIGGER CHECK_COUNT_OF_GOODS
    BEFORE INSERT OR UPDATE
        ON SALES
        FOR EACH ROW
        
    DECLARE
        WAREHOUSE1_COUNT NUMBER;
        WAREHOUSE2_COUNT NUMBER;
    BEGIN
        BEGIN
            SELECT SUM(GOOD_COUNT) AS TOTAL
            INTO WAREHOUSE1_COUNT
            FROM WAREHOUSE1
            WHERE GOOD_ID = :NEW.GOOD_ID
            GROUP BY GOOD_ID;
            EXCEPTION WHEN NO_DATA_FOUND THEN
            WAREHOUSE1_COUNT := 0;
        END;
        
        BEGIN
            SELECT SUM(GOOD_COUNT) AS TOTAL
            INTO WAREHOUSE2_COUNT
            FROM WAREHOUSE2
            WHERE GOOD_ID = :NEW.GOOD_ID
            GROUP BY GOOD_ID;
            EXCEPTION WHEN NO_DATA_FOUND THEN
            WAREHOUSE2_COUNT := 0;
        END;
        
        IF WAREHOUSE1_COUNT + WAREHOUSE2_COUNT < :NEW.GOOD_COUNT THEN
            RAISE_APPLICATION_ERROR(-20000, 'Not enough goods');        
        END IF;
    END;
    
    INSERT INTO SALES(GOOD_ID, GOOD_COUNT, CREATE_DATE)
    VALUES(62, 444, '20-01-21')
    
    DROP TRIGGER CHECK_COUNT_OF_GOODS;
    
--2. Создать триггер, который не позволяет добавить заявку c числом товара меньше 1.
    CREATE TRIGGER CHECK_EMPTY_SALE
    BEFORE INSERT 
        ON SALES
        FOR EACH ROW
        
    BEGIN
        IF :NEW.GOOD_COUNT < 1 THEN
            RAISE_APPLICATION_ERROR(-20000, 'Not enough goods');        
        END IF;
    END;
    
    INSERT INTO SALES(GOOD_ID, GOOD_COUNT, CREATE_DATE)
    VALUES(62, 0, '20-01-21')
    
    DROP TRIGGER CHECK_EMPTY_SALE;
    
--3. Создать триггер, который не позволяет уменьшить число товара на 
--«складе 2» при наличии этого товара на «складе 1».
    CREATE TRIGGER UPDATE_WAREHOUSE
    BEFORE UPDATE 
        ON WAREHOUSE2
        FOR EACH ROW
        
    DECLARE
        WAREHOUSE1_COUNT NUMBER;
        
    BEGIN
        SELECT COUNT(*)
        INTO WAREHOUSE1_COUNT
        FROM WAREHOUSE1
        WHERE GOOD_ID = :NEW.GOOD_ID;

        IF WAREHOUSE1_COUNT > 0 THEN
            RAISE_APPLICATION_ERROR(-20000, 'TEST MESSAGE'); 
        END IF;
    END;
    
    UPDATE WAREHOUSE2
    SET GOOD_COUNT = 8888
    WHERE GOOD_ID = 1
    
    DROP TRIGGER UPDATE_WAREHOUSE;
    
--4. Создать триггер, который при удалении товара в случае наличия на него
--ссылок откатывает транзакцию.
    CREATE TRIGGER CHECK_FOREIGN_KEY
    BEFORE DELETE 
        ON GOODS
        FOR EACH ROW
    
    DECLARE
        SALE_COUNT NUMBER;
        WAREHOUSE1_COUNT NUMBER;
        WAREHOUSE2_COUNT NUMBER;
    
    BEGIN
        SELECT COUNT(*)
        INTO SALE_COUNT
        FROM SALES
        WHERE GOOD_ID = :NEW.ID;
        
        SELECT COUNT(*)
        INTO WAREHOUSE1_COUNT
        FROM WAREHOUSE1
        WHERE GOOD_ID = :NEW.ID;
        
        SELECT COUNT(*)
        INTO WAREHOUSE2_COUNT
        FROM WAREHOUSE2
        WHERE GOOD_ID = :NEW.ID;
        
        IF SALE_COUNT > 0 OR WAREHOUSE1_COUNT > 0 OR WAREHOUSE2_COUNT > 0 THEN
            RAISE_APPLICATION_ERROR(-20000, 'TEST MESSAGE');
        END IF;
    END;
    
    DELETE FROM GOODS
    WHERE ID = 1
    
    DROP TRIGGER CHECK_FOREIGN_KEY;

 --Курсор
 --Необходимо реализовать хранимую процедуру, рассчитывающую прогнозируемый
 --спрос на 7 дней на некоторый товар. Хранимая процедура должна иметь два входных
 --параметра, задающие интервал времени для анализа изменения спроса, и параметр,
 --задающий анализируемый товар.Предлагаемый алгоритм: с помощью курсора формируем
 --временную таблицу, содержащую номер дня в рассматриваемом интервале и число хранящегося
 --товара. Максимальный номер сохраняем в переменной. Организуем курсор, перебирающий
 --последовательно строки временной таблицы, упорядоченные по номеру точки, и
 --усредняющий попарно соседние точки (за каждую итерацию точек становится на 1 меньше).
 --Полученное среднее значение каждой пары, заменяет значение минимальной по номеру точки.
 --Последняя точка удаляется. Работа курсора повторяется до тех пор, пока в таблице
 --не останется 2 точки. Будем считать, что разница спроса в этих двух точках равна разнице
 --спроса между прогнозируемым на следующий день спросом и спросом на заданный товар последнего дня.
 --Таким образом, мы можем получить величину прогнозируемого спроса 
 
    CREATE GLOBAL TEMPORARY TABLE DEMAND_TABLE(DAY NUMBER, GOOD_COUNT NUMBER)
    ON COMMIT DELETE ROWS;
    
    CREATE OR REPLACE PROCEDURE DIAGRAM_FOR_GOOD
    (DATE_FROM IN TIMESTAMP, DATE_TO IN TIMESTAMP, ID_GOOD IN NUMBER, RESULT OUT DOUBLE PRECISION, DATA_CURSOR OUT SYS_REFCURSOR)
    IS
        CURSOR GET_DATA IS
            SELECT DAY, GOOD_COUNT
            FROM DEMAND_TABLE;
    
    ROWNUM_COUNT NUMBER;
    CURRENT_ROWNUM NUMBER;
    LAST_SUM NUMBER;
    RES1 DOUBLE PRECISION;
    RES2 DOUBLE PRECISION;
    
    MAX_GOOD_COUNT NUMBER;
    
    BEGIN
        ROWNUM_COUNT := 0;
        LAST_SUM := 0;
        RES1 := 0;
        RES2 := 0;
        CURRENT_ROWNUM := 0;
        
        SELECT MAX(SUM(GOOD_COUNT))
        INTO MAX_GOOD_COUNT
        FROM SALES WHERE GOOD_ID = ID_GOOD
        GROUP BY CREATE_DATE;
        
        INSERT INTO DEMAND_TABLE
            SELECT CREATE_DATE, SUM(GOOD_COUNT) AS SM
            FROM SALES
            WHERE CREATE_DATE >= DATE_FROM AND 
            CREATE_DATE <= DATE_TO
            AND GOOD_ID = ID_GOOD
            GROUP BY CREATE_DATE
            ORDER BY CREATE_DATE;
        
        FOR CR IN GET_DATA
        LOOP
            
            
            
        END LOOP;
    
    
    
    
    
    
    
    
    
        FOR CR IN GET_DATA
        LOOP
            ROWNUM_COUNT := ROWNUM_COUNT + 1;
        END LOOP;
        
        FOR CR IN GET_DATA
        LOOP
            IF CURRENT_ROWNUM < ROWNUM_COUNT - 2 THEN
                RES1 := RES1 + CR.SM;
            ELSE
                RES2 := RES2 + CR.SM;
            END IF;
            
            CURRENT_ROWNUM := CURRENT_ROWNUM + 1;
        END LOOP;
        
        IF ROWNUM_COUNT > 2 THEN
            RES1 := RES1 / (ROWNUM_COUNT - 2);
            RES2 := RES2 / 2;
        END IF;
        
        IF RES1 > RES2 THEN
            RES1 := RES1 - RES2;
        ELSE
            RES1 := RES2 - RES1;
        END IF;
        
        CURRENT_ROWNUM := 0;
        
        FOR CR IN GET_DATA
        LOOP
            IF CURRENT_ROWNUM = ROWNUM_COUNT - 1 THEN
                LAST_SUM := CR.SM;
            END IF;
        END LOOP;
        
        RESULT := RES1 + LAST_SUM;
    IF NOT DATA_CURSOR%ISOPEN THEN

    OPEN DATA_CURSOR FOR
		SELECT CREATE_DATE, SUM(GOOD_COUNT) AS SM
        FROM SALES
        WHERE CREATE_DATE >= DATE_FROM AND 
        CREATE_DATE <= DATE_TO
        AND GOOD_ID = ID_GOOD
        GROUP BY CREATE_DATE
        ORDER BY CREATE_DATE;
    END IF;
    END;
    
    DROP PROCEDURE DIAGRAM_FOR_GOOD;












    
    
    
    
    
    