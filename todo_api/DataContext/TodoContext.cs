using Microsoft.EntityFrameworkCore;
using System;
using todo_api.Model;

namespace todo_api.DataContext
{
    public class TodoContext :DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options) :base(options)
        {

        }

        public DbSet<Todo> todo { get; set; } 

        
    }
}
