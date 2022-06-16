IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[directeur]')) 
   ALTER TABLE [dbo].[directeur] 
   DISABLE  CHANGE_TRACKING
GO
