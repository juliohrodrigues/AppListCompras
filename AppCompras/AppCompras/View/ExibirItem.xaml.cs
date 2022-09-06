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
    public partial class ExibirItem : ContentPage
    {
        public ExibirItem()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Item o = new Item
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Produto = txt_produto.Text,
                PrecoUnt = Convert.ToDouble(txt_preco.Text),
                Qtd = Convert.ToDouble(txt_qntd.Text),
                Desc = txt_descricao.Text,
            };

            await App.Database.Update(o);

            await Navigation.PushAsync(new Listagem());
        }
    }
}