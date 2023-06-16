using System.ComponentModel.DataAnnotations;
using Lancamentos.Business.Models;

namespace Lancamentos.Web.Models
{
    public class LancamentoNovoVM
    {
        [Required]
        public decimal? Valor { get; set; }
        [Required]
        public TipoPagamento? TipoPagamento { get; set; }
        public string Descricao { get; set; } = String.Empty;

        internal Lancamento MapperToModel()
        {
            return new Lancamento()
            {
                Valor = this.Valor??0,
                TipoPagamento = this.TipoPagamento??0,
                Descricao = this.Descricao
            };
        }
    }
}