-- Inserindo equipes
INSERT INTO Equipe (nome) VALUES ('Equipe 1');
INSERT INTO Equipe (nome) VALUES ('Equipe 2');
INSERT INTO Equipe (nome) VALUES ('Equipe 3');
INSERT INTO Equipe (nome) VALUES ('Equipe 4');
INSERT INTO Equipe (nome) VALUES ('Equipe 5');
INSERT INTO Equipe (nome) VALUES ('Equipe 6');
INSERT INTO Equipe (nome) VALUES ('Equipe 7');
INSERT INTO Equipe (nome) VALUES ('Equipe 8');

-- Inserindo rodadas
INSERT INTO Rodada (rodada) VALUES ('Classificatória');
INSERT INTO Rodada (rodada) VALUES ('Quartas de Final');
INSERT INTO Rodada (rodada) VALUES ('Semifinal');
INSERT INTO Rodada (rodada) VALUES ('Final');

-- Inserindo chaves
INSERT INTO Chave (chave) VALUES ('Chave A');
INSERT INTO Chave (chave) VALUES ('Chave B');
INSERT INTO Chave (chave) VALUES ('Chave C');
INSERT INTO Chave (chave) VALUES ('Chave D');
INSERT INTO Chave (chave) VALUES ('Chave E');
INSERT INTO Chave (chave) VALUES ('Chave F');

-- Inserindo modalidades
INSERT INTO Modalidade (modalidade) VALUES ('Futebol');

-- Criando um torneio
INSERT INTO Torneio (nome, data_inicio, data_fim) 
VALUES ('Torneio 2024', '2024-09-01 10:00:00', '2024-09-30 18:00:00');

-- Criando partidas
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, FALSE, '2024-09-02');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, FALSE, '2024-09-02');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, FALSE, '2024-09-03');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, TRUE, '2024-09-03');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, TRUE, '2024-09-04');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, 1, FALSE, '2024-09-04');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, FALSE, '2024-09-05');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, FALSE, '2024-09-05');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, TRUE, '2024-09-06');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, FALSE, '2024-09-06');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, FALSE, '2024-09-07');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 2, 2, 1, FALSE, '2024-09-07');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 3, 3, 1, FALSE, '2024-09-08');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 3, 4, 1, FALSE, '2024-09-08');
INSERT INTO Partida (torneio_id, rodada_id, chave_id, modalidade_id, empate, data_partida) VALUES (1, 4, 5, 1, FALSE, '2024-09-09');

-- Inserindo relações em EquipeChaveTorneio
-- equipes da chave A
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 1, 1);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 1, 2);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 1, 3);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 1, 4);

-- equipes da chave B
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 2, 5);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 2, 6);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 2, 7);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 2, 8);

-- equipes da chave C
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 3, 1);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 3, 8);

-- equipes da chave D
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 4, 3);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 4, 5);

-- equipes da chave E
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 5, 1);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_id, equipe_id) VALUES (1, 5, 5);

-- Inserindo relações em PartidaEquipe
-- relações da Chave A
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (1, 1, 3, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (1, 2, 2, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (2, 1, 2, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (2, 3, 0, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (3, 1, 1, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (3, 4, 0, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (4, 2, 2, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (4, 3, 2, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (5, 2, 1, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (5, 4, 1, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (6, 3, 1, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (6, 4, 0, FALSE);

-- relações da Chave B
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (7, 5, 3, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (7, 6, 1, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (8, 5, 0, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (8, 7, 1, TRUE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (9, 5, 2, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (9, 8, 2, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (10, 6, 2, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (10, 7, 1, FALSE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (11, 6, 0, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (11, 8, 2, TRUE);

INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (12, 7, 0, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (12, 8, 1, TRUE);

-- relações da Chave C
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (13, 1, 3, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (13, 8, 2, FALSE);

-- relações da Chave D
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (14, 3, 1, FALSE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (14, 5, 2, TRUE);

-- relações da Chave E
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (15, 1, 4, TRUE);
INSERT INTO PartidaEquipe (partida_id, equipe_id, pontos, vencedor) VALUES (15, 5, 3, FALSE);