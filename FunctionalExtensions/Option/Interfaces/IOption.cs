using System;
using System.Collections.Generic;

namespace FunctionalExtensions.Option.Interfaces
{
    /// <summary>
    /// Describes a type that may or may not have an actual value.
    /// Before the data can be accessed, a way to handle missing data is not available
    /// must be provided
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOption<T>
    {
        /// <summary>
        /// Deals with the "no value scenario" by invoking a given function
        /// </summary>
        /// <param name="alternativeCallback">The alternative function returning a fallback value</param>
        /// <returns>An object containing the data, either actual or fallback</returns>
        IOptionResult<T> WhenNone(Func<T> alternativeCallback);

        /// <summary>
        /// Deals with "no value scenario" using a fallback value
        /// </summary>
        /// <param name="alternativeObject">Fallback value</param>
        /// <returns>An object containing the data, either actual or fallback</returns>
        IOptionResult<T> WhenNone(T alternativeObject);

        /// <summary>
        /// Deals with "no value scenario" by invoking a given action
        /// </summary>
        /// <param name="alternativeCallback">An object which can execute an action if the actual data is available</param>
        /// <returns></returns>
        IOptionResultAction<T> WhenNone(Action alternativeCallback);

        /// <summary>
        /// Ignores the "no value scenario"
        /// </summary>
        /// <returns>An object which can execute an action if the actual data is available</returns>
        IOptionResultAction<T> IgnoreNone();

        /// <summary>
        /// Converts the option to IEnumreble
        /// </summary>
        /// <returns>IEnumerable containing either none or one item</returns>
        IEnumerable<T> AsEnumerable();

        /// <summary>
        /// Performs an unsafe convert by exposing the raw data. May return null
        /// </summary>
        /// <returns>Either the actual value or null</returns>
        T UnsafeConvert();
    }
}