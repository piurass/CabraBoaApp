﻿using System;
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
		public FormAlertas ()
		{
			InitializeComponent ();
		}

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var alertas = new Alertas
            {
                Habilitar       =  Habilitar.Text,
                Notificacoes    =  Notificacoes.Text,
                Visual          =  Visual.Text,
                Sonoro          =  Sonoro.Text,
                Email           =  Email.Text               
            };

            DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}