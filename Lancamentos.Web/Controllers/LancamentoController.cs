using System.Net;
using Lancamentos.Business.Contracts.Services;
using Lancamentos.Web.Helpers;
using Lancamentos.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lancamentos.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {

        private readonly ICaixaService _caixaService;
        private readonly ILogger<LancamentoController> _logger;

        public LancamentoController(ILogger<LancamentoController> logger,
            ICaixaService caixaService
            )
        {
            _logger = logger;
            _caixaService = caixaService;
        }

        [HttpPost(Name = "PostLancamento")]
        public IActionResult Post([FromBody] LancamentoNovoVM lacamento)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var lancamentoDomain = lacamento.MapperToModel();
            _caixaService.InserirLancamento(lancamentoDomain, User.GetUserId());

            return Ok(LancamentoVerVM.MapperToVM(lancamentoDomain));
        }
    }
}