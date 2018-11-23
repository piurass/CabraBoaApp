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
        private Animal animal;
        private SQLiteDb db;

        public FormAnimal()
        {
            InitializeComponent();

            db = new SQLiteDb();
            animal = db.LeDados<Animal>();

            if (animal != null)
            {
                Nome.Text = animal.Nome;
                Data_nascimento.Text = animal.Data_nascimento;
                Peso.Text = animal.Peso;
                Sexo.Text = animal.Sexo;
                Pai.Text = animal.Pai;
                Mae.Text = animal.Mae;
                Data_morte.Text = animal.Data_morte;
                Lote.Text = animal.Lote;
                Chifre.Text = animal.Chifre;
                Score.Text = animal.Score;
                Cl.Text = animal.Cl;
                Clo.Text = animal.Clo;
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
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

            bool ret = db.GravaDados(animal);

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