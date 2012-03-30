using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace TankMap.CSVMapping
{
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class TankMapping
    {
        [FieldQuoted()]
        public string Organization;
        [FieldQuoted()]
        public string TankInfo;
        [FieldQuoted()]
        public string TankName;
        [FieldQuoted()]
        public string TankAddress;
        [FieldQuoted()]
        public string City;
        [FieldQuoted()]
        public string State;
        [FieldQuoted()]
        public string Zip;
        [FieldQuoted()]
        public string TaskType;
        [FieldQuoted()]
        public string TaskStatus;
        [FieldQuoted()]
        public string FullAddress;
        [FieldQuoted()]
        public string Latitude;
        [FieldQuoted()]
        public string Longitude;
    }
}