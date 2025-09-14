using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.User.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; } = default!;
    }
}
