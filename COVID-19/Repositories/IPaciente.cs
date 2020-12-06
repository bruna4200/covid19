using covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public interface IPacienteRepository
    {
        public Paciente buscaPorId(int id);
        public IList<Paciente> buscaTodosPacientes();
        public void novoPaciente(Paciente paciente);
    }
}
