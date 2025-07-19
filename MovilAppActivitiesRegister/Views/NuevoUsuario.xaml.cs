using MovilAppActivitiesRegister.ViewModels;

namespace MovilAppActivitiesRegister.Views;

public partial class NuevoUsuario : ContentPage
{
    private readonly string user;
	private NuevoUsuarioViewModel _nvoUsr;
	public NuevoUsuario(string User)
	{
        user = User;
		InitializeComponent();
	}

    private void btnRegistrarNewUser_Clicked(object sender, EventArgs e)
    {
		_nvoUsr= new NuevoUsuarioViewModel();
        int result = _nvoUsr.InsertNuevoUsuario(txtNom.Text,txtRegisPass.Text,txtApellidoUser.Text, txtApellidomaternoUser.Text,txtNomUser.Text).Result;

        if (result == 0)
        {
            DisplayAlert("Eror", "ERRRRRRRRROOOOOOOOOOOOORRRRRRRR", "Salir");
        }
        else
        {
            DisplayAlert("Aviso", "Nuevo Usuario registrado", "Salir");
            Navigation.PushAsync(new Home(user));
        }
    }
}