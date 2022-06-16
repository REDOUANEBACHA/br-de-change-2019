IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[devise]')) 
   ALTER TABLE [dbo].[devise] 
   DISABLE  CHANGE_TRACKING
GO
