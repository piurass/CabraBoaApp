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
        private Usuario usuario;
        private SQLiteDb db;

        public FormUsuario()
        {
            InitializeComponent();

            db = new SQLiteDb();
            usuario = db.LeDados<Usuario>();

            if (usuario != null)
            {
                Nome.Text = usuario.Nome;
                Data_nascimento.Text = usuario.Data_nascimento;
                Sexo.Text = usuario.Sexo;
                Foto.Text = usuario.Foto;
                Cargo.Text = usuario.Cargo;
                Senha.Text = usuario.Senha;
                Email.Text = usuario.Email;
                Celular.Text = usuario.Celular;
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            usuario = new Usuario
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
                bool ret = db.GravaDados(usuario);

                if (ret == true)
                {
                    await DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
                }
                else
                {
                    await DisplayAlert("Salvar", "Erro na gravação dos dados!", "NOK");
                }
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