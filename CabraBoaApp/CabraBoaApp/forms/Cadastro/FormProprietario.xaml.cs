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
        public FormProprietario()
        {
            InitializeComponent();
        }
        
        private void Salvar_Clicked(object sender, EventArgs e)
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

            DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}