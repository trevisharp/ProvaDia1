8CREATE TRIGGER limpaServer ON Servidores
AFTER DELETE AS
BEGIN
	DECLARE @AnexCount INT;
	DECLARE @MesaCount INT;
	DECLARE @PartCount INT;
	DECLARE @Name VARCHAR(200);
	DECLARE @Cmd VARCHAR(2000);

	DELETE FROM MensagemAnexo
	WHERE IdMensagem IN (
	  SELECT Id
	  FROM Mensagem
	  WHERE IdServidor IN (SELECT Id FROM deleted)
	);
	SET @AnexCount = @@ROWCOUNT;
	
	DELETE FROM Mensagens WHERE IdServidor IN (SELECT Id FROM deleted);
	SET @MesaCount = @@ROWCOUNT;
	
	DELETE FROM ParticipantesServidor WHERE IdServidor = old.Id;
	SET @PartCount = @@ROWCOUNT;
	
	SELECT TOP 1 @Name = Nome
	FROM deleted
	
	SET @Cmd = 'Echo "' +
		CONVERT(VARCHAR(200), GETDATE()) + " - " + 
		@Name + " - " +
		@PartCount + " - " +
		@MesaCount + " - " +
		@AnexCount +
		'" >> C:\Users\Public\Documents\historico.txt"';
	
	EXEC xp_cmdshell @Cmd;
END