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
        private Lote lote;
        private SQLiteDb db;

        public FormLote ()
		{
			InitializeComponent ();

            db = new SQLiteDb();
            lote = db.LeDados<Lote>();

            if (lote != null)
            {
                Nome.Text = lote.Nome;
                Inseminacao.Text = lote.Inseminacao;
                Dieta.Text = lote.Dieta;
                Infraestrutura.Text = lote.Infraestrutura;
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            var lote = new Lote
            {
                Nome=Nome.Text,
                Inseminacao= Inseminacao.Text,
                Dieta= Dieta.Text,
                Infraestrutura= Infraestrutura.Text
            };

            bool ret = db.GravaDados(lote);

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