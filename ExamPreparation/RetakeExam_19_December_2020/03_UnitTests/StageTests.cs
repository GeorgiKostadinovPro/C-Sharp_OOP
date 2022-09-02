// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {

		[Test]
	    public void ConstructorShouldWorkProperly()
	    {
			Stage stage = new Stage();

            Assert.AreEqual(0, stage.Performers.Count);
		}

        [Test]
        public void PropertyPerformersShouldReturnIReadOnlyCollectionOfTypePerformer()
        {
            Stage stage = new Stage();

            IReadOnlyCollection<Performer> performers = new List<Performer>();

            CollectionAssert.AreEqual(performers, stage.Performers);
        }

        [Test]
        public void AddPerformerMethodShouldWorkProperly()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);

            stage.AddPerformer(performer);

            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void AddPerformerMethodShouldInvokeValidateNullValueMethodAndThrowException()
        {
            Stage stage = new Stage();
             
            Assert.That(() => {

               stage.AddPerformer(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void AddPerformerMethodShouldThrowAnArgumentExceptionForInvalidAge()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 17);

            Assert.That(() => {

                stage.AddPerformer(performer);
            }, Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
        }

        [Test]
        public void AddSongMethodShouldInvokeValidateNullValueMethodAndThrowException()
        {
            Stage stage = new Stage();

            Assert.That(() =>
            {

                stage.AddSong(null);
            }, Throws.ArgumentNullException);
        }


        [Test]
        public void AddSongMethodShouldThrowAnArgumentExceptionWhenSongDurationIsUnderOneMinute()
        {
            Stage stage = new Stage();
            Song song = new Song("Moon sonata", new TimeSpan(0, 0, 50));

            Assert.That(() =>
            {
                stage.AddSong(song);
            }, Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }

        [Test]
        public void AddSongToPerformerMethodShouldWorkProperly()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            string result = stage.AddSongToPerformer("Moon sonata", "George Kostadinov");

            Assert.AreEqual($"{song} will be performed by {performer.FullName}", result);
        }


        [Test]
        public void AddSongToPerformerMethodShouldInvokeValidateNullValueMethodAndThrowExceptionWhenSongIsNull()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
               string result = stage.AddSongToPerformer(null, "George Kostadinov");
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerMethodShouldInvokeValidateNullValueMethodAndThrowExceptionWhenPerformerIsNull()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
                string result = stage.AddSongToPerformer("Moon sonata", null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerMethodShouldInvokeGetSongAndThrowException()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
                string result = stage.AddSongToPerformer("Fur Elise", "George Kostadinov");
            }, Throws.ArgumentException.With.Message.EqualTo("There is no song with this name."));
        }

        [Test]
        public void AddSongToPerformerMethodShouldInvokeGetPerformerAndThrowException()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
                string result = stage.AddSongToPerformer("Fur Elise", "Lyuboslav Veliev");
            }, Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));
        }

        [Test]
        public void PlayMethodShouldWorkProperly()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("George", "Kostadinov", 19);
            Song song = new Song("Moon sonata", new TimeSpan(0, 2, 50));
            Song song2 = new Song("Fur Elise", new TimeSpan(0, 3, 0));

            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSong(song2);

            stage.AddSongToPerformer("Moon sonata", "George Kostadinov");
            stage.AddSongToPerformer("Fur Elise",   "George Kostadinov");

            string result = stage.Play();

            Assert.AreEqual("1 performers played 2 songs", result);
        }
    }
}