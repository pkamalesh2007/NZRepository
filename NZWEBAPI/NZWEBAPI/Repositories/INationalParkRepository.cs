using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface INationalParkRepository
    {
        public  IEnumerable<NationalPark> GetNationalParks();

        public NationalPark GetNationalPark(int id);

        public bool NationalParkExists(string name);

        public bool NationalParkExists(int id);

        public bool CreateNationalParks(NationalPark nationalPark);

        public bool UpdateNationalPark(NationalPark nationalPark);

        public bool DeleteNationalPark(NationalPark nationalPark);

        public bool Save();


    }
}
