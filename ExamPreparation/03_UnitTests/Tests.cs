namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void BookShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Ivan Vazov"));
        }

        [Test]
        public void AuthorShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Book("Pod igoto", ""));
        }

        [Test]
        public void AddFootnoteMethodShouldThrowException()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "Nice"));
        }

        [Test]
        public void AddFootnoteMethodShouldWorkProperly()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");
            book.AddFootnote(2, "Nice");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteMethodShouldWorkProperly()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");
            book.AddFootnote(2, "Nice");

            string result = book.FindFootnote(1);

            Assert.AreEqual("Footnote #1: Cool", result);
        }

        [Test]
        public void FindFootnoteMethodShouldthrowException()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");
            book.AddFootnote(2, "Nice");

            string result = book.FindFootnote(1);

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(3));
        }

        [Test]
        public void AlterFootnoteMethodShouldWorkProperly()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");
            book.AddFootnote(2, "Nice");

            book.AlterFootnote(1, "Bad");
            string result = book.FindFootnote(1);

            Assert.AreEqual("Footnote #1: Bad", result);
        }

        [Test]
        public void AlterFootnoteMethodShouldthrowException()
        {
            Book book = new Book("Pod igoto", "Ivan Vazov");

            book.AddFootnote(1, "Cool");
            book.AddFootnote(2, "Nice");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(3, "Bad"));
        }
    }
}