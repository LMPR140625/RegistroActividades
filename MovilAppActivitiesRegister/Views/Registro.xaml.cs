using CommunityToolkit.Maui.Alerts;
using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.ViewModels;

namespace MovilAppActivitiesRegister.Views;

public partial class Registro : ContentPage
{
	private string user;
	private RegistroViewModel _registro;
	private TipoActividadViewModel _tipoActividad;
	public Registro(string usuario)
	{
		this.user = usuario;
		InitializeComponent();
		List<int> lstHoras = new List<int>{ 0, 1, 2 ,3 ,4 , 5 ,6 ,7 ,8};
        List<int> lstMinutos = new List<int> {0,5,10,15,20,25,30,35,40,45,50,55};
        pkrHora.ItemsSource = lstHoras;
		pkrMinutos.ItemsSource = lstMinutos;

		_tipoActividad = new TipoActividadViewModel();		
		pkrTipoActividad.ItemsSource = _tipoActividad.GetAllTipoActividad().Result;
		
    }

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
		int min = Convert.ToInt32(pkrMinutos.Items[pkrMinutos.SelectedIndex]);
		int minHoras = Convert.ToInt32(pkrHora.Items[pkrHora.SelectedIndex]) * 60;

		
        if (txtAct.Text != "" || txtObs.Text !="" 
			|| pkrTipoActividad.SelectedIndex.ToString() != "-1"
			|| pkrMinutos.SelectedIndex >= 0 || pkrHora.SelectedIndex >= 0)
		{
			_registro = new RegistroViewModel();
			_registro.InsertActividad(user
									 ,txtAct.Text.ToUpper()
									 ,txtObs.Text
									 ,pkrTipoActividad.Items[pkrTipoActividad.SelectedIndex]
									 ,Convert.ToInt32(pkrHora.Items[pkrHora.SelectedIndex])
                                     ,Convert.ToInt32(pkrMinutos.Items[pkrMinutos.SelectedIndex]));//usuario, actividad, detalle/observacion, tipoActividad,horas,minutos
            RunSnackBar(3).Wait();
            Navigation.PushAsync(new Home(user));
            DisplayAlert("Exito","Validacion correcta","Salir");
		} else
		{
            DisplayAlert("Error", "Validacion incorrecta", "Salir");
        }
    }

    public async Task RunSnackBar(int minutosTotales)
    {
        var snackBar = Snackbar.Make("Actividad en Proceso", () => DisplayAlert("Mensaje", "Actividad Registrada", "Cerrar", "Finalizar"), "",
                TimeSpan.FromSeconds(minutosTotales), new CommunityToolkit.Maui.Core.SnackbarOptions
                {
                    BackgroundColor = Colors.SeaGreen,
                    TextColor = Colors.White
                });
        await snackBar.Show();

        if (snackBar.Show().IsCanceled)
        {
            await DisplayAlert("Aviso", "El mensaje fue cancelado", "Cerrar");
        }
    }
}