using covid19.Context;
using covid19.Models;
using covid19.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public class PacienteRepository : IPaciente
    {
        private Covid19Context Covid19Context;

        public PacienteRepository()
        {
            Covid19Context = new Covid19Context();
        }
        public IList<Paciente> BuscarPacienteCidade(string cidade)
        {
            return (IList<Paciente>)Covid19Context.PACIENTES.Where(p => p.cidade == cidade);
        }
        public Paciente BuscarPacienteCPF(string cpf)
        {
            return Covid19Context.PACIENTES.Where(p => p.cpf == cpf).FirstOrDefault();
        }
        public Paciente BuscarPorId(int id)
        {
            return Covid19Context.PACIENTES.Where(p => p.id == id).FirstOrDefault();
        }
        public void InserirPaciente(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
            {
                Covid19Context.PACIENTES.Add(paciente);
            }
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }
        public IList<Paciente> ListarTodosPacientes()
        {
            return (IList<Paciente>)Covid19Context.PACIENTES;
        }

    }

}
