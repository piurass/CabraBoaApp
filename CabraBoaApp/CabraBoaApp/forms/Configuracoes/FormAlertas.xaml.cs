using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabraBoaApp.dados;

namespace CabraBoaApp.forms.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormAlertas : ContentPage
    {
        public FormAlertas()
        {
            InitializeComponent();
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            var alertas = new Alertas
            {
                Habilitar = Habilitar.Text,
                Notificacoes = Notificacoes.Text,
                Visual = Visual.Text,
                Sonoro = Sonoro.Text,
                Email = Email.Text
            };

            bool ret = false;
            DbAlertas db = new DbAlertas();

            if (!db.CheckDb())
            {                
                await DisplayAlert("Database", "não existe!", "OK0");
            }

            await DisplayAlert("Database", db.GetPath(), "OK0");

            ret = db.Conectar();
            await DisplayAlert("Conectar", db.Erro, "OK1");
                  
            
            if (ret == true)
            {
                if(!db.CheckDb())
                {
                    ret = db.Criar();
                    await DisplayAlert("Criar", db.Erro, "OK2");
                }
            }                        

            if (ret==true)
            {
                ret = db.Gravar(alertas);
                await DisplayAlert("Gravar", db.Erro, "OK3");
            }
          
            if (ret==true)
            {
                await DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
            }
            else
            {
                await DisplayAlert("Salvar", "Erro na gravação dos dados!", "NOK");
            }
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}