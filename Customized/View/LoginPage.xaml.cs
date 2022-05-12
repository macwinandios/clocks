using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Customized.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Logo.Source = ImageSource.FromResource("Customized.Images.Tiosq.png");
        }
    }
}
