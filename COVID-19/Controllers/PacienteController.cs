using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using covid19.Models;
using covid19.Repositories;
using covid19.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace covid19.Controllers
{
    [Authorize(Roles = "administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(
            IPacienteService pacienteService
        )
        {
            _pacienteService = pacienteService;
        }
        private readonly PacienteRepository pacienteRepository;

        public PacienteController()
        {
           pacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = _pacienteService.BuscarTodos();
            return Ok(pacientes);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = _pacienteService.BuscarPacienteUnico(id);
            return Ok(paciente);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
            _pacienteService.Create(paciente);

            return Ok("Dado cadastrado ");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Paciente paciente)
        {
            _pacienteService.Update(paciente);

            return Ok("Dado atualizado");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _pacienteService.Delete(id);
            return Ok("Dado deletado");
        }

    }
}
