from faker import Faker
import pyodbc

fake = Faker('pt_BR')
connString = (
    r'DRIVER={ODBC Driver 17 for SQL Server};'  # Verifique se o driver está instalado
    r'SERVER=(localdb)\MSSQLLocalDB;'
    r'DATABASE=TRANSPORTE_AEREO;'  # Nome do seu banco de dados
    r'Trusted_Connection=yes;'
)
conn = pyodbc.connect(connString)

cursor = conn.cursor()
fake.name

# inserindo aeroportos
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto de Guarulhos', 'São Paulo', 'São Paulo', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional de Recife/Guararapes - Gilberto Freyre', 'Recife', 'Pernambuco', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional de Congonhas', 'São Paulo', 'São Paulo', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional de Brasília', 'Brasília', 'Distrito Federal', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional do Rio de Janeiro/Galeão - Antônio Carlos Jobim', 'Rio de Janeiro', 'Rio de Janeiro', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional Afonso Pena', 'São José dos Pinhais', 'Paraná', 'Brasil')")
cursor.execute("INSERT INTO aeroportos(NOME_AEROPORTO, CIDADE, ESTADO, PAIS) VALUES ('Aeroporto Internacional de Salvador - Deputado Luís Eduardo Magalhães', 'Salvador', 'Bahia', 'Brasil')")
conn.commit()

# inserindo escalas
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (1)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (2)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (3)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (4)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (5)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (6)")
cursor.execute("INSERT INTO escalas(ID_AEROPORTO) VALUES (7)")
conn.commit()

# inserindo tipos de aeronaves
cursor.execute("INSERT INTO tipos_aeronaves(TIPO, DESC_TIPO) VALUES('Jato Comercial', 'Aeronave de passageiros de grande porte')")
cursor.execute("INSERT INTO tipos_aeronaves(TIPO, DESC_TIPO) VALUES('Jato Executivo', 'Aeronave de passageiros de pequeno porte')")
cursor.execute("INSERT INTO tipos_aeronaves(TIPO, DESC_TIPO) VALUES('Jato regional', 'Aeronave de médio alcance')")
cursor.execute("INSERT INTO tipos_aeronaves(TIPO, DESC_TIPO) VALUES('Aeronave de Carga', 'Aeronave utilizada exclusivamente para carga')")
cursor.execute("INSERT INTO tipos_aeronaves(TIPO, DESC_TIPO) VALUES('Turboélice Comercial', 'Aeronave de passageiros com motores turboélice')")
conn.commit()

# inserindo registros em fabricantes
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Airbus')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Boeing')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Gulfstream')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Cessna')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('ATR')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Bombardier')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Antonov')")
cursor.execute("INSERT INTO fabricantes(FABRICANTE) VALUES('Embraer')")
conn.commit()

# inserindo registros em aeronaves
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('A320', 1, 1, 180)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('A350', 1, 1, 350)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('737', 2, 1, 160)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('777', 2, 1, 396)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('E195', 8, 3, 120)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('G650', 3, 2, 18)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('Citation X', 4, 2, 12)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('72', 5, 5, 12)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('Dash 8', 6, 5, 12)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('747-8F', 2, 4, 0)")
cursor.execute("INSERT INTO aeronaves(MODELO, ID_FABRICANTE, ID_TIPO, NUM_ASSENTOS) VALUES('An-124', 7, 4, 0)")
conn.commit()

# inserindo registros em pessoas/pilotos/passageiros
for i in range(600):
    name = fake.name()
    cursor.execute(f"INSERT INTO pessoas (NOME_COMPLETO) VALUES ('{name}')")
    cursor.execute("SELECT SCOPE_IDENTITY()")
    lastPersonId = cursor.fetchone()[0]
    if i % 15 == 0:
        cursor.execute(f"INSERT INTO pilotos (ID_PESSOA) VALUES ({lastPersonId})")
    else:
        cursor.execute(f"INSERT INTO passageiros (ID_PESSOA) VALUES ({lastPersonId})")

    conn.commit()

# inserindo registros em assentos
for i in range(80):
    for j in range(3):
        pos = ["JANELA", "MEIO", "CORREDOR"]
        actualPos = pos[j]
        cursor.execute(f"INSERT INTO assentos (LADO, POSICAO, LINHA) VALUES ('ESQUERDA', '{actualPos}', {i+1})")
        cursor.execute(f"INSERT INTO assentos (LADO, POSICAO, LINHA) VALUES ('DIREITA', '{actualPos}', {i+1})")
        conn.commit()

# inserindo voos
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (1, 5, 2, 7, '2024-06-01 09:00:00', '2024-06-01 14:30:00')")
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (1, 3, 4, 1, '2024-06-05 15:00:00', '2024-06-05 19:30:00');")
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (2, 7, 1, 3, '2024-06-15 16:00:00', '2024-06-15 21:30:00')")
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (3, 4, 3, 10, '2024-05-01 18:00:00', '2024-05-01 02:30:00')")
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (4, 3, 5, 15, '2024-05-25 15:00:00', '2024-05-25 19:30:00')")
cursor.execute("INSERT INTO voos(ID_AEROPORTO_ORIGEM, ID_AEROPORTO_DESTINO, ID_AERONAVE, ID_PILOTO, HORARIO_SAIDA, HORARIO_CHEGADA) VALUES (5, 6, 6, 4, '2024-05-28 13:00:00', '2024-05-28 18:30:00')")
conn.commit()

# inserindo relações de voos e escalas
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(1, 3, '2024-06-01 12:00:00', '2024-06-01 13:00:00')")
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(2, 6, '2024-06-05 16:45:00', '2024-06-05 17:45:00')")
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(3, 2, '2024-06-15 18:00:00', '2024-06-15 19:00:00')")
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(4, 4, '2024-05-01 19:30:00', '2024-05-01 20:45:00')")
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(4, 3, '2024-05-01 22:45:00', '2024-05-01 23:45:00')")
cursor.execute("INSERT INTO voos_escalas(ID_VOO, ID_ESCALA, HORARIO_CHEGADA, HORARIO_SAIDA) VALUES(5, 4, '2024-05-25 17:00:00', '2024-05-25 17:45:00')")
conn.commit()

cursor.close()
conn.close()