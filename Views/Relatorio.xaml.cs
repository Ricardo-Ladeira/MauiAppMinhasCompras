using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    public Relatorio()
    {
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
        {
        try
        {
            lista.Clear();
            var inicio = date_start.Date;
            var fim = date_end.Date;
            if (inicio > fim)
            {
                fim = inicio;
                date_end.Date = inicio;
            }
            List<Produto> tmp = await App.Db.GetAll();
            foreach (var produto in tmp){
                if (produto.DataCadastro.Date >= inicio && produto.DataCadastro.Date <= fim)
                {
                    lista.Add(produto);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
        }
    
}