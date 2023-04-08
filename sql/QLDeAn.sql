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

--Cac thong tin stored procedure
--sp xem toan bo thong tin user
CREATE OR REPLACE PROCEDURE sp_get_all_users(p_cursor OUT SYS_REFCURSOR) IS
BEGIN
  OPEN p_cursor FOR
    SELECT * FROM dba_users ORDER BY CREATED DESC;
END sp_get_all_users;
/
--sp xem thong tin user theo username
CREATE OR REPLACE PROCEDURE sp_get_user_by_username(p_username IN VARCHAR2, p_cursor OUT SYS_REFCURSOR) IS
BEGIN
  OPEN p_cursor FOR
    SELECT * FROM dba_users WHERE USERNAME LIKE p_username || '%';
END sp_get_user_by_username;
/

--sp xem thong tin toan bo cac role
CREATE OR REPLACE PROCEDURE sp_get_all_role(p_cursor OUT SYS_REFCURSOR) IS
BEGIN
    OPEN p_cursor FOR
        SELECT * FROM dba_roles;
END sp_get_all_role;
/

--sp xem thong tin role theo rolename
CREATE OR REPLACE PROCEDURE sp_get_role_by_rolename(p_username IN VARCHAR2, p_cursor OUT SYS_REFCURSOR) IS
BEGIN
  OPEN p_cursor FOR
    SELECT * FROM dba_roles WHERE ROLE LIKE p_username || '%';
END sp_get_role_by_rolename;
/

--sp tao nguoi dung
CREATE OR REPLACE PROCEDURE sp_create_user(
    p_username IN VARCHAR2,
    p_password IN VARCHAR2,
    p_grant_create_session IN NUMBER
)
AS
BEGIN
    EXECUTE IMMEDIATE 'CREATE USER ' || p_username || ' IDENTIFIED BY ' || p_password;

    IF p_grant_create_session = 1 THEN
        EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || p_username;
    END IF;
END;
/

--sp drop nguoi dung
CREATE OR REPLACE PROCEDURE sp_drop_user(
    p_username IN VARCHAR2,
    p_cascade IN NUMBER
)
AS
    v_opt VARCHAR2(10) := '';
BEGIN
    IF p_cascade = 1 THEN
        v_opt := ' CASCADE';
    END IF;

    EXECUTE IMMEDIATE 'DROP USER ' || p_username || v_opt;
END;
/

--sp create role
CREATE OR REPLACE PROCEDURE sp_create_role (
    p_role_name IN VARCHAR2,
    p_password_optional IN VARCHAR2,
    p_password_optional_checked IN NUMBER
)
AS
BEGIN
    IF p_password_optional_checked = 1 THEN
        EXECUTE IMMEDIATE 'CREATE ROLE ' || p_role_name || ' IDENTIFIED BY ' || p_password_optional;
    ELSE
        EXECUTE IMMEDIATE 'CREATE ROLE ' || p_role_name;
    END IF;
END;
/


--sp drop role
CREATE OR REPLACE PROCEDURE sp_drop_role (
    p_role_name IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ' || p_role_name;
END;
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

SELECT * 
FROM DBA_ROLE_PRIVS;

