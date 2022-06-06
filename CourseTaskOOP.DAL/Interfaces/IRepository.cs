namespace CourseTaskOOP.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    List<T> GetAll();

    T GetById(int id);

    List<T> Find(Func<T, bool> predicate);

    T Create(T item);

    void Update(T item);

    void Delete(T item);
}