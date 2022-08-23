using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> allHotels = this.hotels.All()
                .Where(h => h.Category == category)
                .ToList();
            
            int guests = children + adults;

            string result = string.Empty;

            if (allHotels.Count == 0)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            allHotels.OrderBy(h => h.FullName);

            while(allHotels.Count > 0)
            {
                var currHotel = allHotels.FirstOrDefault();

                var hotelRooms = currHotel.Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .ToArray();

                hotelRooms = hotelRooms
                    .OrderBy(r => r.BedCapacity)
                    .ToArray();
                
                if (hotelRooms.Any(hr => hr.BedCapacity >= guests) == false)
                {
                    return OutputMessages.RoomNotAppropriate;
                }

                IRoom room = null;

                bool roomFound = false;

                foreach (var hotelRoom in hotelRooms)
                {
                    if (hotelRoom.BedCapacity >= guests)
                    {
                        room = hotelRoom;
                        roomFound = true; 
                        break;
                    }
                }

                if (roomFound)
                {
                    int bookingNumber = currHotel.Bookings.All().Count + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
                    IHotel hotelWithAccomodation = this.hotels.Select(currHotel.FullName);
                    hotelWithAccomodation.Bookings.AddNew(booking);
                    
                    result = string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotelWithAccomodation.FullName);
                    break;
                }

                allHotels.Remove(currHotel);
            }

            return result;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();

            IReadOnlyCollection<IBooking> hotelBookings = hotel.Bookings.All();

            if (hotelBookings.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (IBooking booking in hotelBookings)
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            } 
            
            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
