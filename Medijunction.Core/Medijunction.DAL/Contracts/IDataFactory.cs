using System;
using System.Collections.Generic;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface IDataFactory
    {
        T GetData<T>() where T : IData;
    }
}
