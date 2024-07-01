using leave_mgt.Data;

namespace leave_mgt.Contracts
{
    public interface ILeaveHistoryRepository : IRepositoryBase<LeaveHistory>
    {
        ICollection<LeaveHistory> GetEmployeesByLeaveType(int id);
    }
}
