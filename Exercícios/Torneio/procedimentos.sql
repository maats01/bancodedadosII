DELIMITER $$

CREATE PROCEDURE ResultadoPorChave(IN chaveamento VARCHAR(255))
BEGIN
	SELECT * FROM ChaveamentoView
	WHERE chave_atual = chaveamento
	ORDER BY pontos DESC;
END $$

CREATE PROCEDURE VerPartidaPorEquipe(IN equipe_nome VARCHAR(255))
BEGIN
	SELECT * FROM PartidaView
    WHERE equipe = equipe_nome;
END $$

DELIMITER ;