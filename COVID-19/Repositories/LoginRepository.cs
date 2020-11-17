using covid19.Context;
using covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private Covid19Context covid19context;
        public LoginRepository()
        {
            covid19context = new Covid19Context();
        }
        public Login GetLogin(Login login)
        {
            var resultado = 
            covid19context.LOGINS.Where(l => l.usuario == login.usuario && l.senha == login.senha).FirstOrDefault();

            if (resultado != null)
            {
                login.id = resultado.id;
                login.grupo = resultado.grupo;
                return login;
            }
            return null;
        }

    }
}
