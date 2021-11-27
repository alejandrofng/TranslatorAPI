using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extensions
{
    public static class OperationExtensions
    {
        public static async Task<bool> ExistsAsync<T>(this DbContext dbContext, Guid id, CancellationToken cancellationToken = default) where T:Entity
        {
            return await dbContext.Set<T>().AnyAsync(x => x.Id == id);
        }
    }
}
