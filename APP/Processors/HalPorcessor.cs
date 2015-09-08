using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Http.Routing;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;


namespace APP.Processors
{
    public  class HalPorcessor
    {
        private ContextResource _context;
        private readonly PageType _pageType;
        internal string ApiHost;
        private string _key;
        private  PolicyContainer _ploicy;
        private readonly UrlHelper _uriHelper;
        public HalPorcessor(ContextResource context,PageType pageType, string apiHost, string key,UrlHelper helper)
        {
            _context = context;
            _pageType = pageType;
            this.ApiHost = apiHost;
            this._key = key;
            _uriHelper = helper;
        }

        public List<Link> FillInitialHalList()
        {

            var link = _uriHelper.Link("DefaultApi", new { controller = "Customer", key = _key, }); //string.Format("{0}api/Customer/{1}", ApiHost, new Guid(_key));
           // link = link.Replace("Customer", "Customer/icliq/" + _key);
            var links = new List<Link>
                       {
                           new Link()
                           {
                               
                               Title = "next customer",
                               Href = link,
                               Rel = "self"
                                                              
                           },
                            new Link()
                           {
                               Title = "recall",
                               Href = link
                           }
                       };
            return links;
        }

        public  void FillLookups()
        {
            switch (_pageType)
            {
                case PageType.Initial:
                    
                    break;
                case PageType.Customer:

                    break;
                case PageType.Vehicle:
                    break;
                case PageType.Driver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public  List<Link> BuildHalResource()
        {
            var list = new List<Link>();
            switch (_pageType)
            {
                case PageType.Initial:

                break;
                case PageType.Customer:
                    var link = _uriHelper.Link("DefaultApiAction", new {controller = "Customer", action = "Get", id = ""});
                    link = link.Replace("Customer", "Customer/icliq" + _key);
                    list.Add(new Link(){Href = link,Title = "customer",Rel = "self"});

                    //has vehicle node foreach vehicel
                    var vehicleLink = _uriHelper.Link("DefaultApiAction", new { controller = "Vehicle", action = "Get", id = "" }); 

                    break;
                case PageType.Vehicle:
                    break;
                case PageType.Driver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return list;

        }
    }
}