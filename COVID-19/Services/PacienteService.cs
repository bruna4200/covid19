using covid19.Models;
using covid19.Repositories;
using covid19.Repositories.Interfaces;
using covid19.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Services
{
    public class PacienteService : lPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(
            IPacienteRepository pacienteRepository
        )
        {
            _pacienteRepository = pacienteRepository;
        }

        public void Create(Paciente ent)
        {
            _pacienteRepository.Create(ent);
        }

        public void Delete(int id)
        {
            _pacienteRepository.Delete(id);
        }

        public IEnumerable<Paciente> BuscarTodos()
        {
            return _pacienteRepository.BuscarTodos();
        }

        public Paciente BuscarPacienteUnico(int id)
        {
            return _pacienteRepository.BuscarPacienteUnico(id);
        }

        public Paciente Update(Paciente ent)
        {
            return _pacienteRepository.Update(ent);
        }
    }
}
