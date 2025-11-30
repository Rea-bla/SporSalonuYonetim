

--database kurumu için
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SporSalonuDB')
BEGIN
    CREATE DATABASE SporSalonuDB;
END
GO

--Hangi Database i kullandýðýmýzý göstermek için
use SporSalonuDB;
go


--Uyelik tiplerini oluþturmak için
if not exists (select * from sysobjects where name='UyelikTipleri' and xtype='U')
begin
    create table UyelikTipleri (
        UyelikTipiId int primary key identity(1,1), 
        Ad nvarchar(50) not null,                   
        Fiyat decimal(18,2)                         
    );

    insert into UyelikTipleri (ad,fiyat) values ('Standart',1000);
    insert into UyelikTipleri (ad,fiyat) values ('Gümüþ', 1500);
    insert into UyelikTipleri (ad,fiyat) values ('Altýn', 2000);
    insert into UyelikTipleri (ad,fiyat) values ('Platin', 3000);
end
go
--uyeler tablosunu kurmak için
if not exists (select * from sysobjects where name='Uyeler' and xtype='U')
begin
    create table Uyeler (
        UyeID int primary key identity(1,1),
        TCNo char(11) not null unique,      
        Ad nvarchar(50) not null,
        Soyad nvarchar(50) not null,
        Telefon nvarchar(15),
        KanGrubu nvarchar(6),
        Cinsiyet nvarchar(5),
        Boy int,       --Cm olarak alýnacaktýr                
        Kilo float,    --Kg olarak alýnacaktýr          
        KayitTarihi datetime default getdate(), 
        BitisTarihi datetime,
        DogumTarihi datetime, --Yýl olarak alýnacaktýr:D
        
        SecilenUyelikID int, 
        foreign key (SecilenUyelikID) references UyelikTipleri(UyelikTipiID)
    );
end
go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Yoneticiler' AND xtype='U')
BEGIN
    CREATE TABLE Yoneticiler (
        YoneticiID int primary key identity(1,1),
        KullaniciAdi nvarchar(50) not null unique,
        Sifre nvarchar(50) not null
    );
    INSERT INTO Yoneticiler (KullaniciAdi, Sifre) VALUES ('MuhammeT', '4488137');
    INSERT INTO Yoneticiler (KullaniciAdi, Sifre) VALUES ('Baykus', 'kedietiyedi');
    INSERT INTO Yoneticiler (KullaniciAdi, Sifre) VALUES ('Babuska', '313131');
end
go