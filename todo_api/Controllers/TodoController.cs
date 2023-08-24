using Microsoft.AspNetCore.Mvc;
using todo_api.DTO.Todo;
using todo_api.Interface;
using todo_api.Model;
using todo_api.Service;

namespace todo_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodo _todoService;

        public TodoController(ITodo todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            var note = await _todoService.GetAll();
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTodo(TodoAdd todoAdd)
        {
            var noteId = await _todoService.CreateTodo(todoAdd);
            return Ok(noteId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            var todo = await _todoService.GetById(id);
            return Ok(todo);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<bool>> UpdateNoteById(int id ,Todo todo) 
        {
            var Item = await _todoService.GetById(id);
            if(Item == null)
            {
                return NotFound();
            }

            var tod = await _todoService.UpdateById(id,todo);

            return Ok(tod);


        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> DeleteById(int id)
        {
         
            var status = await _todoService.DeleteById(id);

            return Ok(status);

        }

    }
}
