--Proc DROP user
SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE dropNV AS
    CURSOR CUR IS (SELECT MANV FROM EM.NHANVIEN);
    strSQL VARCHAR2(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        strSQL:= 'DROP USER ' || Usr || ' CASCADE';
        BEGIN
            EXECUTE IMMEDIATE strSQL;
        EXCEPTION
            WHEN OTHERS THEN
                DBMS_OUTPUT.PUT_LINE('Failed to drop user ' || Usr || ': ' || SQLERRM);
        END;
    END LOOP;
    CLOSE CUR;
END;
/

execute dropNV;
/

---tao proc them tao cac user co trong bang NHANVIEN
CREATE OR REPLACE PROCEDURE createNV AS
    CURSOR CUR IS (SELECT MANV FROM EM.NHANVIEN);
    strSQL VARCHAR2(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        strSQL:= 'CREATE USER ' || Usr || ' IDENTIFIED BY '|| '123';
        EXECUTE IMMEDIATE strSQL;
        strSQL:= 'GRANT CREATE SESSION TO ' || Usr;
        EXECUTE IMMEDIATE strSQL;
    END LOOP;
    CLOSE CUR;
END;
/


execute createNV;
/





