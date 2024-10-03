DECLARE @NewID TABLE (NewId INT);
DECLARE @Descrim AS NVARCHAR(10);

SET @Descrim = 'mach';
INSERT INTO _Org (Id, Code, Descr) VALUES (1, 'Org1', 'Organisation 1');
INSERT INTO _Org (Id, Code, Descr) VALUES (2, 'Org2', 'Organisation 2');

INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'M1', 'Machine 1') ;
INSERT INTO Machine (_Id, StationPairs) VALUES ((select NewId from @NewID), 15);
DELETE FROM @NewID;
INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'M2', 'Machine 2');
INSERT INTO Machine (_Id, StationPairs) VALUES ((select NewId from @NewID), 15);
DELETE FROM @NewID;
INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'M3', null);
INSERT INTO Machine (_Id, StationPairs) VALUES ((select NewId from @NewID), 30);
DELETE FROM @NewID;

SET @Descrim = 'mldg';
INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'MG1', 'Mould Group 1') ;
INSERT INTO MouldGroup (_Id) VALUES ((select NewId from @NewID));
DELETE FROM @NewID;
INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'MG2', 'Mould Group 2');
INSERT INTO MouldGroup (_Id) VALUES ((select NewId from @NewID));
DELETE FROM @NewID;
INSERT INTO _BaseEntity (_OrgId, Descrim, Code,	Descr) OUTPUT INSERTED.Id INTO @NewId VALUES (1, @Descrim, 'MG3', null);
INSERT INTO MouldGroup (_Id) VALUES ((select NewId from @NewID));
DELETE FROM @NewID;


select * from _baseEntity
select * from MouldGroup
select * from Machine