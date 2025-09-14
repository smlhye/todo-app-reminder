using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Common;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.Entities
{
    public class User : AuditableEntity<Guid>
    {
        public Fullname Fullname { get; private set; } = default!;
        public List<TodoItem> UserTodoItems { get; private set; } = default!;
        private User() { }
        public User(Fullname fullname)
        {
            Id = Guid.NewGuid();
            Fullname = fullname ?? throw new ArgumentNullException(nameof(fullname), "Fullname is required");
            SetCreated(Id.ToString());
        }
        public void UpdateFullname(Fullname fullname)
        {
            Fullname = fullname ?? throw new ArgumentNullException(nameof(fullname), "Fullname is required");
            SetUpdated(Id.ToString());
        }
        public void AddTodoItem(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException(nameof(todoItem));
            UserTodoItems.Add(todoItem);
        } 
    }
}
