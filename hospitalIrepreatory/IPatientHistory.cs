using Dataaccesslayer;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
    public interface IPatientHistory : IGenericRepository<PatientHistoryVm> , IPaginationHelper<PatientHistoryVm>
    {
        IEnumerable<PatientHistoryVm>
 GetallPatientHistory(string id);

    }


}