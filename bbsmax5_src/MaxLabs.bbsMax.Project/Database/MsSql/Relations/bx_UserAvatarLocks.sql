﻿
--ALTER TABLE bx_UserAvatarLocks ADD CONSTRAINT FK_bx_UserAvatarLocks_UserID FOREIGN KEY (UserID) REFERENCES bx_Users (UserID) ON UPDATE CASCADE ON DELETE CASCADE
