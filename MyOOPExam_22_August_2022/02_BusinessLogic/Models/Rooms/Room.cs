﻿using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;

        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public int BedCapacity
        {
            get 
            { 
              return this.bedCapacity;
            }
            private set 
            {
                this.bedCapacity = value;
            }
        }

        public double PricePerNight
        {
            get
            {
                return this.pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
