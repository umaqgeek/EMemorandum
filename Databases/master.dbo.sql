-- master.dbo.Products definition

-- Drop table

-- DROP TABLE master.dbo.Products;

CREATE TABLE master.dbo.Products (
	id int IDENTITY(0,1) NOT NULL,
	name varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	quantity int NOT NULL
);


-- master.dbo.Users definition

-- Drop table

-- DROP TABLE master.dbo.Users;

CREATE TABLE master.dbo.Users (
	name varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	email varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	address varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	id int IDENTITY(1,1) NOT NULL
);