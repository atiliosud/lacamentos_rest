using Castle.Core.Logging;
using FluentAssertions;
using Lancamentos.Business.Contracts.Services;
using Lancamentos.Repository.Data;
using Lancamentos.Web.Controllers;
using Lancamentos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace Lancamentos.Web.Test
{
    public class LancamentoControllerTest
    {

        private readonly Mock<ICaixaService> _serviceMock;
        private readonly ILogger<LancamentoController> _logger;
        private readonly LancamentoController _controller;

        public LancamentoControllerTest(ITestOutputHelper output)
        {
            /*
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "cadcaminhoes")
                .Options;
            
            _context = new ApplicationDbContext(options);
            */
            _logger = new XunitLogger<LancamentoController>(output);
            _serviceMock = new Mock<ICaixaService>();
            _controller = new LancamentoController(_logger, _serviceMock.Object) ;
        }

        [Fact]
        public void LancamentoController_Post_OK()
        {
            LancamentoNovoVM lancamentoNovo = new LancamentoNovoVM()
            {
                Descricao = "test",
                TipoPagamento = Business.Models.TipoPagamento.Credito,
                Valor = 123
            };

            var actionResult = _controller.Post(lancamentoNovo);

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<LancamentoVerVM>();

        }

        [Fact]
        public void LancamentoController_Post_Unprocessable()
        {
            LancamentoNovoVM lancamentoNovo = new LancamentoNovoVM()
            {
                Descricao = "test",
                TipoPagamento = Business.Models.TipoPagamento.Credito,
                Valor = 123
            };

            _controller.ModelState.AddModelError("modelerro", "test");

            var actionResult = _controller.Post(lancamentoNovo);

            actionResult.Should().BeOfType<UnprocessableEntityObjectResult>();

        }
    }
}