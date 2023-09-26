using System;
using Xamarin.Forms;

namespace ExemploXamarin
{
    public class App : Application
    {
        public App()
        {
            Button bt = new Button { Text = "Ir para a próxima página" };
            Entry en = new Entry { Placeholder = "Senha", IsPassword = true };

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
                        en, bt
                    }
                }
            };
            var navigation = new NavigationPage(scrollView);

            bt.Clicked += async delegate
            {
                if (en.Text != "minhaSenha123")
                    return;
                
                var nextPage = new ContentPage
                {
                    Content = new Label
                    {
                        Text = "Esta é a próxima página!",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                    }
                };
                await navigation.PushAsync(new NavigationPage(nextPage));
            };

            MainPage = navigation;
        }
    }
}