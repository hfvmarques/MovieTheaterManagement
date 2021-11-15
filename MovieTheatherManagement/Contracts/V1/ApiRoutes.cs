using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Movies
        {
            public const string GetAll = Base + "/movies";

            public const string Update = Base + "/movies/{movieId}";

            public const string Delete = Base + "/movies/{movieId}";

            public const string Get = Base + "/movies/{movieId}";

            public const string Create = Base + "/movies";
        }
    }
}
