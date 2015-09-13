using System;
using StructureMap;

namespace APP
{
    public static class IOC
    {
        private static readonly  IContainer _container=new Container();
        private static object syncRoot = new Object();

        public static IContainer GetContainer
        {
            get
            {
               
                return _container;
            }

        }
    }



}