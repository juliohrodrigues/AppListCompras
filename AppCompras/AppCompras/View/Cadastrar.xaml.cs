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
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Item P = new Item();
            P.Produto = txt_Produto.Text;
            P.Quantidade = Convert.ToDouble(txt_Qntd.Text);
            P.PrecoUnitario = Convert.ToDouble(txt_PrecoUnit.Text);
            P.Descricao = txt_Desc.Text;

            await App.Database.Insert(P);

            await Navigation.PushAsync(new Listagem());
        }
    }
}