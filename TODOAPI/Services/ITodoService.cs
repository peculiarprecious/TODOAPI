using TODOAPI.DTOs;

namespace TODOAPI.Services
{
    public interface ITodoService
    {
        List<TodoResponseDto> GetAll();
        TodoResponseDto? GetById(int id);
        TodoResponseDto Create(CreateTodoDto dto);
        TodoResponseDto? Update(int id, UpdateTodoDto dto);
        bool Delete(int id);
    }
}
