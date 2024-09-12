using leave_mgt.Contracts;
using leave_mgt.Data;

namespace leave_mgt.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var LeaveAllocation = _db.LeaveAllocations.ToList();
            return LeaveAllocation;

            //throw new NotImplementedException();
        }

        public LeaveAllocation FindById(int id)
        {
            var LeaveAllocation = _db.LeaveAllocations.Find(id);
            return LeaveAllocation;

            //throw new NotImplementedException();
        }

        public ICollection<LeaveAllocation> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            /*
             check if LeaveAllocation table is empty or not and if (there is an Id that matches the paremeter "id",
            then return true or false
             */
            var exists = _db.LeaveAllocations.Any(q => q.Id == id);
            return exists;
            //throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;

            //throw new NotImplementedException();
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }
    }
}
