using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Add(T Element);

        T Get(long Id);
        List<T> GetAll();
    }
}
