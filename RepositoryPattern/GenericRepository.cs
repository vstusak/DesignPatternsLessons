namespace _04_RepositoryPattern
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly WarehouseContext _warehouseContext;

        public GenericRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }
        public T Add(T item)
        {
            return _warehouseContext.Add(item).Entity;
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _warehouseContext.Set<T>().Where(expression);
        }

        public T Get(string name)
        {
            return _warehouseContext.Find<T>(name);
        }

        public IEnumerable<T> GetAll()
        {
            return _warehouseContext.Set<T>().ToList();
        }

        public void Remove(T item)
        {
            _warehouseContext.Remove(item);
        }

        public T Update(T item)
        {

            return _warehouseContext.Update(item).Entity;
        }
    }
}
