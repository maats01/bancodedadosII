# PartidaEquipe
CREATE VIEW PartidaView AS
SELECT
	p.id as id_partida,
    t.nome as nome_torneio,
    r.rodada as rodada,
    m.modalidade,
    e.nome as equipe,
    pe.pontos,
    pe.vencedor,
    p.empate,
    p.data_partida
FROM PartidaEquipe as pe
JOIN Partida p ON pe.partida_id = p.id
JOIN Torneio t ON t.id = p.torneio_id
JOIN Rodada r ON r.id = p.rodada_id
JOIN Modalidade m ON m.id = p.modalidade_id
JOIN Equipe e ON e.id = pe.equipe_id;

# EquipeChaveTorneio
CREATE VIEW ChaveamentoView AS
SELECT
	t.nome as nome_torneio,
    c_atual.chave as chave_atual,
    c_anterior.chave as chave_anterior,
    e.nome as equipe,
    ect.pontos
FROM EquipeChaveTorneio as ect
JOIN Torneio t ON t.id = ect.torneio_id
JOIN Chave c_atual ON c_atual.id = ect.chave_atual_id
LEFT JOIN Chave c_anterior ON c_anterior.id = ect.chave_anterior_id
JOIN Equipe e ON e.id = ect.equipe_id;