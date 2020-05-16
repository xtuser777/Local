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
    public class EstadoController : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;

        public EstadoController(ILogger<EstadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Estado> Get()
        {
            var estados = new EstadoControl().ObterTudo();

            return estados;
        }
    }
}
