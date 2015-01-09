﻿--网络硬盘文件夹表外键关系

EXEC bx_Drop 'FK_bx_DiskDirectories_UserID';

ALTER TABLE [bx_DiskDirectories] ADD
     CONSTRAINT [FK_bx_DiskDirectories_UserID]           FOREIGN KEY ([UserID])          REFERENCES [bx_Users]            ([UserID])      ON UPDATE CASCADE    ON DELETE CASCADE
GO