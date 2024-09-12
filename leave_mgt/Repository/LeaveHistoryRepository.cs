using leave_mgt.Contracts;
using leave_mgt.Data;

namespace leave_mgt.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LeaveHistory = _db.LeaveHistories.ToList();
            return LeaveHistory;

            //throw new NotImplementedException();
        }

        public LeaveHistory FindById(int id)
        {
            var LeaveHistory = _db.LeaveHistories.Find(id);
            return LeaveHistory;

            //throw new NotImplementedException();
        }

        public ICollection<LeaveHistory> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            /*
             check if LeaveHistory table is empty or not and if (there is an Id that matches the paremeter "id",
            then return true or false
             */
            var exists = _db.LeaveHistories.Any(q => q.Id == id);
            return exists;

            //throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;

            //throw new NotImplementedException();
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            //Save
            return Save();

            //throw new NotImplementedException();
        }
    }
}
