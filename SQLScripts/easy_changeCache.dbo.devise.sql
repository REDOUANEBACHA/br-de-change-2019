IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[devise]')) 
   ALTER TABLE [dbo].[devise] 
   ENABLE  CHANGE_TRACKING
GO
