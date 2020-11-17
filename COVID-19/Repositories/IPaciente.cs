using covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public interface IPaciente
    {
        public Paciente BuscarPorId(int id);
        public IList<Paciente> BuscarPacienteCidade(string cidade);
        public Paciente BuscarPacienteCPF(string cpf);
        public void InserirPaciente(Paciente paciente);
        public IList<Paciente> ListarTodosPacientes();
    }
}
