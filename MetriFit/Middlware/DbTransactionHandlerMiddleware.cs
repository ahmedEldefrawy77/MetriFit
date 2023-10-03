using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace MetriFit.Middlware
{
    public class DbTransactionHandlerMiddleware : IMiddleware
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<DbTransactionHandlerMiddleware> _logger;
        public DbTransactionHandlerMiddleware(ApplicationDbContext dbContext, ILogger<DbTransactionHandlerMiddleware> logger)
        {
            
           _logger= logger;
            _dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           
            IDbContextTransaction? transaction = null;
            try
            {
                transaction = await _dbContext.Database.BeginTransactionAsync();

                await next(context);

               await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
