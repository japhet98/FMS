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
        FMSEntities db;
        public ShippingDetailController()
        {
            db = new FMSEntities();
        }

        //Add Shipping Arrival
        
        public void AddShipping(ArrivedBoatDetail ship)
        {
            db.ArrivedBoatDetails.Add(ship);
            db.SaveChanges();
        }

        // Update shipping Arrival 
        public void EditShipping(ArrivedBoatDetail ship)
        {
            ship = db.ArrivedBoatDetails.FirstOrDefault(sh => sh.shippingId == ship.shippingId);
            if(ship != null)
            {
                db.Entry(ship).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Shipping Id not found");
            }
        }

        // Retrieve Single ShippingDetail
        public List<ArrivedBoatDetail> GetShipping(string shippingId)
        {
            return db.ArrivedBoatDetails.Where(ship => ship.shippingId == shippingId).ToList();
        }

        //Retrieve All Shipping Detail

        public List<ArrivedBoatDetail> GetShipping()
        {
            return db.ArrivedBoatDetails.ToList();
        }

        // Remove Shipping Detail

        public void DeleteShipping(string shippingId)
        {
            var ship = db.ArrivedBoatDetails.FirstOrDefault(sh => sh.shippingId == shippingId);
            
            if(ship != null)
            {
                db.Entry(ship).State = EntityState.Deleted;
            }

            else
            {
                throw new Exception("Shipping Id not found");
            }
        }
    }
}
