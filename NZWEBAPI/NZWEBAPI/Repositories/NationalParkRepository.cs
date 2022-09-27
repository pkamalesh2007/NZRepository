using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly NZDBContext db;

        public NationalParkRepository(NZDBContext db)
        {
            this.db = db;
        }
        public bool CreateNationalParks(NationalPark nationalPark)
        {
            db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int Id)
        {
           return db.NationalParks.FirstOrDefault(x => x.Id == Id); 


        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return db.NationalParks.OrderBy(s => s.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = db.NationalParks.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());

            return value;
        }

        public bool NationalParkExists(int id)
        {
            bool value= db.NationalParks.Any(x => x.Id == id);
            return value;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0? true:false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
