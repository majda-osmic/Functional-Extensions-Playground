using FunctionalExtensions.Option;
using FunctionalExtensions.Option.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Option
    {
        private static IReadOnlyDictionary<int, string> _dummySampleData = new Dictionary<int, string>()
        {
            {1, "one" },
        };

        private static IOption<string> GetByKey(int key)
        {
            if (_dummySampleData.TryGetValue(key, out var data))
            {
                return Some<string>.Create(data);
            }

            return None<string>.Create();
        }

        [Test]
        public void CanGenerateSome()
        {
            var result = GetByKey(1).WhenNone("None").GetValue();

            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result, "one");
        }

        [Test]
        public void CanGenerateNone()
        {
            var result = GetByKey(-1).WhenNone("None").GetValue();

            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result, "None");
        }

        [Test]
        public void CanPerformUnsafeConvert()
        {
            var result = GetByKey(1).UnsafeConvert();
            Assert.AreEqual(result, "one");

            var nonExistant = GetByKey(-1).UnsafeConvert();
            Assert.IsNull(nonExistant);
        }

        [Test]
        public void CanIgnoreNone()
        {
            var list = new List<string>() { "random item" };

            var validResultCallback = new Action<string>(item => list.Add(item));

            Assert.AreEqual(1, list.Count);
            GetByKey(-1).IgnoreNone().OnValidResult(validResultCallback);

            Assert.AreEqual(1, list.Count);
            GetByKey(1).IgnoreNone().OnValidResult(validResultCallback);

            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(string.IsNullOrEmpty(list[1]));
        }

        [Test]
        public void CanExecuteWhenNoneCallback()
        {
            int validAccessCount = 0;
            int invalidAccessCount = 0;

            var validAccessCallback = new Action<string>(_ => validAccessCount++);
            var invalidAccessCallback = new Action(() => invalidAccessCount++);

            GetByKey(-1).WhenNone(invalidAccessCallback).OnValidResult(validAccessCallback);

            Assert.AreEqual(1, invalidAccessCount);
            Assert.AreEqual(0, validAccessCount);

            GetByKey(1).WhenNone(invalidAccessCallback).OnValidResult(validAccessCallback);

            Assert.AreEqual(1, invalidAccessCount);
            Assert.AreEqual(1, validAccessCount);
        }


        [Test]
        public void CanConvertToIEnumerable()
        {
            var enumerable = GetByKey(1).AsEnumerable();
            Assert.AreEqual(1, enumerable.Count());

            var invalidAccessAnumerable = GetByKey(-1).AsEnumerable();
            Assert.IsNotNull(invalidAccessAnumerable);
            Assert.IsEmpty(invalidAccessAnumerable);
        }
    }
}