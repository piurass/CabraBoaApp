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
	public partial class FormLote : ContentPage
	{
		public FormLote ()
		{
			InitializeComponent ();
		}

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var lote = new Lote
            {
                Nome=Nome.Text,
                Inseminacao= Inseminacao.Text,
                Dieta= Dieta.Text,
                Infraestrutura= Infraestrutura.Text
            };

            DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}