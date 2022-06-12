using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Otter.DataAccess.Repositories
{
    /// <summary>
    /// Basic repository functionalities.
    /// all repositories implements this <c>Interface</c>
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso href="http://blog.falafel.com/implement-step-step-generic-repository-pattern-c/">
    /// This blog post my give you some useful information about the <c>Repository Pattern</c>.
    /// </seealso>
    /// <remarks><img src="../media/repository-pattern.png" />
    /// <note type="important">
    /// Implemented members should not apply changes to Database directly.
    /// </note>
    /// <seealso cref="IUnitOfWork{TEntity}" /></remarks>

    public interface IRepository<TEntity>// where TEntity : class
    {
        /// <summary>
        /// Gets all stored objects.
        /// </summary>
        /// <remarks>
        /// <note type="warning">
        /// Using this method affects to the database queries directly and may cause to execute bad queries.
        /// if you do not want to provide this method to implement this method explicitly.
        /// derived <c>Interfaces</c> may provide better alternative methods for querying data.
        /// </note>
        /// </remarks>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets a Queryable collection.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        /// <remarks><note type="warning">
        /// Using this method affects to the database queries directly and may cause to execute bad queries.
        /// if you do not want to provide this method to implement this method explicitly.
        /// derived <c>Interfaces</c> may provide better alternative methods for querying data.
        /// </note></remarks>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);
    }
}