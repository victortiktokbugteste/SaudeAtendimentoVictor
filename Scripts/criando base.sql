--create database SaudeAtendimentoVictor

--use SaudeAtendimentoVictor

DROP TABLE __EFMigrationsHistory;

drop table Triagem;
drop table Atendimento;
drop table Status;
drop table Especialidade;
drop table Paciente;


--agora s� ir no vs e rodar o update-database.

INSERT INTO Status values ('Leve')
INSERT INTO Status values ('Cr�tico')


INSERT INTO Especialidade VALUES ('Doen�as de gripe')
INSERT INTO Especialidade VALUES ('Dor de cabe�a')


