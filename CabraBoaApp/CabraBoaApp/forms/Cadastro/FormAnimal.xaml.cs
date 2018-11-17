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
	public partial class FormAnimal : ContentPage
	{
		public FormAnimal ()
		{
			InitializeComponent ();
		}

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var animal = new Animal
            {
                Nome = Nome.Text,
                Data_nascimento = Data_nascimento.Text,
                Peso = Peso.Text,
                Sexo = Sexo.Text,
                Pai = Pai.Text,
                Mae = Mae.Text,
                Data_morte = Data_morte.Text,
                Lote = Lote.Text,
                Chifre = Chifre.Text,
                Score = Score.Text,
                Cl = Cl.Text,
                Clo = Clo.Text
            };

            DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}