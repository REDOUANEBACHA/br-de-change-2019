IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[vente]')) 
   ALTER TABLE [dbo].[vente] 
   ENABLE  CHANGE_TRACKING
GO
