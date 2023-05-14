using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IOrder:IDao<Order>
    {
        int InsertAvanced(Order t, List<OrderSpare> sp);
    }
}
