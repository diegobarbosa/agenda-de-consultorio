   -- Cenários de Referência (usando o seed.sql):
   -- Dessa forma é possível term um horário 14:00 às 15:00 e de 15:00 às 16:00
         
	declare @hojeStr varchar(100)=cast(cast(getdate() as date) as varchar)
	
	--declare @novaDataInicial datetime =@hojeStr +' 06:00' 
 --   declare @novaDataFinal datetime =  @hojeStr +' 07:00'

	declare @novaDataInicial datetime = @hojeStr+' 07:30'
    declare @novaDataFinal datetime =   @hojeStr+' 07:40'

    --declare @novaDataInicial datetime = @hojeStr+' 15:00'
    --declare @novaDataFinal datetime =   @hojeStr+' 16:00'

    select * 
    from atendimento atend
    where
	(
		   (atend.data_final > @novaDataInicial  and atend.data_final <= @novaDataFinal )   -- caso 1

		or (atend.data_inicial >= @novaDataInicial and atend.data_inicial < @novaDataFinal) -- caso 2
	
		or (atend.data_inicial = @novaDataInicial and atend.data_final = @novaDataFinal)    -- caso 3
	
		or (atend.data_inicial > @novaDataInicial and atend.data_final < @novaDataFinal)    -- caso 4 

		or (atend.data_inicial < @novaDataInicial and atend.data_final > @novaDataFinal)    -- caso 5
	
	)
         
--       @d1 |--------| @d2       
--           .        . |--------| @d2 < start_date
--           .        |--------|   @d2 = start_date
--|--------| .        .            end_date < @d1
--  |--------|        .            end_date = @d1
--    |--------|      .            OVERLAPS - FEITO -- caso 1
--           .      |--------|     OVERLAPS - FEITO -- caso 2
--           |--------|            OVERLAPS - FEITO -- caso 3
--           . |----| .            OVERLAPS - FEITO -- caso 4
--         |------------|          OVERLAPS - FEITO -- caso 5
		 
		        
        