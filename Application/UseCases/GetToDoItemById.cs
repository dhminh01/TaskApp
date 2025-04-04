using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class GetToDoItemById
    {
        private readonly IToDoRepository _toDoRepository;

        public GetToDoItemById(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ToDoItem> ExecuteAsync(int id)
        {

            return await _toDoRepository.GetByIdAsync(id);
        }
    }
}
