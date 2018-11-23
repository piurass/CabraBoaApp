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
                Habilitar.Text = alertas.Habilitar;
                Notificacoes.Text = alertas.Notificacoes;
                Visual.Text = alertas.Visual;
                Sonoro.Text = alertas.Sonoro;
                Email.Text = alertas.Email;
            }            
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            alertas = new Alertas
            {
                Habilitar = Habilitar.Text,
                Notificacoes = Notificacoes.Text,
                Visual = Visual.Text,
                Sonoro = Sonoro.Text,
                Email = Email.Text
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