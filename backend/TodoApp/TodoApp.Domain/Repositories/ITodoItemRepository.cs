using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories
{
    public interface ITodoItemRepository
    {
        Task<TodoItem?> GetByIdAsync(Guid Id);
        Task<List<TodoItem>> GetAllByUserIdAsync(Guid UserId);
        Task AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(Guid Id);
    }
}
