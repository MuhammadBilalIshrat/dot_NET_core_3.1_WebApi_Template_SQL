using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Abstraction
{
    public interface IDbStratrgy
    {
        // seeding the database with necessary schema and data changes
        void SeedDatabase();
        // Get Connection to the Db
        DbConnection Connection { get; }
    }
}
