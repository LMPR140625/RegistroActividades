using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MovilAppActivitiesRegister.Models;
using MovilAppActivitiesRegister.Views;
using MovilAppActivitiesRegister.Tools;

namespace MovilAppActivitiesRegister.Data
{
    public class SqliteHelper
    {
        SQLiteAsyncConnection db;
        private readonly string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3");
        public SqliteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Activity>().Wait();
            db.CreateTableAsync<RegistroInicioSession>().Wait();
            db.CreateTableAsync<TipoActividadModel>().Wait();
            db.CreateTableAsync<Usuario>().Wait();
        }

        public SqliteHelper()
        {
            db = new SQLiteAsyncConnection(_path);
            db.CreateTableAsync<Activity>().Wait();
            db.CreateTableAsync<RegistroInicioSession>().Wait();
            db.CreateTableAsync<TipoActividadModel>().Wait();
            db.CreateTableAsync<Usuario>().Wait();
        }

        public Task<bool> ValidateUser(string user, string password)
        {  
            /* Realizar la validación del usuario dentro de la Tabla User*/
            var lstUser = db.Table<Usuario>().Where(u => u.NombreUsuario == user && u.Contraseña == password).ToListAsync(); // true = Validacion correcta , false = validacion incorrecta, con el password 
            bool result = false;
            //if (user == "" && password == "")
            if (lstUser.Result.Count > 0)
            {
                result = true;
            } else
            {
                result = false; 
            }

            //return Task.FromResult(result);
            return Task.FromResult(true);
        }
        public Task<int> InsertUsuario(Usuario user)
        {
            return db.InsertAsync(user);
        }

        public Task<int> InsertLoginAttemp(RegistroInicioSession loginAttemp)
        {
            if (loginAttemp.IdRegistro == 0)
            {
                return db.InsertAsync(loginAttemp);
            } else
            {
                return null;
            }
        }
        public Task<List<RegistroInicioSession>> GetAllLogins()
        {
            return db.Table<RegistroInicioSession>().ToListAsync();
        }

        public Task<int> InsertActivity(Activity activity)
        {
            if (activity.IdActivity == 0)
            {
                var res = db.InsertAsync(activity);
                return res;
            }
            else
            {
                return null;
            }
        }
        public Task<List<Activity>> GetAllActivities()
        {
            //db.DeleteAllAsync<Activity>();
            List<Activity> lst = db.Table<Activity>().ToListAsync().Result;
            return db.Table<Activity>().ToListAsync();
        }        

        public Task<int> InsertTipoActividad(TipoActividadModel tipoActividad)
        {
            if (tipoActividad.Id == 0)
            {
                return db.InsertAsync(tipoActividad);
            }
            else
            {
                return null;
            }
        } 
        public Task<List<TipoActividadModel>> GetAllTipoActividad()
        {
            return db.Table<TipoActividadModel>().ToListAsync();   
        }

        public Task<List<RegistroInicioSession>> GetTodayLogins()
        { 
            return db.Table<RegistroInicioSession>().Where(r => r.FechaRegistro.Date == DateTime.Now.Date).ToListAsync();
        }
        public Task<List<Activity>> GetTodayActivities()
        {
            List<Activity> lsrResult = db.Table<Activity>().Where(act => act.FechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString()).ToListAsync().Result;
            return Task.FromResult(lsrResult);
        }
        public Task<List<Activity>> GetTodayInProcessActivities()
        {
            List<Activity> lsrResult = db.Table<Activity>().Where(act => act.Status == (int)EstatusActividad.EnProceso).ToListAsync().Result;
            return Task.FromResult(lsrResult);
        }
        public Task<List<EstatusActividades>> GetTodayQtyEstatusActividades()
        {
            List<EstatusActividades> lstResult = new List<EstatusActividades>();
            try
            {
                var Result = db.Table<Activity>().ToListAsync().Result
                                                 .Where(acti => acti.FechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString())
                                                 .GroupBy(act => act.Status)
                                                 .Select(g => new { Estatus = g.Key, Cantidad = g.Count() });

                if (Result.Count() > 0)
                {
                    foreach (var item in Result)
                    {
                        EstatusActividades oEstatus = new EstatusActividades(item.Estatus, item.Cantidad);
                        lstResult.Add(oEstatus); 
                    }
                }
            }
            catch (SQLiteException ex)
            {
                ex.ToString();
            }
            
            return Task.FromResult(lstResult);
        }
        public void DeleteTables()
        {
            db.DeleteAllAsync<Usuario>().Wait();            
            db.DeleteAllAsync<Activity>().Wait();
            db.DeleteAllAsync<RegistroInicioSession>().Wait();
            db.DeleteAllAsync<TipoActividadModel>().Wait();

            Usuario user = new Usuario("root","Usuario Raiz","root","root","admin");
            db.InsertAsync(user);
        }
        public Task<int> UpdateAnulateActivity()
        {
            List<Activity> lstCurrentActivities = db.Table<Activity>().ToListAsync().Result;
            List<Activity> listaResultado = lstCurrentActivities.Where(act => act.Status == (int)EstatusActividad.EnProceso && act.FechaFIN < DateTime.Now).ToList();
            int result = 0;
            if (listaResultado.Count > 0 && listaResultado != null)
            {
                foreach (var item in listaResultado)
                {
                    item.IdActivity = item.IdActivity;
                    item.Status = (int)EstatusActividad.AnuladaPorTiempo;
                }
                result = db.UpdateAllAsync(listaResultado).GetAwaiter().GetResult();
            }            
            return Task.FromResult(result);
        }
        public Task<int> FinalizarActividad(Activity act)
        {
            return Task.FromResult(db.UpdateAsync(act).Result);
        }
        public Task<int> AnularActividad(Activity act)
        {
            return Task.FromResult(db.UpdateAsync(act).Result);
        }
    }    
}
