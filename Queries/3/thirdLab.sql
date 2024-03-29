CLEAR SCREEN;
--�������������
--1. ������� �������������, ������������ ��� ������, ����� �������
--�� ������� 1� ����� ���������� �����.
    CREATE OR REPLACE VIEW SORT_GOODS_BY_COUNT AS
        SELECT GOODS.NAME, GOODS.PRIORITY, WAREHOUSE1.GOOD_COUNT
        FROM WAREHOUSE1
        JOIN GOODS ON WAREHOUSE1.GOOD_ID = GOODS.ID
        WHERE WAREHOUSE1.GOOD_COUNT < 20000;
        
    DROP VIEW SORT_GOODS_BY_COUNT;
    
    SELECT *
    FROM SORT_GOODS_BY_COUNT;
    
--2. ������� �������������, ������������ 5 ����� ���������� ������� �� �������� �����.
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

--�������� ���������
--1. ������� �������� ���������, ��������� ������ ������� ��� �������� � ���
--���������� �������� �������� ��������� �����������
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
    
--2. ������� �������� ��������� � ���������� ����������� ������������ ������ ��
--��������� ���� � ��������� ��� ������, ������� ���������� ��������, � �� ����������.
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

--3. ������� �������� ���������, ������� ��� ��������� ������1� � ������2�.
--��� ������ ���������� ����, ����� � ������� �� ������1� ��� ������ ��� �� ������2�.
--���� � �����-���� ���� ���� �� ������� �� ����������, ����� ���� �� ���������������.
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
    
--4. ������� �������� ��������� � �������� �����������, ��������� ��������
--�������, � �������� � ��������������� ������. ��������� ������ ����������
--����� � ������������ ��������� ������.
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
    
--��������
--1. ������� �������, ������� �� ��������� �������� ������ �� �����, �����
--�������� �� ����� ������� ������ ���������� � ������. 
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
    
--2. ������� �������, ������� �� ��������� �������� ������ c ������ ������ ������ 1.
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
    
--3. ������� �������, ������� �� ��������� ��������� ����� ������ �� 
--������� 2� ��� ������� ����� ������ �� ������� 1�.
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
    
--4. ������� �������, ������� ��� �������� ������ � ������ ������� �� ����
--������ ���������� ����������.
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

 --������
 --���������� ����������� �������� ���������, �������������� ��������������
 --����� �� 7 ���� �� ��������� �����. �������� ��������� ������ ����� ��� �������
 --���������, �������� �������� ������� ��� ������� ��������� ������, � ��������,
 --�������� ������������� �����.������������ ��������: � ������� ������� ���������
 --��������� �������, ���������� ����� ��� � ��������������� ��������� � ����� �����������
 --������. ������������ ����� ��������� � ����������. ���������� ������, ������������
 --��������������� ������ ��������� �������, ������������� �� ������ �����, �
 --����������� ������� �������� ����� (�� ������ �������� ����� ���������� �� 1 ������).
 --���������� ������� �������� ������ ����, �������� �������� ����������� �� ������ �����.
 --��������� ����� ���������. ������ ������� ����������� �� ��� ���, ���� � �������
 --�� ��������� 2 �����. ����� �������, ��� ������� ������ � ���� ���� ������ ����� �������
 --������ ����� �������������� �� ��������� ���� ������� � ������� �� �������� ����� ���������� ���.
 --����� �������, �� ����� �������� �������� ��������������� ������ 
 
   clear screen;
--CREATE GLOBAL TEMPORARY TABLE DEMAND_TABLE(CREATE_DATE TIMESTAMP, GOOD_COUNT NUMBER)
--ON COMMIT DELETE ROWS;
--DROP TABLE DEMAND_TABLE

CREATE OR REPLACE PROCEDURE DIAGRAM_FOR_GOOD1
(DATE_FROM IN TIMESTAMP, DATE_TO IN TIMESTAMP, ID_GOOD IN NUMBER, RESULT OUT DOUBLE PRECISION)
IS
  TYPE DATA_CURSOR_TYPE IS REF CURSOR;
  DATA_CURSOR DATA_CURSOR_TYPE;
  
  TYPE DEMAND_TABLE_TYPE IS TABLE OF DEMAND_TABLE%ROWTYPE; 
  TMP_TABLE DEMAND_TABLE_TYPE;
  
  ROWS_COUNT NUMBER;
  row_count NUMBER;
BEGIN
  DELETE FROM DEMAND_TABLE;

  INSERT INTO DEMAND_TABLE (CREATE_DATE, GOOD_COUNT)
	SELECT CREATE_DATE, SUM(GOOD_COUNT) AS SM
    FROM SALES
    WHERE CREATE_DATE >= DATE_FROM AND 
    CREATE_DATE <= DATE_TO
    AND GOOD_ID = ID_GOOD
    GROUP BY CREATE_DATE
    ORDER BY CREATE_DATE;
  
  SELECT COUNT(*)
  INTO ROWS_COUNT
  FROM DEMAND_TABLE;
    
  IF (ROWS_COUNT < 2) THEN 
        RAISE_APPLICATION_ERROR(-20000, 'Not enough data');
  END IF;
  
  LOOP 
        --OPEN DATA_CURSOR FOR SELECT CREATE_DATE, SM FROM DEMAND_TABLE;
        --FETCH DATA_CURSOR BULK COLLECT INTO TMP_TABLE;
		
        row_count := 0;
        
        SELECT COUNT(*)
        INTO ROWS_COUNT
        FROM DEMAND_TABLE;

        EXIT WHEN (ROWS_COUNT = 2);
        
        OPEN DATA_CURSOR FOR
        SELECT CREATE_DATE, GOOD_COUNT
        FROM DEMAND_TABLE;
        
        DELETE FROM DEMAND_TABLE;
            
        LOOP
            FETCH DATA_CURSOR BULK COLLECT INTO TMP_TABLE LIMIT 2;

            SELECT COUNT(*)
            INTO ROWS_COUNT
            FROM DEMAND_TABLE;

            IF (ROWS_COUNT = 1 AND DATA_CURSOR%ROWCOUNT - row_count = 1) THEN 
                 INSERT INTO DEMAND_TABLE (CREATE_DATE, GOOD_COUNT)
                 VALUES (TMP_TABLE(1).CREATE_DATE, TMP_TABLE(1).GOOD_COUNT);
            END IF;
            
            row_count := DATA_CURSOR%ROWCOUNT;
            EXIT WHEN DATA_CURSOR%NOTFOUND;
			
			INSERT INTO DEMAND_TABLE (CREATE_DATE, GOOD_COUNT)
            VALUES (TMP_TABLE(1).CREATE_DATE, (TMP_TABLE(1).GOOD_COUNT + TMP_TABLE(2).GOOD_COUNT) / 2);
			
            SELECT COUNT(*)
            INTO ROWS_COUNT
            FROM DEMAND_TABLE;
                   
        END LOOP;
            
        CLOSE DATA_CURSOR;   
    END LOOP;
        
    OPEN DATA_CURSOR FOR SELECT CREATE_DATE, GOOD_COUNT FROM DEMAND_TABLE;
    FETCH DATA_CURSOR BULK COLLECT INTO TMP_TABLE LIMIT 2;
  
    RESULT := ABS(TMP_TABLE(1).GOOD_COUNT - TMP_TABLE(2).GOOD_COUNT);
END;

DROP PROCEDURE DIAGRAM_FOR_GOOD1;

SET SERVEROUTPUT ON;
declare test double precision;
begin
    DIAGRAM_FOR_GOOD1('08.04.21', '15.04.21', 1, test);
    DBMS_OUTPUT.PUT_LINE('AAAAA=' || test);
end;

