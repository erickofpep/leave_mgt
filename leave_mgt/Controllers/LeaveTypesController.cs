using AutoMapper;
using leave_mgt.Contracts;
using leave_mgt.Data;
using leave_mgt.Models;
using Microsoft.AspNetCore.Mvc;

namespace leave_mgt.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypesController1
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);
            return View(model);

        }

        // GET: LeaveTypesController1/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        public ILeaveTypeRepository Get_repo()
        {
            return _repo;
        }

        // POST: LeaveTypesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {

                return NotFound();

            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                var isSuccess = _repo.Update(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
        }

        // GET: LeaveTypesController1/Delete/5
        public ActionResult Delete(int id)
        {
            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(leavetype);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
            /*
             if (!_repo.isExists(id))
             {
                 return NotFound();
             }
             var leavetype = _repo.FindById(id);
             var model = _mapper.Map<LeaveTypeVM>(leavetype);
             return View(model);

             */
        }

        // POST: LeaveTypesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                // TODO: Add delete logic here
                var leavetype = _repo.FindById(id);
                if (leavetype == null)
                {
                    return NotFound();
                }

                var isSuccess = _repo.Delete(leavetype);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}