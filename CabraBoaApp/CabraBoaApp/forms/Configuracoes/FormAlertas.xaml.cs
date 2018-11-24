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
        private Alertas alertas;
        private SQLiteDb db; 

        public FormAlertas()
        {
            InitializeComponent();

            db = new SQLiteDb();
            alertas =db.LeDados<Alertas>();     

            if(alertas!=null)
            {
                Habilitar.IsToggled = alertas.Habilitar;
                Notificacoes.IsToggled = alertas.Notificacoes;
                Visual.IsToggled = alertas.Visual;
                Sonoro.IsToggled = alertas.Sonoro;
                Email.IsToggled = alertas.Email;
            }            
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            alertas = new Alertas
            {
                Habilitar = Habilitar.IsToggled,
                Notificacoes = Notificacoes.IsToggled,
                Visual = Visual.IsToggled,
                Sonoro = Sonoro.IsToggled,
                Email = Email.IsToggled
            };

            bool ret = db.GravaDados(alertas);

            if (ret == true)
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