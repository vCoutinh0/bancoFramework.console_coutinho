namespace Domain.Interfaces.Repositories
{
    public interface IBaseSqlServerRepository<TEntity> where TEntity : class
    {
        TEntity ObterPorId(int id);
        TEntity Atualizar(TEntity entity);
    }
}
