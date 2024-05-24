using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikeletPanzio
{
    public class Szobak
    {
        int roomNum;
        int roomCapacity;
        int roomPrice;
        public int RoomNum { get => roomNum; set => roomNum = value; }
        public int RoomCapacity { get => roomCapacity; set => roomCapacity = value; }
        public int RoomPrice { get => roomPrice; set => roomPrice = value; }
        public Szobak(int roomNum, int roomCapacity, int roomPrice)
        {
            this.RoomNum = roomNum;
            this.RoomCapacity = roomCapacity;
            this.RoomPrice = roomPrice;
        }
        public Szobak(string sor)
        {
            this.RoomNum = int.Parse(sor.Split(';')[0]);
            this.RoomCapacity = int.Parse(sor.Split(';')[1]);
            this.RoomPrice = int.Parse(sor.Split(';')[2]);
        }
        public override string ToString()
        {
            return $"{RoomNum};{RoomCapacity};{RoomPrice}";
        }
    }
}