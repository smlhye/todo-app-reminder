using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Common
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ITodoItemRepository TodoItemRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // Transaction
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
