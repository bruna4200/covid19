using covid19.Models;
using covid19.Services.Interfaces;
using Fluent.Infrastructure.FluentContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Services.Interfaces
{
    public interface IPacienteService : IServiceBase<Paciente>
    {
    }
}
