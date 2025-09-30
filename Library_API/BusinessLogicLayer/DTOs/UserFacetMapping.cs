using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facet;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class UserFacetMapping{

        [Facet(typeof(User), exclude: new[] { nameof(User.HashedPassword)})]
        public partial record UserGetRequest { }

    }
}
