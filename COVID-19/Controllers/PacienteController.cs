using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using covid19.Models;
using covid19.Repositories;
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
        private readonly PacienteRepository paciente_repository;
        public PacienteController() 
        {
            paciente_repository = new PacienteRepository();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Litagem dos pacientes cadastrados.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            paciente_repository.BuscarPorId(id);
            return Ok("Dados do paciente.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
                paciente_repository.InserirPaciente(paciente);
                return Ok("Paciente cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Paciente paciente)
        {
            Paciente p = new Paciente();

            return Ok("Paciente atualizado.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok("Paciente deleteado.");
        }

    }
}
