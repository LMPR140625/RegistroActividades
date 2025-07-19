using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.ViewModels;
using System.Linq;

namespace MovilAppActivitiesRegister.Views;
public partial class TipoActividad : ContentPage
{
	private readonly string user;
	private TipoActividadViewModel _viewModel;
	public TipoActividad(string User)
	{
		user = User;
		InitializeComponent();
		ActiveControls();
	}

    private void btnRegistrarNuevaActividad_Clicked(object sender, EventArgs e)
    {
		if (txtTipo.Text != "" && txtDescri.Text != "")
		{
			_viewModel = new TipoActividadViewModel();
			int result = _viewModel.InsertTipoActividad(txtTipo.Text.ToUpper(), txtDescri.Text).Result;
			if(result == 0 )
			{
				DisplayAlert("Eror", "ERRRRRRRRROOOOOOOOOOOOORRRRRRRR", "Salir");
			}
			else
			{
                DisplayAlert("Aviso", "Nuevo Tipo Actividad", "Salir");
                Navigation.PushAsync(new Home(user));
			}

		} else
		{
			DisplayAlert("Alerta", "Ingresar tipo de actividad y una breve descripción", "Salir");
		}
    }
	public void ActiveControls()
	{
		_viewModel = new TipoActividadViewModel();
		viewTipoActividad.ItemsSource = _viewModel.GetAllTipoActividad().Result;
	}

    private void txtTipo_TextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel = new TipoActividadViewModel();
        List<TipoActividadModel> lstTipoActividad = _viewModel.GetAllTipoActividad().Result;
		List<TipoActividadModel> lstTextChaged = lstTipoActividad.Where(x => x.tipoActividad.Contains(txtTipo.Text.ToUpper())).ToList();
        viewTipoActividad.ItemsSource = lstTextChaged;
    }
}