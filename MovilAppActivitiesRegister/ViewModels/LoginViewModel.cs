using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovilAppActivitiesRegister.Data;
using MovilAppActivitiesRegister.Models;

namespace MovilAppActivitiesRegister.ViewModels
{
    public class LoginViewModel
    {
       // public string usuario { get; set; }
        //public string pass { get; set; }

        private SqliteHelper db;        
        private RegistroInicioSession loginAttemp;

        public Task<bool> AuthorizeUser(string User, string Password)
        {
            db = new SqliteHelper();
            return db.ValidateUser(User, Password);
        }

        public Task<int> InsertLoginAttemp(string User, bool Estatus)
        {
            loginAttemp = new RegistroInicioSession();
            loginAttemp.estatusAttemp = Estatus;
            loginAttemp.Usuario = User;
            loginAttemp.FechaRegistro = DateTime.Now;

            db = new SqliteHelper();
            return  db.InsertLoginAttemp(loginAttemp);
            
        }
        public Task<int> AnulateActivities()
        {
            db = new SqliteHelper();
            int result = db.UpdateAnulateActivity().Result;
            return Task.FromResult(result);
        }
        public Task InsertUserRoot() 
        {
            db = new SqliteHelper();
            return db.InsertUsuario(new Usuario("root","Usuario Raiz","root","root","admin"));
        }
        /* Buscar todas las actividades*/




    }
}
