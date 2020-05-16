using System;
using System.Collections.Generic;
using LocalLib.Controls;
using LocalLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;

        public CidadeController(ILogger<EstadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public List<Cidade> Get(int id)
        {
            var cidades = new CidadeControl().ObterPorEstado(id);

            return cidades;
        }
    }
}
