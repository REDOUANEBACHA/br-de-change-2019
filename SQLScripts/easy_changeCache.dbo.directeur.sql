IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[directeur]')) 
   ALTER TABLE [dbo].[directeur] 
   ENABLE  CHANGE_TRACKING
GO
