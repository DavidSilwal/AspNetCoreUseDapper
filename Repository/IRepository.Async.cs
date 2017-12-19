using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public partial interface IRepository<T> where T : class, new()
    {
    }
}
