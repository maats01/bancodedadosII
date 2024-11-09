USE TRANSPORTE_AEREO;
--CREATE DATABASE TRANSPORTE_AEREO;
create table AEROPORTOS
(
	ID int identity (1,1) primary key,
    NOME_AEROPORTO nvarchar(255) not null,
    CIDADE nvarchar(255) not null,
    ESTADO nvarchar(255) not null,
    PAIS nvarchar(255) not null
);

create table PESSOAS
(
	ID int identity (1,1) primary key,
    NOME_COMPLETO nvarchar(255)
);

create table TIPOS_AERONAVES
(
	ID int identity (1,1) primary key,
    TIPO nvarchar(255) not null,
    DESC_TIPO nvarchar(255) not null
);

create table FABRICANTES
(
	ID int identity (1,1) primary key,
    FABRICANTE nvarchar(255) not null
);

create table ASSENTOS
(
	ID int identity (1,1) primary key,
    LADO nvarchar(10),
    POSICAO nvarchar(255),
    LINHA int not null
);

create table AERONAVES
(
	ID int identity (1,1) primary key,
    MODELO nvarchar(100) not null,
    ID_FABRICANTE int not null,
    ID_TIPO int not null,
    NUM_ASSENTOS int not null,
    foreign key (ID_TIPO) references TIPOS_AERONAVES(ID),
    foreign key (ID_FABRICANTE) references FABRICANTES(ID)
);

create table PILOTOS
(
	ID int identity (1,1) primary key,
    ID_PESSOA int not null,
    foreign key (ID_PESSOA) references PESSOAS(ID)
);

create table VOOS
(
	ID int identity (1,1) primary key,
    ID_AEROPORTO_ORIGEM int not null,
    ID_AEROPORTO_DESTINO int not null,
    ID_AERONAVE int not null,
    ID_PILOTO int not null,
    NUM_ASSENTOS_OCUPADOS int not null DEFAULT 0,
    NUM_ASSENTOS_LIVRES int,
    HORARIO_SAIDA datetime not null,
    HORARIO_CHEGADA datetime not null,
    foreign key (ID_AEROPORTO_ORIGEM) references AEROPORTOS(ID),
    foreign key (ID_AEROPORTO_DESTINO) references AEROPORTOS(ID),
    foreign key (ID_AERONAVE) references AERONAVES(ID),
    foreign key (ID_PILOTO) references PILOTOS(ID)
);

create table PASSAGEIROS
(
	ID int identity (1,1) primary key,
    ID_PESSOA int not null,
    foreign key (ID_PESSOA) references PESSOAS(ID)
);

create table ASSENTOS_PASSAGEIROS_VOOS
(
    ID_VOO int not null,
    ID_ASSENTO int not null,
    ID_PASSAGEIRO int default null,
    primary key (ID_VOO, ID_ASSENTO),
    foreign key (ID_VOO) references VOOS(ID),
    foreign key (ID_ASSENTO) references ASSENTOS(ID),
    foreign key (ID_PASSAGEIRO) references PASSAGEIROS(ID)
);

create table ESCALAS
(
	ID int identity (1,1) primary key,
    ID_AEROPORTO int not null,
    foreign key (ID_AEROPORTO) references AEROPORTOS(ID)
);

create table VOOS_ESCALAS
(
	ID int identity (1,1) primary key,
    ID_VOO int not null,
    ID_ESCALA int not null,
    HORARIO_CHEGADA datetime not null,
    HORARIO_SAIDA datetime not null,
    foreign key (ID_VOO) references VOOS(ID),
    foreign key (ID_ESCALA) references ESCALAS(ID)
);