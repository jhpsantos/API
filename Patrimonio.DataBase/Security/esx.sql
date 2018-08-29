﻿
CREATE LOGIN [esxapp] WITH PASSWORD=N'esxapp', DEFAULT_DATABASE=[ESXDESAFIO], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [esxapp]
GO

CREATE USER [esxapp] FOR LOGIN [esxapp] WITH DEFAULT_SCHEMA=[dbo]
GO


