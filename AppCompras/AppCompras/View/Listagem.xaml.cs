using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using AppCompras.Model;

namespace AppCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        ObservableCollection<Item> P = new ObservableCollection<Item>();
        public Listagem()
        {
            InitializeComponent();

            lista_items.ItemsSource = P;
        }

        private void atualizando_Refreshing(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Item> temp = await App.Database.GetAllRows();

                P.Clear();

                foreach (Item item in temp)
                {
                    P.Add(item);
                }

                atualizando.IsRefreshing = false;
            });
        }

        protected override void OnAppearing()
        {
            if (P.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Item> temp = await App.Database.GetAllRows();

                    foreach (Item item in temp)
                    {
                        P.Add(item);
                    }

                    atualizando.IsRefreshing = false;
                });

                lista_items.ItemsSource = P;
            }
        }

        private async void lista_items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item item_selecionado = (Item)e.SelectedItem;

            Navigation.PushAsync(new Listagem
            {
                BindingContext = item_selecionado
            });

            await Navigation.PushAsync(new ExibirItem());
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastrar());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busca = e.NewTextValue;

            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Item> temp = await App.Database.Search(busca);

                P.Clear();

                foreach (Item item in temp)
                {
                    P.Add(item);
                }

                atualizando.IsRefreshing = false;
            });
        }
    }
}