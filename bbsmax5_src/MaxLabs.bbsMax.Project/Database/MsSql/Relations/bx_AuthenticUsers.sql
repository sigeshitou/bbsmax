﻿ALTER TABLE [bx_AuthenticUsers]  WITH CHECK ADD  CONSTRAINT [FK_bx_AuthenticUsers_bx_Users] FOREIGN KEY([UserID])
REFERENCES [bx_Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE