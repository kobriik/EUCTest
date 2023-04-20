using EUCTest.Models;
using EUCTest.Utils;
using EUCTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace EUCTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly EucDatabaseContext _db;
        private readonly IStringLocalizer _localizer;

        public HomeController(EucDatabaseContext db, IStringLocalizerFactory factory)
        {
            _db = db;
            _localizer = factory.Create("EucTest", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        [HttpGet]
        public IActionResult Index()
        {
            BindStaticData();
            return View(new PersonVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PersonVm personVm)
        {
            if (!ModelState.IsValid)
            {
                BindStaticData();
                return View(personVm);
            }

            var newItem = new Person()
            {
                FirstName = personVm.FirstName,
                LastName = personVm.LastName,
                Birthdate = personVm.Birthdate.Value,
                CountryId = int.Parse(personVm.CountryId),
                Email = personVm.Email,
                GdprAgree = personVm.GdprAgree,
                IdentityNumber = personVm.IdentityNumber,
                SexId = personVm.SexId
            };

            _db.People.Add(newItem);
            _db.SaveChanges();
            return RedirectToAction("Get", "Values", new { id = newItem.Id });
        }

        private void BindStaticData()
        {
            ViewBag.Send = _localizer["Send"];
            ViewBag.SexList = StaticData.GetSexList(_localizer);
            ViewBag.CountryList = StaticData.GetCountryList(_db);
            ViewBag.EntryForm = _localizer["EntryForm"];
        }

    }
}