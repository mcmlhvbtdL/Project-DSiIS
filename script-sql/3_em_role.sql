/*
drop role S_QL_NHANVIEN;
drop role S_NHANVIEN;
drop role S_TRUONGPHONG;
drop role S_TAICHINH;
drop role S_NHANSU;
drop role S_TRUONGDEAN;
drop role S_BANGIAMDOC;
/
*/

---tao cac role lien quan cua HE thong 
create role S_QL_NHANVIEN;
create role S_NHANVIEN;
create role S_TRUONGPHONG;
create role S_TAICHINH;
create role S_NHANSU;
create role S_TRUONGDEAN;
create role S_BANGIAMDOC;
/
---them user vao role quan li truc tiep
CREATE OR REPLACE PROCEDURE Add_QL_NHANVIEN
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='QL truc tiep');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_QL_NHANVIEN TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
--them user vao role nhanvien
CREATE OR REPLACE PROCEDURE Add_NHANVIEN
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='Nhan vien');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_NHANVIEN TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
--them user vao role truong phong
CREATE OR REPLACE PROCEDURE Add_TRUONGPHONG
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='Truong phong');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_TRUONGPHONG TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
--them user vao role tai chinh
CREATE OR REPLACE PROCEDURE Add_TAICHINH
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='Tai chinh');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_TAICHINH TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
--them user vao role nhan su
CREATE OR REPLACE PROCEDURE Add_NHANSU
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='Nhan su');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_NHANSU TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
--them user vao role truong de an 
CREATE OR REPLACE PROCEDURE Add_TRUONGDEAN
AS
    Cursor cur is (select MANV from EM.NHANVIEN where VAITRO='Truong de an');
    strSQL varchar2(2000);
    Usr varchar2(20);
BEGIN 
    OPEN cur;
    Loop
        fetch cur into Usr;
        exit when cur%notfound;
        strSQL:= 'GRANT S_TRUONGDEAN TO '||Usr;
        Execute immediate (strSQL);
    end loop;
end;
/
-----------------thuc thi cac proc them user


execute Add_QL_NHANVIEN;
execute Add_NHANVIEN;
execute Add_TRUONGPHONG;
execute Add_TAICHINH;
execute Add_NHANSU;
execute Add_TRUONGDEAN;
select*from DBA_ROLE_PRIVS where granted_role = 'S_NHANVIEN';
/