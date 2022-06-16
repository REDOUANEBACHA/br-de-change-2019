IF NOT EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'easy_change')) 
   ALTER DATABASE [easy_change] 
   SET  CHANGE_TRACKING = ON
GO
