using model;

namespace ConsoleApp1.repository;

public abstract class CrudRepository <ID, E> : Entity<int>
{
    public abstract E findOne(ID id);

    public abstract IEnumerable<E> findAll();

    public abstract E save(E entity);

    public abstract E delete(ID id);

    public abstract E update(E entity);
}