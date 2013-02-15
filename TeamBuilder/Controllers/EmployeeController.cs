using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamBuilder.Models;
using TeamBuilder.ViewModels;
using System.Data.Entity;

namespace TeamBuilder.Controllers
{
    public partial class EmployeeController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();

        public virtual ActionResult Index()
        {
            var employees = _db.Employees
                .Include(x => x.Team)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName);

            var viewModel = Mapper.Map<IEnumerable<Employee>, IEnumerable<IndexEmployeeViewModel>>(employees);

            return View(viewModel);
        }

        public virtual ActionResult Create()
        {
            var viewModel = new EditEmployeeViewModel();
            viewModel.Teams = GetTeamsAsSelectedListItems();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(EditEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<EditEmployeeViewModel, Employee>(viewModel);

                var team = _db.Teams
                    .Find(viewModel.SelectedTeamId)
                    .Throw404IfNull();

                employee.Team = team;

                _db.Employees.Add(employee);
                _db.SaveChanges();

                return RedirectToAction(MVC.Employee.Index());
            }
            else
            {
                viewModel.Teams = GetTeamsAsSelectedListItems();
                
                return View(viewModel);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            var employee = _db.Employees
                .Find(id)
                .Throw404IfNull();

            var viewModel = Mapper.Map<Employee, EditEmployeeViewModel>(employee);
            viewModel.Teams = GetTeamsAsSelectedListItems();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(EditEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _db.Employees
                    .Find(viewModel.Id)
                    .Throw404IfNull();

                employee = Mapper.Map<EditEmployeeViewModel, Employee>(viewModel, employee);

                var team = _db.Teams
                    .Find(viewModel.SelectedTeamId)
                    .Throw404IfNull();

                employee.Team = team;

                _db.SaveChanges();

                return RedirectToAction(MVC.Employee.Index());
            }
            else
            {
                viewModel.Teams = GetTeamsAsSelectedListItems();

                return View(viewModel);
            }
        }

        public virtual ActionResult Delete(int id, bool redirectToTeam)
        {
            var employee = _db.Employees
                .Find(id)
                .Throw404IfNull();

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            if (redirectToTeam)
            {
                return RedirectToAction(MVC.Team.Index());
            }
            else
            {
                return RedirectToAction(MVC.Employee.Index());
            }
        }

        private IEnumerable<SelectListItem> GetTeamsAsSelectedListItems()
        {
            return _db.Teams
               .OrderBy(x => x.Name)
               .AsEnumerable()
               .Select(x => new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });
        }
    }
}
