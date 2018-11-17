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
	public partial class FormUsuario : ContentPage
	{
		public FormUsuario ()
		{
			InitializeComponent ();
		}

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {

                Nome = Nome.Text,
                Data_nascimento = Data_nascimento.Text,
                Sexo = Sexo.Text,
                Foto = Foto.Text,
                Cargo = Cargo.Text,
                Senha = Senha.Text,
                Email = Email.Text,
                Celular = Celular.Text
            };

            var senha2 = Senha2.Text;

            if( string.IsNullOrEmpty(usuario.Senha))
            {
                await DisplayAlert("Salvar", "Senha Não pode ser Vazia!", "OK");
            }
            else if(senha2 == usuario.Senha)
            {
                await DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
            }            
            else      
            {
                await DisplayAlert("Salvar", "Senhas não batem! Favor corrigir", "Cancelar");
            }            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}