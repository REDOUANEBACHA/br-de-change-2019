IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[achat]')) 
   ALTER TABLE [dbo].[achat] 
   ENABLE  CHANGE_TRACKING
GO
