using System.Collections.Generic;

namespace Otter.Business.Definitions.Factories
{
    public interface IFactory<TEntity, Tdto>
        where TEntity : class
        where Tdto : class
    {
        TEntity CreateEntity(Tdto dto);

        Tdto CreateDto(TEntity entity);

        IEnumerable<TEntity> CreateEntity(IEnumerable<Tdto> dtos);

        IEnumerable<Tdto> CreateDto(IEnumerable<TEntity> entities);
    }
}