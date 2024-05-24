using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KikeletPanzio
{
    public class Felhasznalok
    {
        string accID;
        string personName;
        DateTime personBirth;
        string personEmail;
        bool isVIP;
        public string AccID { get => accID; set => accID = value; }
        public string PersonName { get => personName; set => personName = value; }
        public DateTime PersonBirth { get => personBirth; set => personBirth = value; }
        public string PersonEmail { get => personEmail; set => personEmail = value; }
        public bool IsVIP { get => isVIP; set => isVIP = value; }
        public Felhasznalok(string accID, string personName, DateTime personBirth, string personEmail, bool isVIP)
        {
            this.AccID = accID;
            this.PersonName = personName;
            this.PersonBirth = personBirth;
            this.PersonEmail = personEmail;
            this.IsVIP = isVIP;
        }
        public Felhasznalok(string sor)
        {
            this.AccID = sor.Split(';')[0];
            this.PersonName = sor.Split(';')[1];
            this.PersonBirth = DateTime.Parse(sor.Split(';')[2]);
            this.PersonEmail = sor.Split(';')[3];
            this.IsVIP = bool.Parse(sor.Split(';')[4]);
        }
        public override string ToString()
        {
            return $"{AccID};{PersonName};{PersonBirth};{PersonEmail};{IsVIP}";
        }
    }
}