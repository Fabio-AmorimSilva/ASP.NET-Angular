--
-- File generated with SQLiteStudio v3.3.3 on ter ago 3 16:44:08 2021
--
-- Text encoding used: UTF-8
--

-- Table: Agencia
Select * FROM Agencias;
INSERT INTO Agencias (nome, cidade, idCorretor, idImovel) VALUES ('Imoveis Jandira', 'Jandira', 1, 1);
INSERT INTO Agencias (nome, cidade, idCorretor, idImovel) VALUES ('Imoveis Barueri', 'Barueri', 2, 2);
INSERT INTO Agencias (nome, cidade, idCorretor, idImovel) VALUES ('Imoveis Carapicuiba', 'Carapicuiba', 3, 3);
INSERT INTO Agencias (nome, cidade, idCorretor, idImovel) VALUES ('Imoveis Osasco', 'Osasco', 4, 4);

-- Table: Corretor
SELECT * FROM Corretores;
INSERT INTO Corretores (idAgencia, nome, idade, vendas) VALUES (1, 'Fabio', 26, 10);
INSERT INTO Corretores (idAgencia, nome, idade, vendas) VALUES (2, 'Joao', 30, 20);
INSERT INTO Corretores (idAgencia, nome, idade, vendas) VALUES (3, 'Maria', 31, 30);
INSERT INTO Corretores (idAgencia, nome, idade, vendas) VALUES (4, 'Joana', 20, 5);

-- Table: Dono
SELECT * FROM Donos;
INSERT INTO Donos (nome, idade, imovel) VALUES ('Mariana', 20, 'Jandira');
INSERT INTO Donos (nome, idade, imovel) VALUES ('Paulo', 21, 'Barueri');
INSERT INTO Donos (nome, idade, imovel) VALUES ('Juliana', 25, 'Carapicuiba');
INSERT INTO Donos (nome, idade, imovel) VALUES ('Lucas', 30, 'Osasco');

-- Table: Imovel
SELECT * FROM Imoveis;
INSERT INTO Imoveis (idDono, idAgencia, endereco, preco) VALUES (1, 1, 'Jandira', 100.0);
INSERT INTO Imoveis (idDono, idAgencia, endereco, preco) VALUES (2, 2, 'Barueri', 200.0);
INSERT INTO Imoveis (idDono, idAgencia, endereco, preco) VALUES (3, 3, 'Carapicuiba', 80.0);
INSERT INTO Imoveis (idDono, idAgencia, endereco, preco) VALUES (4, 4, 'Osasco', 250.0);

