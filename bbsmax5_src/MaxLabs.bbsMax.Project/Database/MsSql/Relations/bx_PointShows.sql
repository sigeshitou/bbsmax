﻿EXEC bx_Drop 'FK_bx_PointShows_UserID';

ALTER TABLE [bx_PointShows]  WITH CHECK ADD  CONSTRAINT [FK_bx_PointShows_UserID] FOREIGN KEY([UserID])
REFERENCES [bx_Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE