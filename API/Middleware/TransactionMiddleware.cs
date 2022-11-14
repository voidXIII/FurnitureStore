using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace API.Middleware
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly FurnitureStoreContext _context;
        public TransactionMiddleware(FurnitureStoreContext context)
        {
            _context = context;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await _context.Database.BeginTransactionAsync();
            await next(context);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
    }
}