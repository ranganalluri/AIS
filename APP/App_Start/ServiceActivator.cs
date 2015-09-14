using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using APP.Navigation;
using StructureMap;
namespace APP
{
    public class StructureMapWebApiServiceActivator : IHttpControllerActivator
    {
        //private readonly IContainer _container;

        //public StructureMapWebApiServiceActivator(IContainer container)
        //{
        //    this._container = container;
        //}

        IHttpController IHttpControllerActivator.Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {

            return (IHttpController)IOC.GetContainer.GetInstance(controllerType);
        }
    }
}