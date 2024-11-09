GO
CREATE TRIGGER tr_assentos_ocupados
ON assentos_passageiros_voos
INSTEAD OF INSERT
AS
BEGIN
	-- Inserir os dados na tabela assentos_passageiros_voos
    INSERT INTO assentos_passageiros_voos (ID_VOO, ID_ASSENTO, ID_PASSAGEIRO)
    SELECT ID_VOO, ID_ASSENTO, ID_PASSAGEIRO
    FROM inserted;
	
	DECLARE @assentos_ocupados AS INT;
	DECLARE @assentos_livres as INT;

	SELECT @assentos_livres = A.NUM_ASSENTOS, @assentos_ocupados = v.NUM_ASSENTOS_OCUPADOS	
	FROM AERONAVES AS A
	inner join VOOS AS V ON A.ID = V.ID_AERONAVE
	inner join inserted AS I ON V.ID = I.ID_VOO
	WHERE V.ID = I.ID_VOO;

	-- Atualizar o número de assentos ocupados
	UPDATE voos 
	SET 
		num_assentos_ocupados = (@assentos_ocupados + 1),
		num_assentos_livres = (@assentos_livres - @assentos_ocupados - 1)
	FROM voos
	INNER JOIN inserted ON inserted.ID_VOO = voos.ID
	WHERE inserted.ID_PASSAGEIRO IS NOT NULL;

	-- Atualizar o número de assentos livres
	--UPDATE voos
	--SET num_assentos_livres = (SELECT a.num_assentos FROM aeronaves AS a WHERE a.ID = voos.id_aeronave) - voos.num_assentos_ocupados
	--FROM voos
	--INNER JOIN inserted ON inserted.ID_VOO = voos.ID;
END;
GO

GO
CREATE TRIGGER tr_assentos_ocupados_update
ON assentos_passageiros_voos
INSTEAD OF UPDATE
AS
BEGIN
	-- Atualizar o número de assentos ocupados
	UPDATE voos 
	SET num_assentos_ocupados = num_assentos_ocupados + 1
	FROM voos
	INNER JOIN inserted ON inserted.ID_VOO = voos.ID;

	-- Atualizar o número de assentos livres
	UPDATE voos
	SET num_assentos_livres = (SELECT a.num_assentos FROM aeronaves AS a WHERE a.ID = voos.id_aeronave) - voos.num_assentos_ocupados
	FROM voos
	INNER JOIN inserted ON inserted.ID_VOO = voos.ID;
END;
GO