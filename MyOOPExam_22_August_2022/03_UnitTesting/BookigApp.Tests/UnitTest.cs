using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HotelConstrcutorShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Assert.AreEqual("Arthur", hotel.FullName);
            Assert.AreEqual(4, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]

        public void HotelFullNameShouldThrowArgumentNullException(string fullName)
        {
            Assert.That(() => {
               Hotel hotel = new Hotel(fullName, 4);
            }, Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]

        public void HotelFullNameShouldThrowArgumentException(int category)
        {
            Assert.That(() => {
                Hotel hotel = new Hotel("Arthur", category);
            }, Throws.ArgumentException);
        }

        [Test]
        public void HotelRoomsShouldReturnIReadOnlyCollection()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Room room = new Room(4, 50);
            Room room2 = new Room(4, 50);


            hotel.AddRoom(room);
            hotel.AddRoom(room2);

            IReadOnlyCollection<Room> rooms = new List<Room>()
            {
              room, room2,
            };

            CollectionAssert.AreEqual(rooms, hotel.Rooms);
        }

        [Test]
        public void HotelBookingsShouldReturnIReadOnlyCollection()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            IReadOnlyCollection<Booking> bookings = new List<Booking>();


            CollectionAssert.AreEqual(bookings, hotel.Bookings);
        }

        [Test]
        public void HotelAddRoomMethodShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Arthur", 4);
            Room room = new Room(4, 50);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomMethodShouldThrowExceptionWhenAdultsAreLessThanOrEqualToZero(int adults)
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Assert.That(() => {
                hotel.BookRoom(adults, 5, 10, 200);
            }, Throws.ArgumentException);
        }


        [Test]
        public void BookRoomMethodShouldThrowExceptionWhenChildrenAreLessThanZero()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Assert.That(() => {
                hotel.BookRoom(5, -1, 10, 200);
            }, Throws.ArgumentException);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomMethodShouldThrowExceptionWhenResidentDurationIsLessOrEqualToZero(int residentDuration)
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Assert.That(() => {
                hotel.BookRoom(5, 0, residentDuration, 200);
            }, Throws.ArgumentException);
        }

        [Test]
        public void BookRoomMethodShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Room room1 = new Room(4, 40);

            hotel.AddRoom(room1);

            hotel.BookRoom(2, 1, 2, 500);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookRoomMethodShouldWorkProperlyWithDifferentData()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Room room1 = new Room(4, 40);

            hotel.AddRoom(room1);

            hotel.BookRoom(2, 2, 2, 500);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookRoomMethodShouldWorkProperlyWithDifferentDataTurnover()
        {
            Hotel hotel = new Hotel("Arthur", 4);

            Room room1 = new Room(4, 40);

            hotel.AddRoom(room1);

            hotel.BookRoom(2, 2, 2, 500);
            
            Assert.AreEqual(80, hotel.Turnover);
        }
    }
}