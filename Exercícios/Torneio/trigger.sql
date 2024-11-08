DELIMITER $$

CREATE TRIGGER atualiza_pontos_apos_partida
AFTER INSERT ON PartidaEquipe
FOR EACH ROW
BEGIN
	DECLARE total_equipes INT;
    DECLARE pontos_primeira_equipe INT;
    DECLARE pontos_segunda_equipe INT;
    
    SELECT COUNT(*) INTO total_equipes
    FROM PartidaEquipe WHERE partida_id = NEW.partida_id;
    
    IF total_equipes = 2 THEN
		SELECT pontos 
        INTO pontos_primeira_equipe
        FROM PartidaEquipe
        WHERE partida_id = NEW.partida_id
        ORDER BY equipe_id ASC
        LIMIT 1;
        
        SELECT pontos 
        INTO pontos_segunda_equipe
        FROM PartidaEquipe
        WHERE partida_id = NEW.partida_id
        ORDER BY equipe_id DESC
        LIMIT 1;
        
        IF pontos_primeira_equipe = pontos_segunda_equipe THEN
			UPDATE EquipeChaveTorneio AS ect
            SET ect.pontos = ect.pontos + 1
            WHERE ect.equipe_id IN (
				SELECT equipe_id FROM PartidaEquipe WHERE partida_id = NEW.partida_id
            ) AND
            ect.chave_id = (
				SELECT p.chave_id
                FROM Partida AS p
                WHERE p.id = NEW.partida_id
            );
		ELSE
			UPDATE EquipeChaveTorneio AS ect
            SET ect.pontos = ect.pontos + 3
            WHERE ect.equipe_id = (
				SELECT equipe_id 
                FROM PartidaEquipe
                WHERE partida_id = NEW.partida_id AND 
                vencedor = TRUE
            ) AND
            ect.chave_id = (
				SELECT p.chave_id
                FROM Partida AS p
                WHERE p.id = NEW.partida_id
            );
		END IF;
	END IF;
END$$

DELIMITER ;