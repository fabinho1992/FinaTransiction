using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Services
{
    public interface ITransactionService
    {
        Task<Response<Transaction?>> CreateTransactionAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> UpdateTransactionAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> DeleteTransactionAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetTransactionByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>?>> GetTransactionByPeriodAsync(GetTransictionByPeriodRequest request);

    }
}
