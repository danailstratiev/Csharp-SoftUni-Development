namespace Tests
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CustomLinkedListTests
    {

        [Test]
        public void CountShouldBeSetToZeroByConstructor()
        {
            DynamicList<int> coolList = new DynamicList<int>();

            Assert.That(coolList.Count, Is.EqualTo(0));
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(26);

            int element = coolList[0];

            Assert.That(element, Is.EqualTo(26));
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(26);

            coolList[0] = 69;

            Assert.That(coolList[0], Is.EqualTo(69));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void GettingInvalidIndexShouldThrowException(int index)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            for (int i = 0; i < 20; i++)
            {
                coolList.Add(i);
            }

            int returnValue = 0;

            // We check that there will be exception in case of invalid index :)
            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = coolList[index],
                "Index was out of range");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void SettingInvalidIndexShouldThrowException(int index)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            for (int i = 0; i < 20; i++)
            {
                coolList.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => coolList[index] = 69,
                "Index was " + index);

        }

        [Test]
        public void AddMethodShouldAddNewElementToTheCollection()
        {
            DynamicList<int> coolList = new DynamicList<int>();
            var collectionCount = coolList.Count;

            coolList.Add(6);

            Assert.That(coolList.Count, Is.EqualTo(collectionCount + 1));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(20)]
        public void RemoveAtMethodShoulThrowExceptionInCaseOfInvalidIndex(int index)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => coolList.RemoveAt(index), "Invalid index");
        }

        [Test]
        [TestCase(1)]
        public void RemovAtMethodShouldRemoveElementFromTheCollection(int index)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(8);

            var collectionCount = coolList.Count;

            coolList.RemoveAt(index);

            Assert.That(coolList.Count, Is.EqualTo(collectionCount - 1));
        }

        [Test]
        [TestCase(1)]
        public void RemovAtMethodShouldReturnRemovedElementFromTheCollection(int index)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(8);

            var element = coolList[index];

            var removedElement = coolList.RemoveAt(index);

            Assert.That(element, Is.EqualTo(removedElement));
        }

        [Test]
        [TestCase(8)]
        public void RemoveMethodShouldRemoveGivenElement(int number)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(8);

            var collectionCount = coolList.Count;
            coolList.Remove(number);

            Assert.That(coolList.Count, Is.EqualTo(collectionCount - 1));
        }

        [Test]
        [TestCase(8)]
        public void RemoveMethodShouldReturnRemovedElementIndex(int number)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(8);

            var indexOfRemovedElement = coolList.IndexOf(number);

            var expectedIndex = coolList.Remove(number);

            Assert.That(indexOfRemovedElement, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(8)]
        public void RemoveMethodShouldReturnMinusOneIfElementAtIndexIsNotFound(int number)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(9);

            var expectedIndex = coolList.Remove(number);
            Assert.That(-1, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(7)]
        public void IndexOfMethodShouldReturnIndexOfTheFirstOccurrenceOfTheElement(int value)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(7);

            var expectedIndex = coolList.IndexOf(value);

            Assert.That(1, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(8)]
        public void IndexOfMethodShouldReturnMinusOneIfTheCollectionDoesNotContainTheElement(int value)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(7);

            var expectedIndex = coolList.IndexOf(value);

            Assert.That(-1, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(9)]
        [TestCase(6)]
        public void ContainsMethodShouldReturnTrueIfTheCollectionContainsGivenElement(int element)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(9);

            Assert.That(coolList.Contains(element) == true);
        }

        [Test]
        [TestCase(7)]
        [TestCase(8)]
        public void ContainsMethodShouldReturnFalseIfTheCollectionDoesNotContainGivenElement(int element)
        {
            DynamicList<int> coolList = new DynamicList<int>();

            coolList.Add(6);
            coolList.Add(9);

            Assert.That(coolList.Contains(element) == false);
        }        
    }
}