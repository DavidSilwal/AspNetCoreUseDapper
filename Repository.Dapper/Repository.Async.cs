using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper
{
    public partial class Repository<T> : IRepository<T> where T : class, new()
    {
    }
}
