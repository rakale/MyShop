namespace Abc.Domain.Common
{
    public interface INamedEntity: IUniqueEntity
    {
        string Name { get; }
        string Code { get; }

    }

    public interface INamedEntity<out TData> : INamedEntity, IEntity<TData> { }

}
