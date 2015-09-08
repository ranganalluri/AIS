using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP.Hypermedia
{
    public class UrlConstants
    {
        public const string PostDriver = "api/Driver/Post/{key}";
        public const string PostValues = "api/Values/Post";
        public const string PostCustomer = "api/Customer/Post/{key}";
        public const string PostInitial = "api/Initial/Post";
        public const string GetYearsLookup = "api/Lookup/GetYears/{key}";
        public const string GetmakesLookup = "api/Lookup/Getmakes/{key}";
        public const string GetModelLookup = "api/Lookup/GetModel/{key}?year={year}&make={make}";
        public const string GetVehicle = "api/Vehicle/Get/{key}/{id}?isDelete={isDelete}&isEdit={isEdit}";
        public const string PostVehicle = "api/Vehicle/Post/{key}/{id}";
        public const string PutVehicle = "api/Vehicle/Put/{key}/{id}";
        public const string DeleteVehicle = "api/Vehicle/Delete/{key}/{id}";
        public const string GetDriver = "api/Driver/Get/{key}/{id}";
        public const string GetCustomer = "api/Customer/Get/{key}/{id}";
    }
}