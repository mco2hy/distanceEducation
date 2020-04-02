using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileBasedDatabase.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FileBasedDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BaseDatabase baseDatabase = Helper.JsonHelper.GetDatabase();
            return View(baseDatabase);
        }
        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult GetBaseDatabase()
        {
            return new JsonResult(Helper.JsonHelper.GetDatabase());
        }
        public IActionResult SetLibraryProperties([FromBody]Data.DTOs.LibraryPropertiesDto libraryProperties)
        {
            var baseDatabase = Helper.JsonHelper.GetDatabase();
            baseDatabase.Name = libraryProperties.Name;
            baseDatabase.Address = libraryProperties.Address;
            baseDatabase.Capacity = libraryProperties.Capacity;
            Helper.JsonHelper.SetDatabase(baseDatabase);

            return new JsonResult(baseDatabase);
        }

        [Route("/home/managevisitor/{id}")]
        public IActionResult ManageVisitor(Guid id)
        {
            ViewBag.Id = id;
            return View(Helper.JsonHelper.GetDatabase());
        }

        [Route("/home/managebook/{id}")]
        public IActionResult ManageBook(Guid id)
        {
            ViewBag.Id = id;
            return View(Helper.JsonHelper.GetDatabase());
        }

        public IActionResult SetVisitor([FromBody]Data.DTOs.VisitorDto visitor)
        {
            var baseDatabase = Helper.JsonHelper.GetDatabase();

            if (visitor.Id == Guid.Empty)  //yeni kayıt
            {
                var visitorEntity = new Data.Entities.Visitor()
                {
                    Name = visitor.Name,
                    Surname = visitor.Surname,
                    Id = Guid.NewGuid()
                };
                baseDatabase.Visitors.Add(visitorEntity);
                Helper.JsonHelper.SetDatabase(baseDatabase);

            }
            else // güncelleme
            {
                var visitorEntity = baseDatabase.Visitors.SingleOrDefault(a => a.Id == visitor.Id);
                if (visitorEntity != null)
                {
                    visitorEntity.Name = visitor.Name;
                    visitorEntity.Surname = visitor.Surname;
                    Helper.JsonHelper.SetDatabase(baseDatabase);
                }
            }

            return new JsonResult(baseDatabase);
        }
    }
}