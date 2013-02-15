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
    public partial class TeamController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();

        public virtual ActionResult Index()
        {
            var teams = _db.Teams
               .Include(x => x.Employees)
               .OrderBy(x => x.Name);

            var viewModel = Mapper.Map<IEnumerable<Team>, IEnumerable<IndexTeamViewModel>>(teams);

            return View(viewModel);
        }

        public virtual ActionResult Create()
        {
            var viewModel = new EditTeamViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(EditTeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var team = Mapper.Map<EditTeamViewModel, Team>(viewModel);
                team.CreatedAt = DateTime.Now;

                _db.Teams.Add(team);
                _db.SaveChanges();

                return RedirectToAction(MVC.Team.Index());
            }
            else
            {
                return View(viewModel);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            var team = _db.Teams
                .Find(id)
                .Throw404IfNull();

            var viewModel = Mapper.Map<Team, EditTeamViewModel>(team);

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(EditTeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var team = _db.Teams
                    .Find(viewModel.Id)
                    .Throw404IfNull();

                team = Mapper.Map<EditTeamViewModel, Team>(viewModel, team);
                _db.SaveChanges();

                return RedirectToAction(MVC.Team.Index());
            }
            else
            {
                return View(viewModel);
            }
        }

        public virtual ActionResult Delete(int id)
        {
            var team = _db.Teams
                .Include(x => x.Employees)
                .SingleOrDefault(x => x.Id == id)
                .Throw404IfNull();

            if (!team.Employees.Any())
            {
                _db.Teams.Remove(team);
                _db.SaveChanges();
            }

            return RedirectToAction(MVC.Team.Index());
        }
    }
}
