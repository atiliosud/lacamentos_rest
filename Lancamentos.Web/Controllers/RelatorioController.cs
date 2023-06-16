using System.Net;
using Lancamentos.Business.Contracts.Services;
using Lancamentos.Web.Helpers;
using Lancamentos.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lancamentos.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {

        private readonly ICaixaService _caixaService;
        private readonly ILogger<RelatorioController> _logger;

        public RelatorioController(ILogger<RelatorioController> logger,
            ICaixaService caixaService
            )
        {
            _logger = logger;
            _caixaService = caixaService;
        }

        [HttpGet(Name = "Diario")]
        public IActionResult Diario(DateTimeOffset data)
        {
            var caixa = _caixaService.PegarFluxoCaixaPorDia(data, User.GetUserId());

            var viewModel = FluxoCaixaVM.MapperToVM(caixa);
            return Ok(viewModel);
        }


    }
}