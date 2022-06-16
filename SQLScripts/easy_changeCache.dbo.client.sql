IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[client]')) 
   ALTER TABLE [dbo].[client] 
   ENABLE  CHANGE_TRACKING
GO
