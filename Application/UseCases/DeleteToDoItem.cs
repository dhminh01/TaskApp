using Domain.Interfaces;

namespace Application.UseCases
{
    public class DeleteToDoItem
    {
        private readonly IToDoRepository _toDoRepository;

        public DeleteToDoItem(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            var toDoItem = await _toDoRepository.GetByIdAsync(id);
            if (toDoItem != null)
            {
                await _toDoRepository.DeleteAsync(id);

                return true;
            }

            return false;
        }
    }

}
