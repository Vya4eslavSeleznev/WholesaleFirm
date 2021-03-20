CLEAR SCREEN;
--�������������
--1. ������� �������������, ������������ ��� ������, ����� �������
--�� ������� 1� ����� ���������� �����.
    CREATE OR REPLACE VIEW SORT_GOODS_BY_COUNT AS
        SELECT GOODS.NAME, GOODS.PRIORITY, WAREHOUSE1.GOOD_COUNT
        FROM WAREHOUSE1
        JOIN GOODS ON WAREHOUSE1.GOOD_ID = GOODS.ID
        WHERE WAREHOUSE1.GOOD_COUNT < 20000
    
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
        WHERE ROWNUM <= 5    

--�������� ���������
--1. ������� �������� ���������, ��������� ������ ������� ��� �������� � ���
--���������� �������� �������� ��������� �����������.
    SET SERVEROUTPUT ON;
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
            
            EXIT WHEN goods_cursor%NOTFOUND;
            DBMS_OUTPUT.PUT_LINE('Name=' || GOOD_NAME  ||
                                 ', Total='  || TOTAL ||
                                 ', Priority=' || GOOD_PRIORITY);
        END LOOP;        
        CLOSE SHIPPING_CURSOR;
    END;
    
    drop procedure SHIPPING
    
--2. ������� �������� ��������� � ���������� ����������� ������������ ������ ��
--��������� ���� � ��������� ��� ������, ������� ���������� ��������, � �� ����������.
    SET SERVEROUTPUT ON;
    CREATE OR REPLACE PROCEDURE COUNT_GOODS_BY_DATE
    (TRIP_DATE TIMESTAMP(3))
    IS
        CURSOR TRIP_CURSOR IS
            SELECT GOODS.NAME, GOODS.PRIORITY, SUM(SALES.GOOD_COUNT) AS TOTAL
            FROM SALES
            JOIN GOODS ON SALES.GOOD_ID = GOODS.ID
            WHERE SALES.CREATE_DATE = TRIP_DATE
            GROUP BY GOODS.NAME, GOODS.PRIORITY
            ORDER BY PRIORITY DESC

    GOOD_NAME VARCHAR2(50 BYTE);
    GOOD_PRIORITY NUMBER;
    TOTAL NUMBER;
    
    BEGIN
        OPEN SHIPPING_CURSOR;
        LOOP
            FETCH SHIPPING_CURSOR
            INTO GOOD_NAME, TOTAL, GOOD_PRIORITY;
            
            EXIT WHEN goods_cursor%NOTFOUND;
            DBMS_OUTPUT.PUT_LINE('Name=' || GOOD_NAME  ||
                                 ', Priority=' || GOOD_PRIORITY
                                 ', Total='  || TOTAL ||);
        END LOOP;        
        CLOSE SHIPPING_CURSOR;
    END;

--3. ������� �������� ���������, ������� ��� ��������� ������1� � ������2�.
--��� ������ ���������� ����, ����� � ������� �� ������1� ��� ������ ��� �� ������2�.
--���� � �����-���� ���� ���� �� ������� �� ����������, ����� ���� �� ���������������.
    SET SERVEROUTPUT ON;
    CREATE OR REPLACE PROCEDURE DEMAND_FOR_GOOD
    (GOOD_NAME1  VARCHAR2(50 BYTE), GOOD_NAME2 VARCHAR2(50 BYTE))
    IS
        CURSOR DEMAND_CURSOR IS




--��������
--1. ������� �������, ������� �� ��������� �������� ������ �� �����, �����
--�������� �� ����� ������� ������ ���������� � ������.
    CREATE TRIGGER EVAL_CHANGE_TRIGGER
    AFTER INSERT 
    ON SALES
    DECLARE
        WAREHOUSE1_COUNT NUMBER;
        WAREHOUSE2_COUNT NUMBER;
        
    BEGIN
        --GET GOOD ID
    
        BEGIN
            SELECT GOOD_COUNT
            INTO WAREHOUSE1_COUNT
            FROM WAREHOUSE1
            JOIN GOODS ON WAREHOUSE1.GOOD_ID = GOODS.ID
            --WHERE GOODS.NAME = 'tmp';
        END;
        
        BEGIN
            SELECT GOOD_COUNT
            INTO WAREHOUSE2_COUNT
            FROM WAREHOUSE2
            JOIN GOODS ON WAREHOUSE2.GOOD_ID = GOODS.ID
            --WHERE GOODS.NAME = 'tmp';
        END;
    
        
    
    
    
    END;
    
    
    
    
    
    
    
    
    
    
    
    
    