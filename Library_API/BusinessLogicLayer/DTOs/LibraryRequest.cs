using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record struct LibraryRequest(
        string Name,
        string Address,
        string Phone,
        List<string> Books);

}
