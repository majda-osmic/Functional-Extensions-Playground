using FunctionalExtensions.Option.Interfaces;
using System;
using System.Collections.Generic;

namespace FunctionalExtensions.Option
{
    /// <summary>
    /// Implementation of Option contaning some value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Some<T> : IOption<T>, IOptionResult<T>, IOptionResultAction<T>
    {
        private T _value;

        private Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public static Some<T> Create(T value) => new Some<T>(value);

        public IEnumerable<T> AsEnumerable() => new T[1] { _value };

        public T GetValue() => _value;

        public T UnsafeConvert() => _value;

        public IOptionResult<T> WhenNone() => this;

        public IOptionResult<T> WhenNone(Func<T> alternativeExecutionPath) => this;

        public IOptionResultAction<T> WhenNone(Action alternativeExecutionPath) => this;

        public IOptionResult<T> WhenNone(T _) => this;

        public void OnValidResult(Action<T> resultCallback) => resultCallback.Invoke(_value);

        public IOptionResultAction<T> IgnoreNone() => this;
    }
}
