using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.Tools;
using MovilAppActivitiesRegister.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.ViewModels
{
    public class ActividadesEnProcesoViewModel
    {
        private SqliteHelper db;
        public string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3");

        public dynamic GetInProcessActivities()
        {
            db = new SqliteHelper(_path);
            return db.GetTodayInProcessActivities().Result;           
        }
        public Task<List<EstatusActividades>> findQtyEstatusActividades()
        {
            db = new SqliteHelper(_path);
            Task<List<EstatusActividades>> resultEstatusActividades = db.GetTodayQtyEstatusActividades();

            return resultEstatusActividades;
        }
        public Task<int> FinalizarActividad(object item)
        {
            Activity activity = JsonConvert.DeserializeObject<Activity>(JsonConvert.SerializeObject(item));
            activity.Status = (int)EstatusActividad.Finalizada;
            db = new SqliteHelper(_path);
            var res = db.FinalizarActividad(activity);
            return Task.FromResult(res.Result);
        }
        public Task<int> AnularActividad(object item)
        {
            Activity activity = JsonConvert.DeserializeObject<Activity>(JsonConvert.SerializeObject(item));
            activity.Status = (int)EstatusActividad.AnuladaPorUsuario;
            db = new SqliteHelper(_path);
            var res = db.AnularActividad(activity);
            return Task.FromResult(res.Result);
        }


    }
}
