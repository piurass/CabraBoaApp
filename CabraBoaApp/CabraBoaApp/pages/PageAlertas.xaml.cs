﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CabraBoaApp.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAlertas : ContentPage
	{
		public PageAlertas ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}