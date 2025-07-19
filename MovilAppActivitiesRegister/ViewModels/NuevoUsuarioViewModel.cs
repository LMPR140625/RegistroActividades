using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.ViewModels
{
    public class NuevoUsuarioViewModel
    {
        private SqliteHelper db;
        private readonly string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.db3");
        private Usuario nuevoUsuario;

        public Task<int> InsertNuevoUsuario(string nombre, string contraseña, string apellidPaterno, string apellidoMaterno,string nombreUsuario)
        {
            nuevoUsuario = new Usuario(nombreUsuario, nombre,apellidPaterno, apellidoMaterno, contraseña);
            db = new SqliteHelper(_path);
            return db.InsertUsuario(nuevoUsuario);
        }
    }
}
