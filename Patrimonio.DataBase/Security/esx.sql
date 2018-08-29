
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [esx]    Script Date: 28/08/2018 22:55:16 ******/
CREATE LOGIN [esx] WITH PASSWORD=N'Ï)01Ú6ýZX:m
­éèçmq;ñ~ýcx0z', DEFAULT_DATABASE=[ESXDESAFIO], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [esx] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [esx]
GO


CREATE USER [esx] FOR LOGIN [esx];

