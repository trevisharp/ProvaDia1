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


using System;
using Xamarin.Forms;

namespace ExemploXamarin
{
    public class App : Application
    {
        public App()
        {
            // Página principal com ScrollView
            var scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(20),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Children =
                    {
                        new Entry { Placeholder = "Nome" },
                        new Entry { Placeholder = "Email" },
                        new Entry { Placeholder = "Senha", IsPassword = true },
                        new Button
                        {
                            Text = "Ir para a próxima página",
                            Command = new Command(() =>
                            {
                                // Navegação para outra página
                                var nextPage = new ContentPage
                                {
                                    Content = new Label
                                    {
                                        Text = "Esta é a próxima página!",
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        VerticalOptions = LayoutOptions.CenterAndExpand,
                                    }
                                };
                                NavigationPage.SetBackButtonTitle(nextPage, "Voltar");
                                NavigationPage.SetHasBackButton(nextPage, true);
                                NavigationPage.SetBackButtonTitle(this, "Voltar");
                                NavigationPage.SetHasBackButton(this, true);

                                Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(nextPage));
                            })
                        }
                    }
                }
            };

            // Navigation Page
            MainPage = new NavigationPage(scrollView);
        }
    }
}