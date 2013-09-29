EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'PNIM\Domain Users';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'PNIM\Domain Users';

