--Cac cau lenh xoa cau truc

--ALTER TABLE NHANVIEN DROP CONSTRAINT fk_NHANVIEN
-- TABLE PHONGBAN DROP CONSTRAINT fk_PHONGBAN_NHANVIEN
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

--sp update user password
CREATE OR REPLACE PROCEDURE sp_update_user_password(
    p_username IN VARCHAR2,
    p_new_password IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' IDENTIFIED BY ' || p_new_password;
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
        EXECUTE IMMEDIATE 'CREATE ROLE ' || p_role_name ;
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
--sp get user privileges
CREATE OR REPLACE PROCEDURE sp_get_user_privileges(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT *
    FROM dba_sys_privs
    WHERE grantee NOT IN ('SYS', 'SYSTEM');
END sp_get_user_privileges;
/

--sp_get_user_privileges_by_owername
CREATE OR REPLACE PROCEDURE sp_get_user_privileges_by_username(
    p_username IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT *
    FROM dba_sys_privs
    WHERE grantee NOT IN ('SYS', 'SYSTEM')
    AND GRANTEE LIKE p_username || '%';
END sp_get_user_privileges_by_username;
/

--sp get role privileges
CREATE OR REPLACE PROCEDURE sp_get_role_privileges(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT * FROM ROLE_TAB_PRIVS;
END sp_get_role_privileges;
/

--sp get role privileges_by_username
CREATE OR REPLACE PROCEDURE sp_get_role_privileges_rolename(
    p_username IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT * FROM ROLE_TAB_PRIVS
    WHERE role LIKE p_username || '%';
END sp_get_role_privileges_rolename;
/

--sp grant permission to user
CREATE OR REPLACE PROCEDURE sp_grant_permission_to_user(
    p_user_name    IN VARCHAR2,
    p_permission   IN VARCHAR2,
    p_object_name  IN VARCHAR2,
    p_with_grant_option IN NUMBER,
    p_is_system_privilege IN NUMBER

) AS
BEGIN
    IF p_is_system_privilege = 1 THEN
        IF p_with_grant_option = 1 THEN
            EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' TO ' || p_user_name || ' WITH ADMIN OPTION';
        ELSE
            EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' TO ' || p_user_name;
        END IF;
    ELSE
        IF p_with_grant_option = 1 THEN
            EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' ON ' || p_object_name || ' TO ' || p_user_name || ' WITH GRANT OPTION';
        ELSE
            EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' ON ' || p_object_name || ' TO ' || p_user_name;
        END IF;
    END IF;
END sp_grant_permission_to_user;
/

CREATE OR REPLACE PROCEDURE sp_revoke_permission_from_user(
    p_user_name    IN VARCHAR2,
    p_permission   IN VARCHAR2,
    p_object_name  IN VARCHAR2,
    p_is_system_privilege IN NUMBER

) AS
BEGIN
    IF p_is_system_privilege = 1 THEN
        EXECUTE IMMEDIATE 'REVOKE ' || p_permission || ' FROM ' || p_user_name;
    ELSE
        EXECUTE IMMEDIATE 'REVOKE ' || p_permission || ' ON ' || p_object_name || ' FROM ' || p_user_name;
    END IF;
END sp_revoke_permission_from_user;
/
--sp_grant_permission_to_role
CREATE OR REPLACE PROCEDURE sp_grant_permission_to_role(
    p_role_name    IN VARCHAR2,
    p_permission   IN VARCHAR2,
    p_object_name  IN VARCHAR2,
    p_is_system_privilege IN NUMBER

) AS
BEGIN
    IF p_is_system_privilege = 1 THEN
        EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' TO ' || p_role_name;
    ELSE
        EXECUTE IMMEDIATE 'GRANT ' || p_permission || ' ON ' || p_object_name || ' TO ' || p_role_name;
    END IF;
END sp_grant_permission_to_role;
/

--sp_revoke_permission_from_role
CREATE OR REPLACE PROCEDURE sp_revoke_permission_from_role(
    p_role_name    IN VARCHAR2,
    p_permission   IN VARCHAR2,
    p_object_name  IN VARCHAR2,
    p_is_system_privilege IN NUMBER

) AS
BEGIN
    IF p_is_system_privilege = 1 THEN
        EXECUTE IMMEDIATE 'REVOKE ' || p_permission || ' FROM ' || p_role_name;
    ELSE
        EXECUTE IMMEDIATE 'REVOKE ' || p_permission || ' ON ' || p_object_name || ' FROM ' || p_role_name;
    END IF;
END sp_revoke_permission_from_role;
/



--sp_show_user_permissions
CREATE OR REPLACE PROCEDURE sp_show_user_permissions(
    p_username IN VARCHAR2,
    result_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN result_cursor FOR
        SELECT 'System Privilege' AS type, PRIVILEGE AS name
        FROM DBA_SYS_PRIVS
        WHERE GRANTEE = UPPER(p_username)
    UNION ALL
        SELECT 'Object Privilege', PRIVILEGE || ' ON ' || TABLE_NAME
        FROM DBA_TAB_PRIVS
        WHERE GRANTEE = UPPER(p_username)
    UNION ALL
        SELECT 'Role', GRANTED_ROLE
        FROM DBA_ROLE_PRIVS
        WHERE GRANTEE = UPPER(p_username);
END sp_show_user_permissions;
/

--sp_show_role_permissions
CREATE OR REPLACE PROCEDURE sp_show_role_permissions (
    p_role IN VARCHAR2,
    result_cursor OUT SYS_REFCURSOR
) IS
BEGIN
    OPEN result_cursor FOR
    SELECT 'System Privilege' AS permission_type, grantee, NULL AS owner, NULL AS table_name, privilege
    FROM DBA_SYS_PRIVS
    WHERE grantee = p_role
    UNION ALL
    SELECT 'Object Privilege' AS permission_type, grantee, owner, table_name, privilege
    FROM DBA_TAB_PRIVS
    WHERE grantee = p_role;
EXCEPTION
    WHEN OTHERS THEN
        RAISE;
END sp_show_role_permissions;
/
 
 --sp_assign_role_to_user
CREATE OR REPLACE PROCEDURE sp_assign_role_to_user (
   p_username IN VARCHAR2,
   p_role IN VARCHAR2
)
IS
BEGIN
   EXECUTE IMMEDIATE 'GRANT ' || p_role || ' TO ' || p_username;
   COMMIT;
END;
/
