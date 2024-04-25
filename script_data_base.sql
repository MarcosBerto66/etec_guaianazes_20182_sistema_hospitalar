CREATE DATABASE bdSistemaHospitalar

USE bdSistemaHospitalar
GO

CREATE TABLE tbPaciente (
	 idPaciente INT PRIMARY KEY IDENTITY(1,1)
	,nome VARCHAR(200)
	,cpf VARCHAR(200)
	,nasc VARCHAR(200)
	,rg VARCHAR(200)
	,logra VARCHAR(200)
	,cep VARCHAR(200)
	,n VARCHAR (200)
	,bairro VARCHAR(200)
	,cid VARCHAR(200)
	,est VARCHAR(200)
)

INSERT INTO tbPaciente(nome, cpf, nasc, rg, logra, cep, n, bairro, cid, est)
VALUES 
    ('João Silva', '123.456.789-00', '1990-05-15', '1234567', 'Rua das Flores', '12345-678', '100', 'Centro', 'São Paulo', 'SP'),
    ('Maria Santos', '987.654.321-00', '1985-10-20', '9876543', 'Avenida das Palmeiras', '54321-876', '200', 'Jardim Botânico', 'Rio de Janeiro', 'RJ'),
    ('José Oliveira', '456.789.123-00', '1978-03-25', '4567891', 'Rua dos Passarinhos', '98765-432', '300', 'Bela Vista', 'Curitiba', 'PR'),
    ('Ana Pereira', '654.321.987-00', '1995-12-10', '6543219', 'Alameda das Árvores', '13579-246', '400', 'Boa Viagem', 'Recife', 'PE'),
    ('Carlos Ferreira', '321.987.654-00', '1980-08-05', '3219876', 'Travessa das Pedras', '24680-135', '500', 'Copacabana', 'Rio de Janeiro', 'RJ');

CREATE TABLE tbTelefonePaciente (
 	 idTelefonePaciente INT PRIMARY KEY IDENTITY(1,1)
	,descricao VARCHAR(200)
	,idPaciente INT FOREIGN KEY
	REFERENCES tbPaciente (idPaciente)
)

CREATE TABLE tbEspecialidade (
	  idEspecialidade INT PRIMARY KEY IDENTITY(1,1)
	 ,descricao VARCHAR(100)
)

CREATE TABLE tbTipoInternacao (
	 idTipoInternacao INT PRIMARY KEY IDENTITY(1,1)
	,descricao VARCHAR(100)
)

CREATE TABLE tbUsuario (
	 idUsuario INT PRIMARY KEY IDENTITY(1,1)
	,loginUsuario VARCHAR(50)
	,senhaUsuario VARCHAR(50)
)

CREATE TABLE tbMedico (
	 idMedico INT PRIMARY KEY IDENTITY(1,1)
	,nomeMedico VARCHAR(50)
	,crmMedico VARCHAR(10)
	,idEspecialidadeMedico INT FOREIGN KEY	
	REFERENCES tbEspecialidade (idEspecialidade)
)
	
CREATE TABLE tbStatusConsulta(
	idStatusConsulta INT PRIMARY KEY IDENTITY(1,1)
	,descricaoStatusConsulta VARCHAR(150)
)
	
CREATE TABLE tbInternacao (
	 idInternacao INT PRIMARY KEY IDENTITY(1,1)
	,dataEntradaInternacao VARCHAR(12)
	,dataAltaInternacao VARCHAR(12)
	,resumoAlta VARCHAR(400)
	,idPaciente INT FOREIGN KEY 
	REFERENCES tbPaciente(idPaciente)
	,idTipoInternacao INT FOREIGN KEY 
	REFERENCES tbTipoInternacao(idTipoInternacao)
	,idMedico INT FOREIGN KEY 
	REFERENCES tbMedico (idMedico)
	,idUsuario INT FOREIGN KEY 
	REFERENCES tbUsuario (idUsuario)	
)

INSERT INTO tbUsuario (loginUsuario,senhaUsuario) VALUES ('adm','adm')

CREATE TABLE tbConsulta(
	idConsulta INT PRIMARY KEY IDENTITY(1,1)
	,dataConsulta VARCHAR(12) 
	,horaConsulta VARCHAR(5)
	,idPaciente INT FOREIGN KEY REFERENCES tbPaciente(idPaciente)
	,idMedico INT FOREIGN KEY REFERENCES tbMedico(idMedico)
	,idStatusConsulta INT FOREIGN KEY REFERENCES tbStatusConsulta(idStatusConsulta)
	,idUsuario INT FOREIGN KEY REFERENCES tbUsuario(idUsuario)
)

SELECT tbPaciente.nome, nomeMedico, descricaoStatusConsulta, dataConsulta, horaConsulta FROM tbConsulta
	INNER JOIN tbPaciente 
		ON tbConsulta.idPaciente = tbPaciente.idPaciente
			INNER JOIN tbMedico
				ON tbConsulta.idMedico = tbMedico.idMedico 
					INNER JOIN tbStatusConsulta
						ON tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta
						
SELECT dataConsulta, horaConsulta, nome, nomeMedico, descricaoStatusConsulta FROM tbConsulta
	INNER JOIN tbPaciente
		ON tbConsulta.idPaciente = tbPaciente.idPaciente
			INNER JOIN tbMedico
				ON tbConsulta.idMedico = tbMedico.idMedico
					INNER JOIN tbStatusConsulta
						ON tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta
