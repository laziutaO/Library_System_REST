using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReserveRepository: IBaseRepository<Reservation>
    {
        int CheckReservationsCount(Guid userId);
    }
}
