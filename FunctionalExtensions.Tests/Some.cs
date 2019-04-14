using FunctionalExtensions.Option;
using NUnit.Framework;

namespace FunctionalExtensions.Tests
{
    [TestFixture]
    class Some
    {

        [Test]
        public void HasCorrectEqualsImplementation()
        {
            var randomString = "Some random string";
            var someRandomString = Some<string>.Create(randomString);

            var anotherSomeRandomString = Some<string>.Create(randomString);
            Assert.AreEqual(someRandomString, anotherSomeRandomString);

            Assert.AreEqual(randomString, someRandomString);
        }

        [Test]
        public void HasCorrectOperatorEqualsImplementation()
        {
            var randomString = "Some random string";
            var someRandomString = Some<string>.Create(randomString);

            var anotherSomeRandomString = Some<string>.Create(randomString);
            Assert.IsTrue(someRandomString == anotherSomeRandomString);
        }

        [Test]
        public void HasCorrectOperatorNotEqualsImplementation()
        {
            var randomString = "Some random string";
            var someRandomString = Some<string>.Create(randomString);

            var anotherSomeRandomString = Some<string>.Create(randomString);
            Assert.IsFalse(someRandomString != anotherSomeRandomString);

            Assert.IsTrue(someRandomString != Some<string>.Create("any other not random string"));
        }

        [Test]
        public void HasCorrectGetHashCodeImplementation()
        {
            var randomString = "Some random string";
            var someRandomString = Some<string>.Create(randomString);
            Assert.AreEqual(someRandomString.GetHashCode(), randomString.GetHashCode());

            var anotherSomeRandomString = Some<string>.Create(randomString);
            Assert.AreEqual(someRandomString.GetHashCode(), anotherSomeRandomString.GetHashCode());

            Assert.AreNotEqual(someRandomString.GetHashCode(), "test".GetHashCode());
        }
    }
}
