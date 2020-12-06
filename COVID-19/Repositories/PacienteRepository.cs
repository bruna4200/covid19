using covid19.Context;
using covid19.Models;
using covid19.Validations;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private IList<Paciente> pacientesLista;

        public PacienteRepository()
        {
            pacientesLista = new List<Paciente>();
        }

        public void novoPaciente(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
            {
                pacientesLista.Add(paciente);
            }
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }

        public void Delete(int id)
        {
            var ent = buscaPorId(id);
            pacientesLista.Remove(ent);
        }

        IList<Paciente> IPacienteRepository.buscaTodosPacientes()
        {
            return pacientesLista;
        }

        public Paciente buscaPorId(int id)
        {
            return pacientesLista.FirstOrDefault(paciente => paciente.id == id);
        }

        public Paciente Update(Paciente ent)
        {
            var salvo = buscaPorId(ent.id);
            pacientesLista.Remove(salvo);
            pacientesLista.Add(ent);
            return ent;
        }
    }

}
