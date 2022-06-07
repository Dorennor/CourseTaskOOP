namespace CourseTaskOOP.BLL.Interfaces;

public interface IUsersService<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<List<T>> FindAsync(Func<T, bool> predicate);

    Task<T> CreateAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(T item);

    Task<bool> RegisterAsync(T item);

    Task<bool> LoginAsync(T item);

    Task LogoutAsync();

    Task<T?> GetLoggedUserAsync();
}