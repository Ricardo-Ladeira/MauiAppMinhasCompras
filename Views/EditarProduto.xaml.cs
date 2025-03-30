using MauiAppMinhasCompras.Models;
using SQLitePCL;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
{
                Produto produto_anexado = BindingContext as Produto;

                dtpk_compra.Date = produto_anexado.DataCadastro;
}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

			Produto p = new Produto
			{
				Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text),
				DataCadastro = dtpk_compra.Date,	
			};

            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}