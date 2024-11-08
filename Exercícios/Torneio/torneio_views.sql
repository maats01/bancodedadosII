# PartidaEquipe
CREATE VIEW PartidaView AS
SELECT
	p.id as id_partida,
    t.nome as nome_torneio,
    r.rodada as rodada,
    c.chave as chave,
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
JOIN Equipe e ON e.id = pe.equipe_id
JOIN Chave c ON c.id = p.chave_id;

# EquipeChaveTorneio
CREATE VIEW ChaveamentoView AS
SELECT
	t.nome as nome_torneio,
    c.chave,
    e.nome as equipe,
    ect.pontos
FROM EquipeChaveTorneio as ect
JOIN Torneio t ON t.id = ect.torneio_id
JOIN Chave c ON c.id = ect.chave_id
JOIN Equipe e ON e.id = ect.equipe_id
ORDER BY ect.chave_id, ect.pontos DESC;