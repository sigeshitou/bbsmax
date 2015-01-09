
BEGIN
	DECLARE @username NVARCHAR(256)
	DECLARE @t_name NVARCHAR(100)
	DECLARE @fk_name NVARCHAR(100)
		DECLARE cs_fks CURSOR FOR SELECT user_name(ot.uid),ot.name out_table_name,object_name(fk.constid) constraint_name FROM sysforeignkeys fk INNER JOIN sysobjects ot ON ot.id=fk.fkeyid ORDER BY ot.id,fk.constid FOR READ ONLY


		OPEN cs_fks

		FETCH NEXT FROM cs_fks INTO @username,@t_name,@fk_name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @username IS NOT NULL BEGIN
				IF @t_name LIKE 'Max_%' OR @t_name LIKE 'bbsMax_%' OR @t_name LIKE 'System_Max_%' OR @t_name LIKE 'System_bbsMax_%' OR @t_name LIKE 'bx_%'
				BEGIN
					EXEC('ALTER TABLE ['+@username+'].['+@t_name+'] DROP CONSTRAINT ['+@fk_name+']')
				END
			END
			FETCH NEXT FROM cs_fks INTO @username,@t_name,@fk_name
		END

		CLOSE cs_fks
		DEALLOCATE cs_fks
	
END
--END DROP FKS

--BEGIN DROP VIEWS

BEGIN
		--DECLARE @username NVARCHAR(256)
	DECLARE @v_name NVARCHAR(100)
		DECLARE cs_views CURSOR FOR SELECT user_name(o.uid),o.name FROM sysobjects o WHERE o.type='V' ORDER BY o.id FOR READ ONLY

		OPEN cs_views

		FETCH NEXT FROM cs_views INTO @username,@v_name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @username IS NOT NULL BEGIN
				IF @v_name LIKE 'Max_%' OR @v_name LIKE 'bbsMax_%' OR @v_name LIKE 'System_Max_%' OR @v_name LIKE 'System_bbsMax_%' OR @v_name LIKE 'bx_%'
				BEGIN
					EXEC('DROP VIEW ['+@username+'].['+@v_name+']')
				END
			END
			FETCH NEXT FROM cs_views INTO @username,@v_name
		END

		CLOSE cs_views
		DEALLOCATE cs_views

END
--END DROP VIEWS

--BEGIN DROP TABLES

BEGIN
		--DECLARE @username NVARCHAR(256)
	--DECLARE @t_name NVARCHAR(100)
		DECLARE cs_tables CURSOR FOR SELECT user_name(o.uid),o.name FROM sysobjects o WHERE o.type='U' ORDER BY o.id FOR READ ONLY


		OPEN cs_tables

		FETCH NEXT FROM cs_tables INTO @username,@t_name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @username IS NOT NULL BEGIN
				IF @t_name LIKE 'Max_%' OR @t_name LIKE 'bbsMax_%' OR @t_name LIKE 'System_Max_%' OR @t_name LIKE 'System_bbsMax_%' OR @t_name LIKE 'bx_%'
				BEGIN
					EXEC('DROP TABLE ['+@username+'].['+@t_name+']')
				END
			END
			FETCH NEXT FROM cs_tables INTO @username,@t_name
		END

		CLOSE cs_tables
		DEALLOCATE cs_tables
END

--END DROP TABLES

--BEGIN DROP STORE PROCEDURES

BEGIN
		--DECLARE @username NVARCHAR(256)
	DECLARE @p_name NVARCHAR(100)
		DECLARE cs_ps CURSOR FOR SELECT DISTINCT user_name(p.uid),p.name FROM sysobjects p WHERE p.type = 'P' FOR READ ONLY

		OPEN cs_ps

		FETCH NEXT FROM cs_ps INTO @username,@p_name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @username IS NOT NULL BEGIN
				IF @p_name LIKE 'Max_%' OR @p_name LIKE 'bbsMax_%' OR @p_name LIKE 'System_Max_%' OR @p_name LIKE 'System_bbsMax_%' OR @p_name LIKE 'bx_%'
				BEGIN
					EXEC('DROP PROCEDURE ['+@username+'].['+@p_name+']')
				END
			END
			FETCH NEXT FROM cs_ps INTO @username,@p_name
		END

		CLOSE cs_ps
		DEALLOCATE cs_ps
END

--END DROP STORE PROCEDURES

--BEGIN DROP FUNCTIONS

BEGIN

	--DECLARE @username NVARCHAR(256)
	DECLARE @f_name NVARCHAR(100)
		DECLARE cs_fs CURSOR FOR SELECT DISTINCT user_name(f.uid),f.name FROM sysobjects f WHERE f.type IN ('FN','TF') FOR READ ONLY

		OPEN cs_fs

		FETCH NEXT FROM cs_fs INTO @username,@f_name
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @username IS NOT NULL BEGIN
				IF @f_name LIKE 'Max_%' OR @f_name LIKE 'bbsMax_%' OR @f_name LIKE 'System_Max_%' OR @f_name LIKE 'System_bbsMax_%' OR @f_name LIKE 'bx_%'
				BEGIN
					EXEC('DROP FUNCTION ['+@username+'].['+@f_name+']');
				END
			END

			FETCH NEXT FROM cs_fs INTO @username,@f_name
		END
	    
		CLOSE cs_fs
		DEALLOCATE cs_fs
END

--END DROP FUNCTIONS