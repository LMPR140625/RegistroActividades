using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Views;

namespace MovilAppActivitiesRegister;

public partial class App : Application
{
	static SqliteHelper db;
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Login());
	}
	public static SqliteHelper SliteDB {
		get 
		{
			if (db == null)
			{
				db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Activities.db3"));
			}
			return db;
		}
	}
}
