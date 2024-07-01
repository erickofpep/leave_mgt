using leave_mgt.Data;

namespace leave_mgt.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {

        ICollection<LeaveType> GetEmployeesByLeaveType(int id);

    }
}
