using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    public class ShippingDetailController
    {
        FMSEntities _db;
        public ShippingDetailController()
        {
            _db = new FMSEntities();
        }

        //Add Shipping Arrival
        public void AddShipping(Shipping shipping)
        {
            _db.Shippings.Add(shipping);
            _db.SaveChanges();
        }

        public void UpdateShipping(Shipping shipping)
        {
            shipping = _db.Shippings.FirstOrDefault(cust => cust.ShippingId == shipping.ShippingId);
            _db.Entry(shipping).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteShipping(Shipping shipping)
        {
            shipping = _db.Shippings.FirstOrDefault(cust => cust.ShippingId == shipping.ShippingId);
            if (shipping != null)
            {
                _db.Entry(shipping).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Shipping Id cannot be found");
            }
        }

        public Shipping GetShippings(int ShippingId)
        {
            return _db.Shippings.FirstOrDefault(cust => cust.ShippingId == ShippingId);
        }
        public List<Shipping> GetShippings()
        {
            return _db.Shippings.ToList();
        }

    }
}
