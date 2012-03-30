using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankMap.Models
{
    public class Tank : IModel
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Organization { get; set; }
        public string TankInfo { get; set; }
        public string TankName { get; set; }
        public string TankAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string TaskType { get; set; }
        public string TaskStatus { get; set; }
        public string FullAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Tank(){

        }

        public Tank(string Organization, string TankInfo, string TankName, string TankAddress, string City, 
                    string State, string Zip, string TaskType, string TaskStatus, string FullAddress, 
                    string Latitude, string Longitude,int ID)
        {
            this.Organization = Organization;
            this.TankInfo = TankInfo;
            this.TankName = TankName;
            this.TankAddress = TankAddress;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.TaskType = TaskType;
            this.TaskStatus = TaskStatus;
            this.FullAddress = FullAddress;
            this.DateCreated = DateTime.Now;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.ID = ID;
        }
    }
}