using Fina.Api.Data;
using Fina.Core.Enums;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Response<Transaction?>> CreateTransactionAsync(CreateTransactionRequest request)
        {
            //AQUI , SE O TYPE FOR UMA RETIRADA , CONVERTO A QUANTIA "AMOUNT" EM NEGATIVO
            if (request is { Type: ETransictionType.WithDraw, Amount: > 0 }) request.Amount *= -1;

            try
            {
                var trasaction = new Transaction
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Type = request.Type,
                    Amount = request.Amount,
                    CreatedAt = DateTime.Now,
                    PaidOrReceivedAt = request.PaidOrReceivedAt,
                    CategoryId = request.CategoryId
                };

                await _context.Transactions.AddAsync(trasaction);
                await _context.SaveChangesAsync();

                return new Response<Transaction?>(trasaction, 201, "Trasação criada!");
            }
            catch 
            {
                return new Response<Transaction?>(null, 500, "Não foi possível concluir!");
            }
            
        }

        public async Task<Response<Transaction?>> DeleteTransactionAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transaction = await _context.Transactions
                    .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);
                if (transaction is null) return new Response<Transaction?>(null, 404, "Transação não encontrada!");

                _context.Remove(transaction);
                await _context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, message: "Removido com sucesso!");
            }
            catch 
            {
                return new Response<Transaction?>(null, 500, "Não foi possível concluir!");
            }
        }

        public async Task<Response<Transaction?>> GetTransactionByIdAsync(GetTransactionByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Transaction>?>> GetTransactionByPeriodAsync(GetTransictionByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Transaction?>> UpdateTransactionAsync(UpdateTransactionRequest request)
        {
            if (request is { Type: ETransictionType.WithDraw, Amount: > 0 }) request.Amount *= -1;

            try
            {
                var transaction = await _context.Transactions
                    .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);
                if (transaction is null) return new Response<Transaction?>(null, 404, "Transação não encontrada!");

                transaction.Title = request.Title;
                transaction.CategoryId = request.CategoryId;
                transaction.Amount = request.Amount;
                transaction.Type = request.Type;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;

                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, message: "Atualizado com sucesso!");
            }
            catch 
            {
                return new Response<Transaction?>(null, 500, "");
            }
        }
    }
}
