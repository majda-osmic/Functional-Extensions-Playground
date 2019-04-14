using FunctionalExtensions.Option.Interfaces;
using System;
using System.Collections.Generic;

namespace FunctionalExtensions.Option
{
    /// <summary>
    /// Implementation of Option contaning no value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class None<T> : IOption<T>, IOptionResult<T>, IOptionResultAction<T>, IEquatable<None<T>>, IEquatable<T>
    {
        private static int _hashCode = new int();

        private T _value;

        private None() { }

        public static None<T> Create() => new None<T>();

        public T GetValue() => _value;

        public IOptionResult<T> WhenNone(Func<T> alternativeExecutionPath)
        {
            if (alternativeExecutionPath == null)
                throw new ArgumentNullException(nameof(alternativeExecutionPath));

            _value = alternativeExecutionPath.Invoke();
            return this;
        }

        public IOptionResultAction<T> WhenNone(Action alternativeExecutionPath)
        {
            if (alternativeExecutionPath == null)
                throw new ArgumentNullException(nameof(alternativeExecutionPath));

            alternativeExecutionPath.Invoke();
            return this;
        }

        public IOptionResult<T> WhenNone(T alternativeObject)
        {
            if (alternativeObject == null)
                throw new ArgumentNullException(nameof(alternativeObject));

            _value = alternativeObject;
            return this;
        }

        public IEnumerable<T> AsEnumerable() => new T[0];

        public void OnValidResult(Action<T> resultCallback)
        {
            //Do nothing, we have no valid result here
        }

        public T UnsafeConvert() => _value; //will most likely be null, but this is what user wants

        public IOptionResultAction<T> IgnoreNone() => this;

        public bool Equals(None<T> other)
        {
            if (other == null || other.GetValue() == null)
                return _value == null;

            return other.GetValue().Equals(_value);
        }

        public override bool Equals(object obj) => Equals(obj as None<T>);

        public bool Equals(T other)
        {
            if (other == null)
                return _value == null;

            return other.Equals(_value);
        }

        public static bool operator ==(None<T> none, None<T> anotherNone)
        {
            if (ReferenceEquals(none, null))
                return ReferenceEquals(anotherNone, null);

            if (ReferenceEquals(anotherNone, null))
                return false;

            if (ReferenceEquals(none.GetValue(), null))
                return ReferenceEquals(anotherNone.GetValue(), null);

            return none.GetValue().Equals(anotherNone.GetValue()); 
        }

        public static bool operator !=(None<T> none, None<T> anotherNone) => !(none == anotherNone);

        public override int GetHashCode()
        {
            if (_value != null)
                return _value.GetHashCode();

            return _hashCode;
        }
    }
}