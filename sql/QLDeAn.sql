--Cac cau lenh xoa cau truc

--ALTER TABLE NHANVIEN DROP CONSTRAINT fk_NHANVIEN
--ALTER TABLE PHONGBAN DROP CONSTRAINT fk_PHONGBAN_NHANVIEN
--ALTER TABLE DEAN DROP CONSTRAINT fk_DEAN_PHONGBAN



-- Xoa cau truc table
DECLARE
    table_nhanvien_exists NUMBER;
    table_phongban_exists NUMBER;
    table_dean_exists NUMBER;
    table_phancong_exists NUMBER;
BEGIN
	SELECT COUNT(*) INTO table_nhanvien_exists FROM user_tables WHERE table_name = 'NHANVIEN';
    IF table_nhanvien_exists = 1 THEN
        EXECUTE IMMEDIATE 'DROP TABLE NHANVIEN';
    END IF;
    
    SELECT COUNT(*) INTO table_phongban_exists  FROM user_tables WHERE table_name = 'PHONGBAN';
    IF table_phongban_exists = 1 THEN
        EXECUTE IMMEDIATE 'DROP TABLE PHONGBAN';
    END IF;
    
    SELECT COUNT(*) INTO table_dean_exists  FROM user_tables WHERE table_name = 'DEAN';
    IF table_dean_exists = 1 THEN
        EXECUTE IMMEDIATE 'DROP TABLE DEAN';
    END IF;
    
    SELECT COUNT(*) INTO table_phancong_exists FROM user_tables WHERE table_name = 'PHANCONG';
    IF table_phancong_exists = 1 THEN
        EXECUTE IMMEDIATE 'DROP TABLE PHANCONG';
    END IF;
END;
/

--Tao cau truc
CREATE TABLE NHANVIEN
(
    MANV varchar2(25),
    TENNV varchar2(255),
    PHAI varchar2(3),
    NGAYSINH date,
    DIACHI varchar2(255),
    SDT varchar(10),
    LUONG number,
    PHUCAP number,
    VAITRO varchar2(255),
    MANQL varchar2(25),
    PHG varchar2(25),
    PRIMARY KEY (MANV),
    --fk_NHANVIEN
    CONSTRAINT fk_NHANVIEN
    FOREIGN KEY(MANQL)
    REFERENCES NHANVIEN(MANV) ON DELETE SET NULL
);

CREATE TABLE PHONGBAN 
(
    MAPH varchar2(25),
    TENPB varchar2(255),
    TRPHG varchar2(25),
    PRIMARY KEY(MAPH),
    --fk_PHONGBAN_NHANVIEN
    CONSTRAINT fk_PHONGBAN_NHANVIEN
    FOREIGN KEY (TRPHG)
    REFERENCES NHANVIEN(MANV)  ON DELETE SET NULL
);
/

CREATE TABLE DEAN 
(
  MADA varchar2(25),
  TENDA varchar2(255),
  NGAYBD date,
  PHONG varchar(25),
  PRIMARY KEY(MADA),
  --fk_DEAN_PHONGBAN
  CONSTRAINT fk_DEAN_PHONGBAN
    FOREIGN KEY(PHONG)
    REFERENCES PHONGBAN(MAPH) ON DELETE SET NULL
);
/

CREATE TABLE PHANCONG
(
    MANV varchar(25),
    MADA varchar(25),
    THOIGIAN timestamp,
    PRIMARY KEY (MANV, MADA)
);
/
--Other:
--Xem ten user hien tai
SHOW USER;
SELECT SYS_CONTEXT('USERENV', 'CURRENT_USER') FROM DUAL;

--Check connect PDB or CDB
SELECT SYS_CONTEXT('USERENV', 'CON_NAME') AS container_name FROM DUAL;
/

--Check name DB
SELECT SYS_CONTEXT('USERENV', 'CON_NAME') FROM DUAL;
SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') FROM DUAL;

--Check list PDB
SELECT PDB_NAME, STATUS FROM DBA_PDBS;
ALTER PLUGGABLE DATABASE XEPDB1 OPEN;
/

SELECT * FROM DBA_ROLES
---

SELECT * FROM DEAN;
--1> Show danh sach user
--Option1
SELECT * FROM dba_users ORDER BY CREATED DESC;

--Option2
SET SERVEROUTPUT ON;
DECLARE
  CURSOR users_cursor IS
    SELECT username
    FROM dba_users
    ORDER BY username;
BEGIN
  DBMS_OUTPUT.PUT_LINE('List of all users in the Oracle database:');
  FOR user_record IN users_cursor LOOP
    DBMS_OUTPUT.PUT_LINE(user_record.username);
  END LOOP;
END;
/


-- Thông tin v? quy?n (privileges) c?a m?i user/ role trên các ??i t??ng d? li?u
--Tr
SELECT * FROM USER_TAB_PRIVS;

SELECT *
FROM ALL_TAB_PRIVS;

SELECT *
FROM ALL_TAB_PRIVS;

SELECT *
FROM ROLE_TAB_PRIVS;


SELECT *
FROM USER_TAB_PRIVS;

CREATE USER temp_user IDENTIFIED BY 123 
GRANT CREATE SESSION TO temp_user


SELECT * FROM DBA_ROLE_PRIVS;

SELECT * FROM dba_users
WHERE USERNAME = 'DUAHAU';
ACCOUNT_STATUS