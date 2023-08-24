using Microsoft.AspNetCore.Mvc;
using todo_api.DTO.Todo;
using todo_api.Model;

namespace todo_api.Interface
{
    public interface ITodo
    {
        Task<IEnumerable<Todo>> GetAll();


        Task<ActionResult<int>> CreateTodo(TodoAdd todoAdd);

        Task<ActionResult<Todo>> GetById(int id);

        Task<ActionResult<bool>> UpdateById(int id,Todo todo);

        Task<ActionResult<bool>> DeleteById(int id);






     
    }
}
