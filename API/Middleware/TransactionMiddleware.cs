using Infrastructure.Data;

namespace API.Middleware
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext, FurnitureStoreContext storeContext)
        {
            // For HTTP GET opening transaction is not required
            if (httpContext.Request.Method == HttpMethod.Get.Method)
            {
                await _next(httpContext);
                return;
            }

            using (var transaction = await storeContext.Database.BeginTransactionAsync())
            {
                await _next(httpContext);

                //Commit transaction if all commands succeed, transaction will auto-rollback when disposed if either commands fails
                await storeContext.Database.CommitTransactionAsync();
            }
        }
    }
}