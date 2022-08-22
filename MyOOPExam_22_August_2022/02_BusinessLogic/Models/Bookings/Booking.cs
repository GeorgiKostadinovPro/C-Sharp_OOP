using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get 
            {
                return this.room;
            }
            private set 
            {
                this.room = value;
            }
        }

        public int ResidenceDuration
        {
            get
            {
                return this.residenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                this.childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get
            {
                return this.bookingNumber;
            }
            private set
            {
                this.bookingNumber = value;
            }
        }

        //private double TotalPaid()
        //{
        //    double totalAmountToPay = this.ResidenceDuration * this.Room.PricePerNight;
        //    return Math.Round(totalAmountToPay, 2);
        //} 

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder(); 
            
            double totalAmountToPay = this.ResidenceDuration * this.Room.PricePerNight;

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalAmountToPay:F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}
