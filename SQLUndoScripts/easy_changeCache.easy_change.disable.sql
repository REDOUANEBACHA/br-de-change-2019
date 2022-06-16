-- Ce code permet de désactiver le suivi des modifications dans votre base de données
-- Assurez-vous que toutes les tables ont cessé d'utiliser le suivi des modifications avant d'exécuter ce code
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'easy_change')) 
  ALTER DATABASE [easy_change] 
  SET  CHANGE_TRACKING = OFF
GO
