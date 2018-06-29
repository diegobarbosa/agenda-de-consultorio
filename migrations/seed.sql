truncate table atendimento 
GO


declare @hoje varchar(100) =  cast(cast(getdate() as date) as varchar) 


INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Maria Vicente',
		   '1952-05-01'--<id_paciente, int,>
           ,@hoje +' 07:00'--<data_inicial, datetime,>
           ,@hoje +' 08:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
          
		   )

INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Maria Clara',
		   '1972-05-01'--<id_paciente, int,>
           ,@hoje +' 08:00'--<data_inicial, datetime,>
           ,@hoje +' 09:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )

INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Maria Vitória',
		   '1982-05-01'--<id_paciente, int,>
           ,@hoje +' 09:00'--<data_inicial, datetime,>
           ,@hoje +' 10:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )


INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Marta Silva',
		   '1992-05-01'--<id_paciente, int,>
           ,@hoje +' 10:00'--<data_inicial, datetime,>
           ,@hoje +' 11:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )

INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Jananina Silva',
		   '1942-05-01'--<id_paciente, int,>
           ,@hoje +' 11:00'--<data_inicial, datetime,>
           ,@hoje +' 12:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )



INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Bianca Luiza',
		   '1992-05-01'--<id_paciente, int,>
           ,@hoje +' 12:00'--<data_inicial, datetime,>
           ,@hoje +' 13:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )

INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Cassiane Joice',
		   '2000-05-01'--<id_paciente, int,>
           ,@hoje +' 13:00'--<data_inicial, datetime,>
           ,@hoje +' 14:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )

INSERT INTO [dbo].[atendimento]
           ([paciente_nome]
		   ,[paciente_data_nascimento]
           ,[data_inicial]
           ,[data_final]
           ,[observacao]
           ,[status]
           ,[data_cadastro]
           ,[data_cancelamento]
           )
     VALUES
           ('Eliana Luíza'
		   ,'1972-05-01'--<id_paciente, int,>
           ,@hoje +' 14:00'--<data_inicial, datetime,>
           ,@hoje +' 15:00'--<data_final, datetime,>
           ,''--<observacao, varchar(500),>
           ,'MARC'--<status, varchar(10),>
           ,getdate()--<data_cadastro, datetime,>
           ,null--<data_cancelamento, datetime,>
           
		   )







