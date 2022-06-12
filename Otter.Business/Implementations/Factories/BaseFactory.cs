using System.Collections.Generic;
using Otter.Business.Definitions.Factories;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Factories
{
    public class BaseFactory<TEntity, Tdto> : IFactory<TEntity, Tdto> where TEntity : class where Tdto : class
    {
        public virtual TEntity CreateEntity(Tdto dto)
        {
            //return GoodMapper.Map<TEntity>(dto);
            return ObjectCopy.ShallowCopy<TEntity, Tdto>(dto);
        }

        public virtual Tdto CreateDto(TEntity entity)
        {
            //return GoodMapper.Map<Tdto>(entity);
            return ObjectCopy.ShallowCopy<Tdto, TEntity>(entity);
        }

        public virtual IEnumerable<TEntity> CreateEntity(IEnumerable<Tdto> dtos)
        {
            if (dtos == null)
                return null;
            var result = new List<TEntity>();
            foreach (var dto in dtos)
            {
                result.Add(CreateEntity(dto));
            }
            return result;
        }

        public virtual IEnumerable<Tdto> CreateDto(IEnumerable<TEntity> entities)
        {
            var result = new List<Tdto>();
            foreach (var entity in entities)
            {
                result.Add(CreateDto(entity));
            }
            return result;
        }
    }
}