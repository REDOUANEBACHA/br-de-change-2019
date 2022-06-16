IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[employé]')) 
   ALTER TABLE [dbo].[employé] 
   ENABLE  CHANGE_TRACKING
GO
