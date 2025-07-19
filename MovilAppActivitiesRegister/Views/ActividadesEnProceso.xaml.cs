
using Microsoft.Maui.Controls;
using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.ViewModels;
using System.Linq;

namespace MovilAppActivitiesRegister.Views;

public partial class ActividadesEnProceso : ContentPage
{    
	private ActividadesEnProcesoViewModel viewModelActividadesEnProceso;
	public ActividadesEnProceso()
	{
        InitializeComponent();        
        viewActividadesEnProceso.ItemsSource = GetInProcessActivities();
	}

    private void btnFinzalizarActividadEnProceso_Clicked(object sender, EventArgs e)
    {
        //Funcion para mandar finalizar
        viewModelActividadesEnProceso = new ActividadesEnProcesoViewModel();
        if (viewActividadesEnProceso.SelectedItem == null)
        {
            DisplayAlert("Mensaje","Seleccionar una actividad a finalizar","Salir");
        } else
        {
            viewModelActividadesEnProceso.FinalizarActividad(viewActividadesEnProceso.SelectedItem);
        }
        
        //Carga de las actividades despues de finalizar
        viewActividadesEnProceso.ItemsSource = GetInProcessActivities();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        List<Activity> activities = GetInProcessActivities();
        List<Activity> actSearchBar = activities.Where(a => a.Name.Contains(srchBar.Text.ToUpper())).ToList();   

        viewActividadesEnProceso.ItemsSource = actSearchBar;
    }

    private void btnEditarActividadEnProceso_Clicked(object sender, EventArgs e)
    {
        //Funcion para mandar editar
        viewModelActividadesEnProceso = new ActividadesEnProcesoViewModel();
        if (viewActividadesEnProceso.SelectedItem == null)
        {
            DisplayAlert("Mensaje", "Seleccionar una actividad a finalizar", "Salir");
        }
        else
        {
            //viewModelActividadesEnProceso.EditarActividad(viewActividadesEnProceso.SelectedItem);
        }
        
        //Carga de las actividades despues de editar
        viewActividadesEnProceso.ItemsSource = GetInProcessActivities();
    }

    private void btnAnularActividadEnProceso_Clicked(object sender, EventArgs e)
    {
        //Funcion para mandar anular
        viewModelActividadesEnProceso = new ActividadesEnProcesoViewModel();
        if (viewActividadesEnProceso.SelectedItem == null)
        {
            DisplayAlert("Mensaje", "Seleccionar una actividad a finalizar", "Salir");
        }
        else
        {
            viewModelActividadesEnProceso.AnularActividad(viewActividadesEnProceso.SelectedItem);
        }        
        //Carga de las actividades despues de anular
        viewActividadesEnProceso.ItemsSource = GetInProcessActivities(); 
    }

    public List<Activity> GetInProcessActivities()
    {
        viewModelActividadesEnProceso = new ActividadesEnProcesoViewModel();
        return viewModelActividadesEnProceso.GetInProcessActivities();
    }

}