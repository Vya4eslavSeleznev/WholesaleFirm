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

















