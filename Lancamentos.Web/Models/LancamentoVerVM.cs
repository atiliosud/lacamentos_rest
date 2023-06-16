using Lancamentos.Business.Models;

namespace Lancamentos.Web.Models
{
    public class LancamentoVerVM
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string Descricao { get; set; } = String.Empty;

        public static IEnumerable<LancamentoVerVM> MapperToVM(IEnumerable<Lancamento> lancamentos)
        {
            return lancamentos.Select(x => MapperToVM(x));
        }

        public static LancamentoVerVM MapperToVM(Lancamento lancamento)
        {
            return new LancamentoVerVM()
            {
                Id = lancamento.Id,
                Valor = lancamento.Valor,
                Descricao = lancamento.Descricao,
                TipoPagamento = lancamento.TipoPagamento
            };
        }
    }
}