using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public record LibraryRequest(
        string id,
        string description,
        string coverImageUrl,
        string name,
        string address,
        string phone,
        List<string> books);

}
