using FunctionalExtensions.Option;
using NUnit.Framework;

namespace FunctionalExtensions.Tests
{
    [TestFixture]
    class None
    {
        [Test]
        public void HasCorrectEqualsImplementation()
        {
            var none = None<string>.Create();
            Assert.AreEqual(none, None<string>.Create());

            Assert.AreNotEqual(none, null);

            var alternativeValue = "alternative";
            var noneWithAlternative = none.WhenNone(alternativeValue);

            var testObject = None<string>.Create().WhenNone(alternativeValue);
            Assert.AreEqual(testObject, noneWithAlternative);

            Assert.AreEqual("alternative", noneWithAlternative);
        }

        [Test]
        public void HasCorrectOperatorEqualsImplementation()
        {
            var none = None<string>.Create();
            Assert.IsTrue(none == None<string>.Create());
            Assert.IsTrue(None<string>.Create() == none);


            Assert.IsFalse(none == null);
            Assert.IsFalse(null == none);

            none.WhenNone("alternative");

            Assert.IsFalse(None<string>.Create() == none);

            var testObject = None<string>.Create();
            testObject.WhenNone("alternative");
            Assert.IsTrue(testObject == none);
        }

        [Test]
        public void HasCorrectOperatorNotEqualsImplementation()
        {
            var none = None<string>.Create();
            Assert.IsFalse(none != None<string>.Create());
            Assert.IsFalse(None<string>.Create() != none);


            Assert.IsTrue(none != null);
            Assert.IsTrue(null != none);

            none.WhenNone("alternative");

            Assert.IsTrue(None<string>.Create() != none);

            var testObject = None<string>.Create();
            testObject.WhenNone("alternative");
            Assert.IsFalse(testObject != none);
        }

        [Test]
        public void HasCorrectGetHashCodeImplementation()
        {
            var randomString = "Some random string";
            var none = None<string>.Create().WhenNone(randomString);
            Assert.AreEqual(none.GetHashCode(), randomString.GetHashCode());

            var anotherNomeRandomString = None<string>.Create().WhenNone(randomString);
            Assert.AreEqual(none.GetHashCode(), anotherNomeRandomString.GetHashCode());

            Assert.AreNotEqual(none.GetHashCode(), "test".GetHashCode());

            Assert.AreEqual(None<string>.Create().GetHashCode(), None<string>.Create().GetHashCode());

            Assert.AreNotEqual(none.GetHashCode(), None<string>.Create().GetHashCode());
        }
    }
}
