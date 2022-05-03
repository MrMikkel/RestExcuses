using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses
{
    public class Secret
    {
        // connection string ligger i sin egen fil så den kan holdes "secret" og ikke uploades i github (den er dog blevet uploaded)
        public static readonly string ConnectionString = "Server=tcp:mvsrestapi.database.windows.net,1433;Initial Catalog=RESTAPI;Persist Security Info=False;User ID=mathiasvinthersoendergaard;Password=Undskyldninger!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
