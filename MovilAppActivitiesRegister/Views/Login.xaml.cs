
using MovilAppActivitiesRegister.ViewModels;
using Newtonsoft.Json;

namespace MovilAppActivitiesRegister.Views;

public partial class Login : ContentPage
{
	private LoginViewModel viewModelLogin;
	public Login()
	{
		InitializeComponent();
	}

    private void btnLogin(object sender, EventArgs e)  //agregar el async
    {
		if (txtUser.Text != "" || txtPass.Text != "")
		{
            viewModelLogin = new LoginViewModel();
			bool access = false;
			if (txtUser.Text == "root")
			{
                access = viewModelLogin.AuthorizeUser(txtUser.Text, txtPass.Text).Result;
				if (access == false)
				{
					viewModelLogin.InsertUserRoot();
				}
            }
			else
			{
                access = viewModelLogin.AuthorizeUser(txtUser.Text, txtPass.Text).Result;
            }			

			if (access) {
                viewModelLogin.InsertLoginAttemp(txtUser.Text, true);
				//viewModelLogin.AnulateActivities();
                Navigation.PushAsync(new Home(txtUser.Text));
            } else
			{
                viewModelLogin.InsertLoginAttemp(txtUser.Text, false);
                DisplayAlert("Aviso", "Usuario y/o contraseña incorrectos !!!!", "Salir");
            }		
		}
		else
		{
			DisplayAlert("Aviso", "Ingresar usuario y/o contraseña !!!!", "Salir");
		}


    }
}