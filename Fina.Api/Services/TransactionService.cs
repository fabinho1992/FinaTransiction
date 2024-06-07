using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.Api.Services
{
    public class TransactionService : ITransactionService
    {
        public Task<Response<Transaction?>> CreateTransactionAsync(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction?>> DeleteTransactionAsync(DeleteTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Transaction>?>> GetTransactionByPeriodAsync(GetTransictionByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction?>> UpdateTransactionAsync(UpdateTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
