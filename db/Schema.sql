DROP TABLE IF EXISTS Machine
DROP TABLE IF EXISTS MouldGroup;
DROP TABLE IF EXISTS _BaseEntity
DROP TABLE IF EXISTS _Org



CREATE TABLE _Org (
    Id         INT             PRIMARY KEY NOT NULL,
	Code       NVARCHAR (100)  NOT NULL,
	Descr      NVARCHAR (MAX)  NOT NULL
)
CREATE TABLE _BaseEntity (
	_OrgId     INT             NOT NULL,
    Id         INT             PRIMARY KEY IDENTITY (10000, 1) NOT NULL,
	Descrim    NVARCHAR (100)  NOT NULL,
	Code       NVARCHAR (100)  NOT NULL,
	Descr      NVARCHAR (MAX)  NULL,
	Encoded    NVARCHAR (MAX)  NULL,
	Updated    DATETIME        NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (_OrgId) REFERENCES _Org(Id)
)
CREATE TABLE Machine (
    Id           INT             PRIMARY KEY IDENTITY (10000, 1) NOT NULL,
	_Id          INT             NOT NULL,
	StationPairs INT             NOT NULL,
	FOREIGN KEY (_Id) REFERENCES _BaseEntity(Id)
)
CREATE TABLE MouldGroup (
    Id         INT             PRIMARY KEY IDENTITY (10000, 1) NOT NULL,
	_Id        INT             NOT NULL,
	FOREIGN KEY (_Id) REFERENCES _BaseEntity(Id)
);
