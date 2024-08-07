<<<<<<< HEAD
PDI(bancoframework.console) - c#

#Script BD

CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    Nome VARCHAR(100),
    CPF VARCHAR(11) NOT NULL,
	Saldo DECIMAL(18, 2) NOT NULL
);

INSERT INTO Cliente (Id, Nome, CPF, Saldo) VALUES (1, 'Alice', 46802686031, 12345.67);
INSERT INTO Cliente (Id, Nome, CPF, Saldo) VALUES (2, 'Bob', 85726487044, 98765.43);

-- ATUALIZAR SALDO
UPDATE Cliente
SET Saldo = @saldo
WHERE Id = @identificador

-- OBTER CLIENTE POR ID
SELECT 
	Id,
	Nome,
	CPF,
	Saldo 
FROM Cliente
WHERE Id = @identificador

-- INSERIR CLIENTE
INSERT INTO Cliente
           (Id
           ,Nome
           ,CPF
           ,Saldo)
     VALUES
           (@identificador
           ,@nome
           ,@cpf
           ,@saldo)
=======
# Projeto base para Calculadora.Console

**Calculadora.Console** é um modelo inicial para o segundo projeto PDI jr.

## Criando um projeto baseado no Calculadora.Console

A forma mais simples de criar um projeto baseado no **Calculadora.Console** é obtendo o mesmo em seu diretorio.

Bons estudos!

>>>>>>> external/main
