using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Domain.Entities;

namespace FrameworksAndDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly AddToDoItem _addToDoItem;
        private readonly GetAllToDoItems _getAllToDoItems;
        private readonly UpdateToDoItem _updateToDoItem;
        private readonly DeleteToDoItem _deleteToDoItem;
        private readonly GetToDoItemById _getToDoItemById;


        public ToDoController(AddToDoItem addToDoItem, UpdateToDoItem updateToDoItem,
                          DeleteToDoItem deleteToDoItem, GetAllToDoItems getAllToDoItems, GetToDoItemById getToDoItemById)
        {
            _addToDoItem = addToDoItem;
            _getAllToDoItems = getAllToDoItems;
            _updateToDoItem = updateToDoItem;
            _deleteToDoItem = deleteToDoItem;
            _getToDoItemById = getToDoItemById;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToDoItem item)
        {
            await _addToDoItem.ExecuteAsync(item);

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _getAllToDoItems.ExecuteAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var toDoItem = await _getToDoItemById.ExecuteAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return Ok(toDoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoItem>> PutToDoItem(int id, [FromBody] ToDoItem toDoItem)
        {
            var result = await _updateToDoItem.ExecuteAsync(id, toDoItem.Title, toDoItem.IsCompleted);
            if (result == null)
            {

                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoItem(int id)
        {
            var success = await _deleteToDoItem.ExecuteAsync(id);
            if (!success)
            {

                return NotFound();
            }

            return NoContent();
        }
    }
}
