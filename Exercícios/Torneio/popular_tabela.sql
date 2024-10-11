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

-- Inserindo modalidades
INSERT INTO Modalidade (modalidade) VALUES ('Futebol');

-- Criando um torneio
INSERT INTO Torneio (nome, equipe_vencedora_id, data_inicio, data_fim) 
VALUES ('Torneio 2024', 1, '2024-09-01 10:00:00', '2024-09-30 18:00:00');

-- Criando partidas
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-02');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-02');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-03');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, TRUE, '2024-09-03');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, TRUE, '2024-09-04');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-04');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-05');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-05');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, TRUE, '2024-09-06');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-06');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-07');
INSERT INTO Partida (torneio_id, rodada_id, modalidade_id, empate, data_partida) VALUES (1, 2, 1, FALSE, '2024-09-07');

-- Inserindo relações em EquipeChaveTorneio
-- equipes da chave A
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 1, NULL, 1);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 1, NULL, 2);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 1, NULL, 3);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 1, NULL, 4);
-- equipes da chave B
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 2, NULL, 5);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 2, NULL, 6);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 2, NULL, 7);
INSERT INTO EquipeChaveTorneio (torneio_id, chave_atual_id, chave_anterior_id, equipe_id) VALUES (1, 2, NULL, 8);

-- Inserindo relações em PartidaEquipe
-- Relações da Chave A
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

-- Relações da Chave B
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