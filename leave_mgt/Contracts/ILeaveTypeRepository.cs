using leave_mgt.Data;
using leave_mgt.Models;

namespace leave_mgt.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        object LeaveTypes { get; }

        void Create(LeaveTypeVM leaveType);
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
        bool isExists(int id);
        void SaveChanges();
    }
}
