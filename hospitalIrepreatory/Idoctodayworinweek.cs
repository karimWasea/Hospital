using hospitalUtilities;
using hospitalVm;

namespace hospitalIrepreatory
{
    public interface Idoctodayworinweek : IGenericRepository<DoctorDayworkVM>
    {
       // IEnumerable<DoctorDayworkVM> Getallstatandendshiftbydoctorbydoctorid(string id);

        //PagedREsult<ContactVm> Getallpag(int pagnumber, int pagesize);
       // public IEnumerable<DoctorDayworkVM> getallweekdays(string id)

   IEnumerable<DoctorDayworkVM> getall();
       DoctorDayworkVM getallweekdays( string id);

    }
}


