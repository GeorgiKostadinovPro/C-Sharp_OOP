namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void AddMethodShouldWorkProperly()
        {
            //Arrange
            Database database = new Database(1, 2, 3);

            //Act
            database.Add(4);

            //Assert
            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]

        public void AddMethodShouldThrowExceptionIfThereIsNoSpaceToAddElement()
        {
            //Arrange
            Database database =
                new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(17), "The method does not throw exception!");

        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            //Arrange
            Database database = new Database(1, 2, 3);

            //Act
            database.Remove();

            //Assert
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]

        public void RemoveMethodShouldThrowExceptionIfThereAreNoElementsToRemove()
        {
            //Arrange
            Database database =
                new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The method does not throw exception!");
        }

        [Test]

        public void FetchMethodShouldWorkProperly()
        {
            //Arrange
            Database database =
                new Database(1,2,3);

            int[] fetchedData = database.Fetch();

            Assert.That(fetchedData.Length, Is.EqualTo(3));
        }
    }
}
