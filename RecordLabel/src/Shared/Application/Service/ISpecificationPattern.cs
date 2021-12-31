namespace RecordLabel.src.Shared.Application.Service
{
    public interface ISpecificationPattern<T>
    {
        bool IsSatisfiedBy(T entity);

    }
}
