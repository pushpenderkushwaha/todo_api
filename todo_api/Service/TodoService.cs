using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using todo_api.DataContext;
using todo_api.DTO.Todo;
using todo_api.Interface;
using todo_api.Model;

namespace todo_api.Service
{
    public class TodoService : ITodo
    {

        private readonly TodoContext _context;
        
        public TodoService(TodoContext todoContext)
        {
            _context = todoContext;
        }


        public async Task<IEnumerable<Todo>> GetAll()
        {
            var todo = await _context.todo.ToListAsync();

            return todo;
        }

        public async Task<ActionResult<int>> CreateTodo(TodoAdd todoAdd)
        {
            var note = new Todo {
                TodoTitle = todoAdd.TodoTitle,
                TodoDescription = todoAdd.TodoDescription,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            _context.todo.Add(note);
            await _context.SaveChangesAsync();
            return note.ID;
        }

        public async Task<ActionResult<Todo>> GetById(int id)
        {
            var todo = await _context.todo.FindAsync(id);
          

            return todo;
            
        }

        public async Task<ActionResult<bool>> UpdateById(int id ,Todo todo)
        {
            try
            {
                var res = _context.todo.FirstOrDefault(r => r.ID == id);
                if (res == null)
                {
                    return false;
                }

                res.TodoTitle = todo.TodoTitle;
                res.TodoDescription = todo.TodoDescription;
                res.UpdatedAt = DateTime.UtcNow;
                _context.todo.Update(res);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {   
                return false;
            }
        }

        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            var todo = await _context.todo.FindAsync(id);

            if (todo == null)
            {
                return false;
            }

            _context.todo.Remove(todo);

            await _context.SaveChangesAsync();


            return true;
        }
    }
}
