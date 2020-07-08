using Medijunction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using DI=Microsoft.Extensions.DependencyInjection;

namespace Medijunction.DAL
{
    public class DataFactory: IDataFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public DataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetData<T>() where T: IData
        {
            var instanceVal = _serviceProvider.GetService(typeof(T));
            if (instanceVal != null)
                return (T)instanceVal;
            else
                return default(T);
        }
    }
}
