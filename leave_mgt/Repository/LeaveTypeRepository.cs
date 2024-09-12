using leave_mgt.Contracts;
using leave_mgt.Data;
using leave_mgt.Models;

namespace leave_mgt.Repository
{

    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public object LeaveTypes => throw new NotImplementedException();

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public void Create(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
            /*
             OR
            return _db.LeaveTypes.ToList();
             */

            //throw new NotImplementedException();
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;

            //throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            /*
             check if LeaveType table is empty or not and if (there is an Id that matches the paremeter "id",
            then return true or false
             */
            var exists = _db.LeaveTypes.Any(q => q.Id == id);
            return exists;

            //throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;

            //_db.SaveChanges();

            //throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }
    }
}
