using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Graphics;
using MovilAppActivitiesRegister.Data;
using System.Drawing;

namespace MovilAppActivitiesRegister.Views;

public partial class Home : ContentPage
{
    private SqliteHelper _db;
    private string user;

    
    public Home(string usuario)
	{
        user = usuario;
		InitializeComponent();
	}   

    public void btnRegister(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Registro(user));
	}
    public void btnReports(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Reportes());
    }
    public void btnActivity(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoActividad(user));
    }
    public void btnActividadesEnProceso(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActividadesEnProceso());
    }
    public void btnNuevosUsuarios(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NuevoUsuario(user));
    }
    public void BtnProbando(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Prueba());
    }
    public void btnReloj(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Reloj());
    }
    public void btnListtaUser(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaUsuarios());
    }
   
    public void btnExit(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }

    private void btnReinicioTablas_Clicked(object sender, EventArgs e)
    {
        _db = new SqliteHelper();
        _db.DeleteTables();
        DisplayAlert("Aviso!","Data Eliminada","Salir");
    }
}