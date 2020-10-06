using COVID_19.Repositories;
using covid19.Models;
using covid19.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private IList<Paciente> listaPaciente = new List<Paciente>();
        public PacienteRepository()
        {
            listaPaciente.Add(new Paciente() { id = 1, cidade = "Bruna" });
            listaPaciente.Add(new Paciente() { id = 2, cidade = "Paulo" });
            listaPaciente.Add(new Paciente() { id = 3, cidade = "Karla" });
            listaPaciente.Add(new Paciente() { id = 4, cidade = "Jason" });
        }
        public Paciente BuscarPacientePorId(int pid)
        {
            return listaPaciente.Where(x => x.id == pid).FirstOrDefault();
        }

        public void InserirPaciente(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
                listaPaciente.Add(paciente);
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }

        public IList<Paciente> ListarTodosPacientes()
        {
            return listaPaciente;
        }
    }
}
