/*
Make sure you have created user "em", given permission to user "em" in the "0_em_create_user" file, 
and are connecting Oracle to the emp account before creating the schema generation script.
*/

-- Script xoa cau truc
BEGIN
  FOR t IN (SELECT table_name FROM user_tables
            WHERE table_name IN ('NHANVIEN', 'PHONGBAN', 'DEAN', 'PHANCONG'))
  LOOP
    EXECUTE IMMEDIATE 'DROP TABLE ' || t.table_name || ' CASCADE CONSTRAINTS';
  END LOOP;
END;
/


create table NHANVIEN
(
    MANV varchar2(5),
    TENNV varchar2(30),
    PHAI varchar2(5),
    NGAYSINH date,
    DIACHI varchar2(50),
    SODT varchar2(10),
    LUONG number(12),
    PHUCAP number(12),
    VAITRO varchar2(30),
    MANQL varchar2(5),
    PHG varchar2(5),
    
    constraint pk_NV primary key(MANV)
)
/
create table PHONGBAN
(
    MAPB varchar2(5),
    TENPB varchar2(30),
    TRPHG varchar2(5),
    
    constraint pk_PB primary key(MAPB)
)
/
create table DEAN
(
    MADA varchar2(5),
    TENDA varchar2(30),
    NGAYBD date,
    PHONG varchar2(5),
    
    constraint pk_DA primary key(MADA)
)
/
create table PHANCONG
(
    MANV varchar2(5),
    MADA varchar2(5),
    THOIGIAN number,
    
    constraint pk_PC primary key(MANV,MADA)
)
/

alter table NHANVIEN 
add constraint fk_NV_PB foreign key(PHG) references PHONGBAN(MAPB)
/
alter table NHANVIEN 
add constraint fk_NV_NQL foreign key(MANQL) references NHANVIEN(MANV)
/
alter table PHONGBAN
add constraint fk_PB_NV foreign key(TRPHG) references NHANVIEN(MANV)
/
alter table DEAN
add constraint fk_DA_PHG foreign key(PHONG) references PHONGBAN(MAPB)
/
alter table PHANCONG
add constraint fk_PC_NV foreign key(MANV) references NHANVIEN(MANV)
/
alter table PHANCONG
add constraint fk_PC_DA foreign key(MADA) references DEAN(MADA)
/
--them data 
insert all 
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV001','Nguyen Van Toan','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111111','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV002','Nguyen Van Vinh','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111112','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV003','Nguyen Van Long','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111113','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV004','Nguyen Van Hoang','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111114','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV005','Nguyen Van Nam','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111115','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV006','Nguyen Van Hai','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCMG','0111111116','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV007','Nguyen Van Dat','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111117','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV008','Nguyen Van Phat','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111118','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV009','Nguyen Van Khoi','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111119','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV010','Nguyen Van Lam','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111120','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV011','Nguyen Van Sang','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111121','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV012','Nguyen Van Phu','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111122','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV013','Nguyen Van trung','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111123','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV014','Nguyen Van Cau','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111124','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV015','Nguyen Van Phuc','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111125','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV016','Nguyen Van Vinh','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111126','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV017','Nguyen Van Minh','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111127','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV018','Nguyen Van hau','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111128','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV019','Nguyen Van Lan','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111129','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV020','Nguyen Van Tung','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111130','10000000','200000','QL truc tiep')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV021','Nguyen Van Toan','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111111','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV022','Nguyen Van Vinh','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111112','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV023','Nguyen Van Long','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111113','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV024','Nguyen Van Hoang','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111114','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV025','Nguyen Van Nam','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','0111111115','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV026','Nguyen Van Hai','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCMG','0111111116','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV027','Nguyen Van Dat','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111117','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV028','Nguyen Van Phat','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM ','0111111118','8000000','200000','Truong phong')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV041','Nguyen Thi Ha','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','099999999','10000000','200000','Tai chinh')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV042','Nguyen Thi Huong','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','099999998','10000000','200000','Tai chinh')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV043','Nguyen Thi Hanh','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','099999997','10000000','200000','Tai chinh')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV044','Nguyen Thi Lan','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','099999996','10000000','200000','Tai chinh')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV045','Nguyen Thi Trinh','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','099999995','10000000','200000','Tai chinh')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV046','Nguyen Thi Hue','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','019999999','9000000','200000','Nhan su')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV047','Nguyen Thi Linh','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','019999998','9000000','200000','Nhan su')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV048','Nguyen Thi Lien','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','019999997','9000000','200000','Nhan su')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV049','Nguyen Thi Chi','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','019999996','9000000','200000','Nhan su')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV050','Nguyen Thi Phung','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','019999995','9000000','200000','Nhan su')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV051','Nguyen Van A','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Truong de an')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV052','Nguyen Van B','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Truong de an')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV053','Nguyen Van C','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Truong de an')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV031','Nguyen THi Hong','Nu',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV032','Nguyen Van An','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV033','Nguyen Van Long','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV034','Nguyen Van Linh','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV035','Nguyen Van Sang','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV036','Nguyen Van Phat','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV037','Nguyen Van Phu','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV038','Nguyen Van Tai','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV039','Nguyen Van Duc','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
into NHANVIEN(MANV,TENNV,PHAI,NGAYSINH,DIACHI,SODT,LUONG,PHUCAP,VAITRO)
values('NV040','Nguyen Van Huy','Nam',TO_DATE('02/01/2000','DD/MM/YYYY'),'TPHCM','029999999','12000000','200000','Nhan vien')
select*from dual;
COMMIT;
/
insert all
into PHONGBAN values('PB001','Nghien cuu','NV021')
into PHONGBAN values('PB002','Dieu hanh','NV022')
into PHONGBAN values('PB003','Quan li','NV023')
into PHONGBAN values('PB004','Ke toan','NV024')
into PHONGBAN values('PB005','Tai chinh','NV025')
into PHONGBAN values('PB006','Nhan su','NV026')
into PHONGBAN values('PB007','Marketing','NV027')
into PHONGBAN values('PB008','San xuat','NV028')
select*from dual;
COMMIT;
/
insert  all
into DEAN values('DA001','San pham X',TO_DATE('01/01/2023','DD/MM/YYYY'),'PB001')
into DEAN values('DA002','San pham y',TO_DATE('02/01/2023','DD/MM/YYYY'),'PB002')
into DEAN values('DA003','San pham Z',TO_DATE('03/01/2023','DD/MM/YYYY'),'PB003')
into DEAN values('DA004','Tin hoc hoa',TO_DATE('04/01/2023','DD/MM/YYYY'),'PB004')
into DEAN values('DA005','Cap Quang',TO_DATE('05/01/2023','DD/MM/YYYY'),'PB005')
into DEAN values('DA006','Dao tao',TO_DATE('06/01/2023','DD/MM/YYYY'),'PB006')
select*from dual;
COMMIT;
/
insert all 
into PHANCONG values('NV009','DA001',30)
into PHANCONG values('NV010','DA001',30)
into PHANCONG values('NV012','DA003',30)
into PHANCONG values('NV015','DA001',30)
into PHANCONG values('NV013','DA002',30)
into PHANCONG values('NV009','DA004',30)
into PHANCONG values('NV011','DA001',30)
into PHANCONG values('NV013','DA003',30)
into PHANCONG values('NV016','DA005',30)
into PHANCONG values('NV017','DA002',30)
into PHANCONG values('NV018','DA006',30)
into PHANCONG values('NV019','DA006',30)
into PHANCONG values('NV020','DA004',30)
into PHANCONG values('NV017','DA001',30)
into PHANCONG values('NV018','DA005',30)
into PHANCONG values('NV010','DA005',30)
into PHANCONG values('NV010','DA003',30)
select*from dual
COMMIT;
/

update NHANVIEN set MANQL='NV001' where VAITRO='Tai chinh';
update NHANVIEN set MANQL='NV002' where VAITRO='Nhan su';
update NHANVIEN set MANQL='NV003' where VAITRO='Truong de an';
update NHANVIEN set MANQL='NV004' where VAITRO='Truong phong';
/
update NHANVIEN set PHG='PB002';
update NHANVIEN set PHG='PB006' where vaitro='Nhan su';
update NHANVIEN set PHG='PB005' where vaitro='Tai chinh';
update NHANVIEN set PHG='PB004' where vaitro='Nhan vien';
update NHANVIEN set PHG='PB003' where vaitro='Truong phong';

--Test insert du lieu thanh cong
--SHOW USER
--SELECT * FROM NHANVIEN;
--SELECT * FROM PHONGBAN;
--SELECT * FROM DEAN;
--SELECT * FROM PHANCONG;
