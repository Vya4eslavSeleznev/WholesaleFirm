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
    EXECUTE COUNT_GOODS_BY_DATE('09-02-21 00:00');
    
    DROP PROCEDURE COUNT_GOODS_BY_DATE;

--3. ������� �������� ���������, ������� ��� ��������� ������1� � ������2�.
--��� ������ ���������� ����, ����� � ������� �� ������1� ��� ������ ��� �� ������2�.
--���� � �����-���� ���� ���� �� ������� �� ����������, ����� ���� �� ���������������.
    SET SERVEROUTPUT ON;
    CREATE OR REPLACE PROCEDURE DEMAND_FOR_GOOD
    (GOOD_NAME1 IN VARCHAR2, GOOD_NAME2 IN VARCHAR2)
    IS
        CURSOR DEMAND_CURSOR IS











--��������
--1. ������� �������, ������� �� ��������� �������� ������ �� �����, �����
--�������� �� ����� ������� ������ ���������� � ������. 
    CREATE TRIGGER CHECK_COUNT_OF_GOODS
    BEFORE INSERT 
        ON SALES
        FOR EACH ROW
        
    DECLARE
        WAREHOUSE1_COUNT NUMBER;
        WAREHOUSE2_COUNT NUMBER;
    BEGIN
        SELECT GOOD_COUNT
        INTO WAREHOUSE1_COUNT
        FROM WAREHOUSE1
        WHERE GOOD_ID = :NEW.GOOD_ID;
        
        SELECT GOOD_COUNT
        INTO WAREHOUSE2_COUNT
        FROM WAREHOUSE2
        WHERE GOOD_ID = :NEW.GOOD_ID;
        
        IF WAREHOUSE1_COUNT + WAREHOUSE2_COUNT < :NEW.GOOD_COUNT THEN
            RAISE_APPLICATION_ERROR(-20000, 'Not enough goods');        
        END IF;
    END;
    
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
        FROM WAREHOUSE1 WHERE GOOD_ID = :NEW.GOOD_ID;

        IF WAREHOUSE1_COUNT > 0 THEN
            RAISE_APPLICATION_ERROR(-20000, 'TEST MESSAGE'); 
        END IF;
    END;
    
    DROP TRIGGER UPDATE_WAREHOUSE;
    
--4. ������� �������, ������� ��� �������� ������ � ������ ������� �� ����
--������ ���������� ����������.
    CREATE TRIGGER UPDATE_WAREHOUSE
    BEFORE DELETE 
        ON WAREHOUSE2
        FOR EACH ROW
   



 












    
    
    
    
    
    