using FunctionalExtensions.Option.Interfaces;
using System;
using System.Collections.Generic;

namespace FunctionalExtensions.Option
{
    /// <summary>
    /// Implementation of Option contaning no value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class None<T> : IOption<T>, IOptionResult<T>, IOptionResultAction<T>
    {
        private T _value;

        private None() { }

        public static None<T> Create() => new None<T>();

        public T GetValue() => _value;

        public IOptionResult<T> WhenNone(Func<T> alternativeExecutionPath)
        {
            _value = alternativeExecutionPath.Invoke();
            return this;
        }

        public IOptionResultAction<T> WhenNone(Action alternativeExecutionPath)
        {
            alternativeExecutionPath.Invoke();
            return this; 
        }

        public IOptionResult<T> WhenNone(T alternativeObject)
        {
            _value = alternativeObject;
            return this;
        }

        public IEnumerable<T> AsEnumerable() => new T[0];

        public void OnValidResult(Action<T> resultCallback)
        {
            //Do nothing, we have no valid result here
        }

        public T UnsafeConvert() => _value; //will most likely be null, but this is what user wants

        public IOptionResultAction<T> IgnoreNone() =>  this;

      
    }
}