using System;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess
{
    /// <summary>
    /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
    /// </summary>

    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso href="http://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/" target="_blank">
    /// This blog post provides useful information about <c>Unit Of Work Pattern</c></seealso>
    /// <seealso href="http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application" target="_blank">
    /// This MSDN article provides useful information about <c>Unit Of Work Pattern</c></seealso>
    public interface IUnitOfWork : IDisposable
    {
        // ISampleRepository SampleRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }

        IPolicyRepository PolicyRepository { get; }
        IProvinceRepository ProvinceRepository { get; }
        ICityRepository CityRepository { get; }
        IDiscountRepository DiscountRepository { get; }

        /// <summary>
        /// Commits all changes to database.
        /// </summary>
        /// <exception cref="DatabaseException">Throws when...</exception>
        void Commit();
    }
}