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
        public Login GetLogin(Login login)
        {
            if (login.usuario == "Bru" && login.senha == "00102030")
            {
                login.id = 1;
                login.grupo = "adm";
                return login;
            }
            return null;
        }

    }
}
