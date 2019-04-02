using System;

namespace FunctionalExtensions.Option.Interfaces
{
    /// <summary>
    /// Defines an object able to perform some action 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOptionResultAction<T>
    {
        /// <summary>
        /// Performs an action using an actual value as input
        /// </summary>
        void OnValidResult(Action<T> resultCallback);
    }
}