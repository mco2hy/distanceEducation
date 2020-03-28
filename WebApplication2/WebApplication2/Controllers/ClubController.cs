using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClubController : Controller
    {
        private readonly DataContext _dataContext;
        public ClubController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/club/getclub/{id:int}")]
        public IActionResult GetClub(int id)
        {
            if (id != 0)
            {
                Club club = _dataContext.Clubs
                    .Include(a => a.ClubColors)
                    .SingleOrDefault(a => a.Id == id);

                return new JsonResult(club);
            }
            else
            {
                return new JsonResult(new Club());
            }            
        }

        public IActionResult GetClubs()
        {
           List<Club> clubs = _dataContext.Clubs.ToList();

            return new JsonResult(clubs); //restful webservice
        }
        // /club/manageclub/0 => Yeni kayıt ekleyeceği
        // /club/manageclub/123 => Eski kayıt düzenlenecek
        // /club/manageclub => Yeni kayıt ekleyeceği        
        //[Route("/club/manageclub")]
        [Route("/club/manageclub/{id:int}")]
        public IActionResult ManageClub(int id)
        {
            return View(id);
        }
        public IActionResult ManageClubAction([FromBody] DTOs.ManageClubDto addClub) 
        {
            if (addClub.Id != 0)
            {
                Club club = _dataContext.Clubs
                    .Include(a => a.ClubColors)
                    .SingleOrDefault(a => a.Id == addClub.Id);

                club.Value = addClub.Value;
                club.Name = addClub.Name;

                club.ClubColors.Clear();

                foreach (int colorId in addClub.ClubColors)
                {
                    Color color = _dataContext.Colors
                        .SingleOrDefault(a => a.Id == colorId);
                    club.ClubColors.Add(new ClubColor()
                    {
                        Color = color,
                        Club = club
                    });
                }

                return new JsonResult("?");
            }
            else
            {
                Models.Club club = new Club()
                {
                    Name = addClub.Name,
                    Value = addClub.Value
                };

                foreach (int colorId in addClub.ClubColors)
                {
                    ClubColor clubColor = new ClubColor()
                    {
                        Club = club,
                        ColorId = colorId
                    };

                    _dataContext.ClubColors.Add(clubColor);
                }
                _dataContext.Clubs.Add(club);
                _dataContext.SaveChanges();

                return new JsonResult(club);
            }
            
        }
    }
}