using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.Tools;

namespace MovilAppActivitiesRegister.ViewModels
{
    public class RegistroViewModel
    {
        private SqliteHelper _db;
        private static int _duracionExtra = 5; //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3");
        private Activity _activity;
        //usuario, actividad, detalle/observacion, tipoActividad,horas,minutos
        public Task<int> InsertActividad(string usuario, string actividad
                                        , string detail, string tipoActividad
                                        , int horas, int minutos )
        {
            _activity= new Activity();
            _activity.Status = (int)EstatusActividad.EnProceso;
            _activity.FechaRegistro = DateTime.Now;
            _activity.DuracionHoras = horas;
            _activity.DuracionMinutos = minutos;
            _activity.Description = detail;
            _activity.Detail = detail;
            _activity.Usuario = usuario;
            _activity.Name = actividad;
            _activity.TypeActivity = tipoActividad;
            _activity.FechaINI = DateTime.Now;
            _activity.DuracionTiempoExtra= _duracionExtra;
            _activity.DuracionTotal = minutos + (horas * 60) + _activity.DuracionTiempoExtra;
            _activity.FechaFIN = DateTime.Now.AddMinutes(_activity.DuracionTotal);
            _activity.version = 1;

            _db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3"));
            return _db.InsertActivity(_activity);

        }
    }
}
