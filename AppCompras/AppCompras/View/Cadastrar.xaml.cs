using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCompras.Model;

namespace AppCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Item P = new Item();
            P.Produto = txt_Produto.Text;
            P.Qtd = Convert.ToDouble(txt_Qntd.Text);
            P.PrecoUnt = Convert.ToDouble(txt_PrecoUnit.Text);
            P.Desc = txt_Desc.Text;

            await App.Database.Insert(P);

            await Navigation.PushAsync(new Listagem());
        }
    }
}