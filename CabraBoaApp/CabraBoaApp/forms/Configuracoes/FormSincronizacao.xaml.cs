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
	public partial class FormSincronizacao : ContentPage
	{
        private Sincronizacao sincronizacao;
        private SQLiteDb db;

        public FormSincronizacao()
        {
            InitializeComponent();

            db = new SQLiteDb();
            sincronizacao = db.LeDados<Sincronizacao>();

            if (sincronizacao != null)
            {
                url.Text = sincronizacao.url;
                endpoint.Text = sincronizacao.endpoint;
                acesso.Text = sincronizacao.acesso;
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            sincronizacao = new Sincronizacao
            {
                url = url.Text,
                endpoint = endpoint.Text,
                acesso = acesso.Text
            };

            bool ret = db.GravaDados(sincronizacao);

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