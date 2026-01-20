using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record ReviewGetRequest(
        string id,
        string UserName,
        string BookTitle,
        int Rating,
        string Comment,
        DateOnly PostedDate);
}
