using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class FishOrderController
    {
        FMSEntities _db;

        public FishOrderController()
        {
            _db = new FMSEntities();
        }

        public void AddFishOrder(FishOrder order)
        {
            _db.FishOrders.Add(order);
            _db.SaveChanges();
        }

        public void UpdateFishOrder(FishOrder order)
        {
            order = _db.FishOrders.FirstOrDefault(cust => cust.orderId == order.orderId);
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteFishOrder(FishOrder order)
        {
            order = _db.FishOrders.FirstOrDefault(cust => cust.orderId == order.orderId);
            if (order != null)
            {
                _db.Entry(order).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("FishOrder Id cannot be found");
            }
        }

        public FishOrder GetFishOrders(int FishOrderId)
        {
            return _db.FishOrders.FirstOrDefault(cust => cust.orderId == FishOrderId);
        }
        public List<FishOrder> GetFishOrders()
        {
            return _db.FishOrders.ToList();
        }
    }
}
