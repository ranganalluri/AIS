using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceModels.Models;

namespace APP.Hypermedia
{
    public static class UrlHelper
    {
        public static Link AddCustomerNodeUrl()
        {
            return new Link(){Href = UrlConstants.PostCustomer,Rel = "",Title = "Customer"};
        }
        public static Link GetCustomerNodeUrl()
        {
            return new Link() { Href = UrlConstants.GetCustomer, Rel = "", Title = "Customer" };
        }
        public static Link GetvehicleLink()
        {
            return new Link() { Href = UrlConstants.GetVehicle, Rel = "", Title = "Vehicle" };
        }
        public static Link PostvehicleLink()
        {
            return new Link() { Href = UrlConstants.PostVehicle, Rel = "", Title = "Vehicle" };
        }
        public static Link GetDriverLink()
        {
            return new Link() { Href = UrlConstants.GetDriver, Rel = "", Title = "Driver" };
        }
        public static Link PosDriverLink()
        {
            return new Link() { Href = UrlConstants.PostDriver, Rel = "", Title = "Driver" };
        }
        public static List<Link> GetVehiclelookups()
        {
            var list = new List<Link>();
            list.Add(new Link() { Href = UrlConstants.GetYearsLookup, Rel = "", Title = "vehicleLookup" });
            list.Add(new Link() { Href = UrlConstants.GetmakesLookup, Rel = "", Title = "vehicleLookup" });
            list.Add(new Link() { Href = UrlConstants.GetModelLookup, Rel = "", Title = "vehicleLookup" });
            return list;
        }
    }
}