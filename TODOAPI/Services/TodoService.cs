using TODOAPI.DTOs;
using TODOAPI.Models;

namespace TODOAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<ToDoItem> _todos = new();
        private int _nextId = 1;

        private TodoResponseDto MapToResponse(ToDoItem todo)
        {
            return new TodoResponseDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
                DueDate = todo.DueDate,
                Priority = todo.Priority
            };
        }

        // GET all
        public List<TodoResponseDto> GetAll()
        {
            return _todos.Select(t => MapToResponse(t)).ToList();
        }

        // GET by id
        public TodoResponseDto? GetById(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return null;
            return MapToResponse(todo);
        }

        // POST - create
        public TodoResponseDto Create(CreateTodoDto dto)
        {
            var todo = new ToDoItem
            {
                Id = _nextId++,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false,          
                CreatedAt = DateTime.Now,   
                DueDate = dto.DueDate,
                Priority = dto.Priority
            };
            _todos.Add(todo);
            return MapToResponse(todo);
        }

        // PUT - update
        public TodoResponseDto? Update(int id, UpdateTodoDto dto)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return null;

            todo.Title = dto.Title;
            todo.Description = dto.Description;
            todo.IsCompleted = dto.IsCompleted;
            todo.DueDate = dto.DueDate;
            todo.Priority = dto.Priority;

            return MapToResponse(todo);
        }

        // DELETE
        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;
            _todos.Remove(todo);
            return true;
        }
    }
}