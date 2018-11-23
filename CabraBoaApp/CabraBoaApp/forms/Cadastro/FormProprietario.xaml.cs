using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabraBoaApp.dados;

namespace CabraBoaApp.forms.Cadastro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormProprietario : ContentPage
    {
        private Proprietario proprietario;
        private SQLiteDb db;

        public FormProprietario()
        {
            InitializeComponent();

            db = new SQLiteDb();
            proprietario = db.LeDados<Proprietario>();

            if (proprietario != null)
            {
                Nome.Text = proprietario.Nome;
                Endereço.Text = proprietario.Endereço;
                Cidade.Text = proprietario.Cidade;
                UF.Text = proprietario.UF;
                CEP.Text = proprietario.Cep;
                Localização.Text = proprietario.Localizacao;
            }
        }
        
        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            var proprietario = new Proprietario
            {
                Nome        = Nome.Text,
                Endereço    = Endereço.Text,
                Cidade      = Cidade.Text,
                UF          = UF.Text,
                Cep         = CEP.Text,
                Localizacao = Localização.Text
            };

            bool ret = db.GravaDados(proprietario);

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