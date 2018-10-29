namespace GapInsurance.Repositories
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {
       
    }
}