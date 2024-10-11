DROP SCHEMA IF EXISTS torneio;
CREATE SCHEMA torneio;
USE torneio;

CREATE TABLE Atleta(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255)
);

CREATE TABLE Equipe(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255)
);

CREATE TABLE Chave(
	id INT AUTO_INCREMENT PRIMARY KEY,
    chave VARCHAR(255)
);

CREATE TABLE Rodada(
	id INT AUTO_INCREMENT PRIMARY KEY,
    rodada VARCHAR(255)
);

CREATE TABLE Modalidade(
	id INT AUTO_INCREMENT PRIMARY KEY,
    modalidade varchar(255) 
);

CREATE TABLE Torneio(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome varchar(255),
    equipe_vencedora_id INT NOT NULL,
    data_inicio DATETIME,
    data_fim DATETIME,
    FOREIGN KEY (equipe_vencedora_id) REFERENCES Equipe(id)
);

CREATE TABLE EquipeChaveTorneio(
	torneio_id INT NOT NULL,
    chave_atual_id INT NOT NULL,
    chave_anterior_id INT,
    equipe_id INT NOT NULL,
    pontos INT DEFAULT(0),
    FOREIGN KEY (torneio_id) REFERENCES Torneio(id),
    FOREIGN KEY (equipe_id) REFERENCES Equipe(id),
    FOREIGN KEY (chave_atual_id) REFERENCES Chave(id),
    FOREIGN KEY (chave_anterior_id) REFERENCES Chave(id)
);

CREATE TABLE EquipeAtleta(
	atleta_id INT NOT NULL,
    equipe_id INT NOT NULL,
    FOREIGN KEY (atleta_id) REFERENCES Atleta(id),
    FOREIGN KEY (equipe_id) REFERENCES Equipe(id)
);

CREATE TABLE Partida(
	id INT AUTO_INCREMENT PRIMARY KEY,
    torneio_id INT NOT NULL,
    rodada_id INT NOT NULL,
    modalidade_id INT NOT NULL,
    empate BOOL DEFAULT(FALSE),
    data_partida DATETIME NOT NULL,
    FOREIGN KEY (torneio_id) REFERENCES Torneio(id),
    FOREIGN KEY (rodada_id) REFERENCES Rodada(id),
    FOREIGN KEY (modalidade_id) REFERENCES Modalidade(id)
);

CREATE TABLE PartidaEquipe(
	partida_id INT NOT NULL,
    equipe_id INT NOT NULL,
    pontos INT DEFAULT(0),
    vencedor BOOL DEFAULT(FALSE),
    FOREIGN KEY (partida_id) REFERENCES Partida(id),
    FOREIGN KEY (equipe_id) REFERENCES Equipe(id)
);