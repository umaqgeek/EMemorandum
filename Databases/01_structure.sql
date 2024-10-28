-- Check if the database exists
IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = N'DbEMO'
)
BEGIN
    -- Create a new database if it does not exist
    CREATE DATABASE DbEMO;
END

-- Optionally, you can set the default database for the `sa` user or another user
USE DbEMO;

-- DbEMO.dbo.EMO_Countries definition

-- Drop table

-- DROP TABLE DbEMO.dbo.EMO_Countries;

CREATE TABLE DbEMO.dbo.EMO_Countries (
	code nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	name nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT EMO_Countries_PK PRIMARY KEY (code)
);

-- DbEMO.dbo.EMO_Pejabat definition

-- Drop table

-- DROP TABLE DbEMO.dbo.EMO_Pejabat;

CREATE TABLE DbEMO.dbo.EMO_Pejabat (
	KodPejPBU nvarchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Pejabat nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	KodPBU nvarchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	NamaPBU nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	StatusPTJ bit NULL,
	CONSTRAINT EMO_Pejabat_PK PRIMARY KEY (KodPBU)
);

-- DbEMO.dbo.EMO_KPI definition

-- Drop table

-- DROP TABLE DbEMO.dbo.EMO_KPI;

CREATE TABLE DbEMO.dbo.EMO_KPI (
	Kod varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	KPI varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT EMO_KPI_PK PRIMARY KEY (Kod)
);

-- DbEMO.dbo.EMO_Staf definition

-- Drop table

-- DROP TABLE DbEMO.dbo.EMO_Staf;

CREATE TABLE DbEMO.dbo.EMO_Staf (
	NoStaf nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Nama nvarchar(80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NoTelBimbit nvarchar(11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NJawatan nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	JGiliran nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	KodPejabat nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	KodPTJSub varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NPejabat nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Singkat nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	StatPejabat bit NULL,
	MS02_JawSandang nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS02_KodJawatan nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	KumpStaf bit NULL,
	MS02_Taraf nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status bit NULL,
	MS01_KpB nvarchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TarafKhidmat nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS01_Gelaran nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Gelaran nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS01_Jantina nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS01_Kategori nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS01_Warganegara nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Warganegara nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS08_Unit nvarchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS02_TkhKuatkuasa smalldatetime NULL,
	MS02_TkhLantikKUTKM smalldatetime NULL,
	CONSTRAINT PK_EMO_Staf PRIMARY KEY (NoStaf)
);

-- DbEMO.dbo.EMO_Roles definition

-- Drop table

-- DROP TABLE DbEMO.dbo.EMO_Roles;

CREATE TABLE DbEMO.dbo.EMO_Roles (
	id bigint IDENTITY(0,1) NOT NULL,
	NoStaf nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Role] nvarchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT EMO_Roles_PK PRIMARY KEY (id),
	CONSTRAINT EMO_Roles_FK FOREIGN KEY (NoStaf) REFERENCES DbEMO.dbo.EMO_Staf(NoStaf) ON DELETE CASCADE
);

-- DbEMO.dbo.MOU01_Memorandum definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU01_Memorandum;

CREATE TABLE DbEMO.dbo.MOU01_Memorandum (
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	NoSiri varchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Tahun int NOT NULL,
	KodPTJ varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	KodScope int NOT NULL,
	KodJenis int NOT NULL,
	KodKategori int NOT NULL,
	KodPTJSub varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TarikhMula smalldatetime NULL,
	TarikhTamat smalldatetime NULL,
	TajukProjek varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NamaDok varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Path] varchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MS01_NoStaf nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Status varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Nilai decimal(18,2) NULL,
	Author nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Negara nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_MOU01_Memorandum PRIMARY KEY (NoMemo),
	CONSTRAINT FK_MOU01_Memorandum_EMO_Staf FOREIGN KEY (MS01_NoStaf) REFERENCES DbEMO.dbo.EMO_Staf(NoStaf)
);

-- DbEMO.dbo.MOU02_Status definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU02_Status;

CREATE TABLE DbEMO.dbo.MOU02_Status (
	Status_ID BIGINT IDENTITY(1,1) NOT NULL,
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Status varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Tarikh smalldatetime NULL,
	Catatan varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_MOU02_Status PRIMARY KEY (Status_ID),
	CONSTRAINT FK_MOU02_Status_MOU01_Memorandum FOREIGN KEY (NoMemo) REFERENCES DbEMO.dbo.MOU01_Memorandum(NoMemo)
);

-- DbEMO.dbo.MOU03_Ahli definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU03_Ahli;

CREATE TABLE DbEMO.dbo.MOU03_Ahli (
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	NoStaf nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Peranan varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TkhMula smalldatetime NULL,
	TkhTamat smalldatetime NULL,
	Status varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SuratLantikan varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Path] varchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_MOU03_Ahli PRIMARY KEY (NoMemo, NoStaf),
	CONSTRAINT FK_MOU03_Ahli_MOU01_Memorandum FOREIGN KEY (NoMemo) REFERENCES DbEMO.dbo.MOU01_Memorandum(NoMemo)
);

-- DbEMO.dbo.MOU04_KPI definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU04_KPI;

CREATE TABLE DbEMO.dbo.MOU04_KPI (
	KPI_ID BIGINT IDENTITY(1,1) NOT NULL,
	Kod varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Amaun decimal(18,2) NULL,
	MOU04_Number numeric(18,0) NULL,
	Penerangan varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TarikhMula smalldatetime NULL,
	TarikhTamat smalldatetime NULL,
	Komen varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Nama varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Nilai numeric(18,0) NULL,
	CONSTRAINT PK_MOU04_KPI PRIMARY KEY (KPI_ID),
	CONSTRAINT FK_MOU04_KPI_MOU01_Memorandum FOREIGN KEY (NoMemo) REFERENCES DbEMO.dbo.MOU01_Memorandum(NoMemo)
);

-- DbEMO.dbo.MOU05_KPI_Progress definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU05_KPI_Progress;

CREATE TABLE DbEMO.dbo.MOU05_KPI_Progress (
	KPI_ID BIGINT NOT NULL,
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProgressID BIGINT IDENTITY(1,1) NOT NULL,
	Bukti nvarchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Amaun decimal(18,2) NULL,
	Number numeric(18,0) NULL,
	Penerangan varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TarikhKemaskini smalldatetime NULL,
	CONSTRAINT PK_MOU05_KPI_Progress_1 PRIMARY KEY (ProgressID),
	CONSTRAINT FK_MOU05_KPI_Progress_MOU04_KPI FOREIGN KEY (KPI_ID) REFERENCES DbEMO.dbo.MOU04_KPI(KPI_ID)
);

-- DbEMO.dbo.MOU_AuditLog definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU_AuditLog;

CREATE TABLE DbEMO.dbo.MOU_AuditLog (
	ID datetime2 NOT NULL,
	User_ID varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Tarikh_Transaksi smalldatetime NULL,
	Proses varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Value varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Nama_Table nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Sub_Menu nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Medan varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Info_Lama varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT MOU_AuditLog_PK PRIMARY KEY (ID)
);

-- DbEMO.dbo.MOU_Status definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU_Status;

CREATE TABLE DbEMO.dbo.MOU_Status (
	Kod varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Status varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT MOU_Status_PK PRIMARY KEY (Kod)
);

-- DbEMO.dbo.PUU_JenisMemo definition

-- Drop table

-- DROP TABLE DbEMO.dbo.PUU_JenisMemo;

CREATE TABLE DbEMO.dbo.PUU_JenisMemo (
	ID bigint NOT NULL,
	Kod int NOT NULL,
	Butiran varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	KodPejabat nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Pejabat nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PUU_JenisMemo_PK PRIMARY KEY (ID)
);

-- DbEMO.dbo.PUU_KategoriMemo definition

-- Drop table

-- DROP TABLE DbEMO.dbo.PUU_KategoriMemo;

CREATE TABLE DbEMO.dbo.PUU_KategoriMemo (
	ID bigint NOT NULL,
	Kod int NULL,
	Butiran varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PUU_KategoriMemo_PK PRIMARY KEY (ID)
);

-- DbEMO.dbo.PUU_ScopeMemo definition

-- Drop table

-- DROP TABLE DbEMO.dbo.PUU_ScopeMemo;

CREATE TABLE DbEMO.dbo.PUU_ScopeMemo (
	ID int NOT NULL,
	Kod int NOT NULL,
	Butiran varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PUU_ScopeMemo_PK PRIMARY KEY (ID)
);

-- DbEMO.dbo.PUU_SubPTj definition

-- Drop table

-- DROP TABLE DbEMO.dbo.PUU_SubPTj;

CREATE TABLE DbEMO.dbo.PUU_SubPTj (
	ID bigint NOT NULL,
	KodPTJ varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	KodSubPTJ varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Nama varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PUU_SubPTj_PK PRIMARY KEY (ID)
);

-- DbEMO.dbo.MOU06_History definition

-- Drop table

-- DROP TABLE DbEMO.dbo.MOU06_History;

CREATE TABLE DbEMO.dbo.MOU06_History (
	id bigint IDENTITY(0,1) NOT NULL,
	NoMemo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	NoStaf nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Description varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Created_At datetime NOT NULL,
	Comment varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT MOU06_History_PK PRIMARY KEY (id)
);