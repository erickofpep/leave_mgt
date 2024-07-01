using leave_mgt.Data;

namespace leave_mgt.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        ICollection<LeaveAllocation> GetEmployeesByLeaveType(int id);
    }
}
