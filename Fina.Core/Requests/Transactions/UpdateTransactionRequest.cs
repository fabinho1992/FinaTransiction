using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Transactions
{
    public class UpdateTransactionRequest : Request
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Título inválido!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime? PaidOrReceivedAt { get; set; }
        [Required(ErrorMessage = "Tipo inválido!")]
        public ETransictionType Type { get; set; } = ETransictionType.WithDraw;
        [Required(ErrorMessage = "Valor inválido!")]
        public decimal Amount { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}
