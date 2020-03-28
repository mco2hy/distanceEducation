using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ColorController : Controller
    {
        private readonly DataContext _dataContext;
        public ColorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult GetColors()
        {
            List<Color> colors = _dataContext.Colors.ToList();
            
            return new JsonResult(colors);
        }
    }
}