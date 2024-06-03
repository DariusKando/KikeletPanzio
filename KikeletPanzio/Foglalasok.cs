using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikeletPanzio
{
    public class Foglalasok
    {
        int roomNum;
        string personName;
        DateTime arriveTime;
        DateTime leaveTime;
        int personCount;
        int priceSum;
        string resState;
        public int RoomNum { get => roomNum; set => roomNum = value; }
        public string PersonName { get => personName; set => personName = value; }
        public DateTime ArriveTime { get => arriveTime; set => arriveTime = value; }
        public DateTime LeaveTime { get => leaveTime; set => leaveTime = value; }
        public int PersonCount { get => personCount; set => personCount = value; }
        public int PriceSum { get => priceSum; set => priceSum = value; }
        public string ResState { get => resState; set => resState = value; }
        public Foglalasok(int roomNum, string personName, DateTime arriveTime, DateTime leaveTime, int personCount, int priceSum, string resState)
        {
            this.RoomNum = roomNum;
            this.PersonName = personName;
            this.ArriveTime = arriveTime;
            this.LeaveTime = leaveTime;
            this.PersonCount = personCount;
            this.PriceSum = priceSum;
            this.ResState = resState;
        }
        public Foglalasok(string sor)
        {
            this.RoomNum = int.Parse(sor.Split(';')[0]);
            this.PersonName = sor.Split(';')[1];
            this.ArriveTime = DateTime.Parse(sor.Split(';')[2]);
            this.LeaveTime = DateTime.Parse(sor.Split(';')[3]);
            this.PersonCount = int.Parse(sor.Split(';')[4]);
            this.PriceSum = int.Parse(sor.Split(';')[5]);
            this.ResState = sor.Split(';')[6];
        }
        public override string ToString()
        {
            return $"{RoomNum};{PersonCount};{ArriveTime};{LeaveTime};{PersonCount};{PriceSum};{ResState}";
        }
    }
}