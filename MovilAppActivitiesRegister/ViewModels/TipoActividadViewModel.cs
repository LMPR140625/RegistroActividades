using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Models;

namespace MovilAppActivitiesRegister.ViewModels
{
    public class TipoActividadViewModel
    {
        private SqliteHelper _db;
        private TipoActividadModel _tipoActividad;
        
        public Task<int> InsertTipoActividad(string tipoActividad, string descripcion)
        {
            _tipoActividad = new TipoActividadModel();
            _tipoActividad.tipoActividad  = tipoActividad;
            _tipoActividad.descripcion= descripcion;

            _db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3"));

            return _db.InsertTipoActividad(_tipoActividad);
        }
        public Task<List<TipoActividadModel>> GetAllTipoActividad()
        {
            _db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3"));
            return _db.GetAllTipoActividad();
        }
    }
}
