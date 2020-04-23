
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
  public  class FishTypeController
    {
        private FMSEntities _db;

        public FishTypeController()
        {
            _db = new FMSEntities();
        }

        public void AddFish(Fish fish)
        {
            _db.Fish.Add(fish);
            _db.SaveChanges();
        }

        public void UpdateFish(Fish fish)
        {
            fish = _db.Fish.FirstOrDefault(cust => cust.FishId == fish.FishId);
            _db.Entry(fish).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteFish(Fish fish)
        {
            fish = _db.Fish.FirstOrDefault(cust => cust.FishId == fish.FishId);
            if (fish != null)
            {
                _db.Entry(fish).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Fish Id cannot be found");
            }
        }

        public Fish GetFishs(int FishId)
        {
            return _db.Fish.FirstOrDefault(cust => cust.FishId == FishId);
        }
        public List<Fish> GetFishs()
        {
            return _db.Fish.ToList();
        }
    }
}
