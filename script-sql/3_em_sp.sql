--------------------------------CS1-----------------------------------
---tao view thong tin cua moi nhan vien
/*
drop view TT_NHANVIEN;
drop view TT_PHANCONG;
drop view TT_PHONGBAN;
drop view TT_DEAN;
/
*/

create  view TT_NHANVIEN
as 
select * from EM.NHANVIEN 
/
create view TT_PHANCONG
as 
select*from EM.PHANCONG
/

create view TT_PHONGBAN
as 
select*from EM.PHONGBAN
/

create view TT_DEAN
as 
select*from EM.DEAN
/


CREATE OR REPLACE TRIGGER emp_update
INSTEAD OF UPDATE
ON TT_NHANVIEN
FOR EACH ROW
DECLARE
BEGIN
UPDATE NHANVIEN SET SODT = :NEW.SODT,
                    DIACHI=:NEW.DIACHI,
                    NGAYSINH=:NEW.NGAYSINH
WHERE MANV = :NEW.MANV;
END;
/
--DROP VPD
begin 
    dbms_rls.drop_policy(
        object_schema => 'em',
        object_name => 'TT_NHANVIEN',
        policy_name => 'pc1');
exception
    when others then
        if sqlcode != -28119 then
            raise;
        end if;
end;
/
begin 
    dbms_rls.drop_policy(
        object_schema => 'em',
        object_name => 'TT_PHANCONG',
        policy_name => 'pc2');
exception
    when others then
        if sqlcode != -28119 then
            raise;
        end if;
end;
/

---tao function cho VDP chi xem duoc thong tin chinh minh
create or replace function sec_function(p_schema varchar2,p_obj varchar2)
Return varchar2
as
    us varchar(100);
    begin
    us := sys_context('userenv', 'session_user');
    return 'MANV = ''' || us||'''';
    end;
/

--create function sec_function2(p_schema varchar2,p_obj varchar2)
--Return varchar2
--as
--    us varchar(100);
--    begin
--    if (sys_context('userenv', 'ISDBA')) then return ' ';
--    else
--    us := sys_context('userenv', 'session_user');
--    return 'MANV = ''' || us||'''';
--    end if;
--    end;
--/

-----tao VDP de nhan vien chi duoc xem thuoc tinh cua chinh minh 
begin
DBMS_RLS.add_policy(
    object_schema => 'em',
    object_name => 'TT_NHANVIEN',
    policy_name => 'pc1',
    policy_function => 'sec_function',
    statement_types => 'select,update',
    update_check => TRUE);
end;
/
begin
DBMS_RLS.add_policy(
    object_schema => 'em',
    object_name => 'TT_PHANCONG',
    policy_name => 'pc2',
    policy_function => 'sec_function',
    statement_types => 'select',
    update_check => TRUE);
end;
/

--CS#1
grant select on TT_NHANVIEN to S_NHANVIEN ;---cap quyen xem thong tin  cua chinh minh cho nhan vien
grant select on TT_PHANCONG to S_NHANVIEN;----cap quyen xem phan cong cua chinh minh cho nhan vien
grant select on TT_PHONGBAN to S_NHANVIEN;---nhan vien duoc xem tat ca cac phong ban
grant select on TT_DEAN to S_NHANVIEN;---nhan vien duoc xem tat ca cac dean
grant update(NGAYSINH,DIACHI,SODT) on TT_NHANVIEN to S_NHANVIEN;-- cap quyen chinh sua thong tin(ngsinh,diachi,sodt) cho nhan vien

--grant select on PHONGBAN to S_NHANVIEN;---nhan vien duoc xem tat ca cac phong ban
--grant select on DEAN to S_NHANVIEN;---nhan vien duoc xem tat ca cac dean

/

---------------------------------CS2----------------------------------------
grant  S_NHANVIEN to S_QL_NHANVIEN---quan li cung la mot nhan vien
--- tao view de quan li xem thong tin nhan vien truc thuoc quan li
drop view TT_NVQL;
drop view TT_PCNVQL;
/
create view TT_NVQL
as 
SELECT MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,VAITRO,MANQL,PHG
FROM NHANVIEN NV
where sys_context('userenv', 'session_user') = MANQL or sys_context('userenv', 'session_user') = MANV;
/
grant select on TT_NVQL to S_QL_NHANVIEN;---cap quyen xem thong tin nhan vien truc thuoc quan li cho role quanli
--- tao view de quan li xem phan cong nhan vien truc thuoc
/  

create view TT_PCNVQL
as 
SELECT PC.MANV,PC.MADA,PC.THOIGIAN
FROM PHANCONG PC join NHANVIEN NV on PC.MANV=NV.MANV
where sys_context('userenv', 'session_user') = PC.MANV or sys_context('userenv', 'session_user') = NV.MANQL;
/
grant select on TT_PCNVQL to S_QL_NHANVIEN;
--------------------------------CS3----------------------------------------
grant S_NHANVIEN to S_TRUONGPHONG;--truong phong cung la nhan vien
---tao view xem nhan vien truc thuoc phong 
drop view TT_NVPHG;
drop view TT_PCNVPHG;
/
create view TT_NVPHG
as 
SELECT MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,VAITRO,MANQL,PHG
FROM NHANVIEN NV join PHONGBAN PB on NV.PHG=PB.MAPB
where sys_context('userenv', 'session_user') = TRPHG;
grant select on TT_NVPHG to S_TRUONGPHONG;---cap quyen cho truong phong xem thong tin nhan vien thuoc phong


--tao view de truong PHONG xem cac phan cong cua nhan vien truc thuoc
create view TT_PCNVPHG
as 
SELECT PC.MANV,PC.MADA,PC.THOIGIAN
FROM NHANVIEN NV join PHONGBAN PB on NV.PHG=PB.MAPB join PHANCONG PC on PC.MANV=NV.MANV
where sys_context('userenv', 'session_user') = TRPHG;
grant select,insert,update,delete on TT_PCNVPHG to S_TRUONGPHONG;----cap quyen cho truong phong thao tac tren view phan cong

--------------------------------CS4----------------------------------------
grant S_NHANVIEN to S_TAICHINH;---tai chinh cung la nhan vien
grant select on NHANVIEN to S_TAICHINH;
grant select on PHANCONG to S_TAICHINH;
grant update(LUONG,PHUCAP) on NHANVIEN to S_TAICHINH;
--------------------------------CS5----------------------------------------
grant S_NHANVIEN to S_NHANSU
grant insert,update on PHONGBAN to S_NHANSU
--tao view chi lay luong va phu cap co gia tri null
create view TT_LUONG_PHUCAP_NULL
as
select LUONG,PHUCAP from NHANVIEN where LUONG is null and PHUCAP is NULL;
/
--grant quyen tren view cho NHANSU 
grant insert,update on TT_LUONG_PHUCAP_NULL to S_NHANSU;
--------------------------------CS6----------------------------------------
grant S_NHANVIEN to S_TRUONGDEAN;
grant insert,update,delete on DEAN to S_TRUONGDEAN;



---------------CS5