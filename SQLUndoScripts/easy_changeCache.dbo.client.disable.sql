IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[client]')) 
   ALTER TABLE [dbo].[client] 
   DISABLE  CHANGE_TRACKING
GO
