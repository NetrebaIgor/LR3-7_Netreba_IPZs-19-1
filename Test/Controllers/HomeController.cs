using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.Models;
using System.Web;
using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Test.Controllers
{
    public class HomeController : Controller
    {


        private DataContext db;


        public HomeController(DataContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); 

                    return RedirectToAction("Index", user);
                }
                ModelState.AddModelError("", "Некоректні логін і(або) пароль");
            }
            return View(model);
        }



        

        [HttpGet]
       

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {

                    user = new User
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.Name,
                        Surname = model.Surname,
                        Petronymic = model.Petronymic,
                        Phone = model.Phone,
                        RoleId = 2
                    };
                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    

                    return RedirectToAction("Login", "Home");
                }
                else
                    ModelState.AddModelError("", "Невірні введені дані");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
           
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
       
        public IActionResult Index(User user)
        {
            ViewBag.Id = user.Id;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }





        public async Task<IActionResult> Cars(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    ViewBag.User = user;
                    ViewBag.NSF = user.Surname.ToString() + " " + user.Name.ToString() + " " + user.Petronymic.ToString();
                    return View();
                }
                else
                    return View();
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {

            db.Users.Update(user);
            await db.SaveChangesAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Cars(InsuranceСar car)
        {

            if (ModelState.IsValid)
            {
                InsuranceСar cars = await db.Cars.FirstOrDefaultAsync(u => u.NSF == car.NSF);
                if (cars == null)
                {
                    db.Cars.Add(car);
                    await db.SaveChangesAsync();
                }

            }

           
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Medics(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    ViewBag.User = user;
                    ViewBag.NSF = user.Surname.ToString() + " " + user.Name.ToString() + " " + user.Petronymic.ToString();
                    return View();
                }
                else
                    return View();
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Medics(InsuranceMedic medic)
        {
            if (ModelState.IsValid)
            {
                InsuranceMedic medics = await db.Medic.FirstOrDefaultAsync(u => u.NSF == medic.NSF);
                if (medics == null)
                {
                    db.Medic.Add(medic);
                    await db.SaveChangesAsync();
                }
               
            }
           
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AutoCitizen(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    ViewBag.User = user;
                    ViewBag.NSF = user.Surname.ToString() + " " + user.Name.ToString() + " " + user.Petronymic.ToString();
                    return View();
                }
                else
                    return View();
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AutoCitizen(InsuranceAutoCitizen auto)
        {

            if (ModelState.IsValid)
            {
                InsuranceAutoCitizen autos = await db.AutoCitizens.FirstOrDefaultAsync(u => u.NSF == auto.NSF);
                if (autos == null)
                {
                    db.AutoCitizens.Add(auto);
                    await db.SaveChangesAsync();
                }

            }
           
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> COVID(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    ViewBag.User = user;
                    ViewBag.NSF = user.Surname.ToString() + " " + user.Name.ToString() + " " + user.Petronymic.ToString();
                    return View();
                }
                else
                    return View();
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> COVID(InsuranceCOVID covid)
        {

            if (ModelState.IsValid)
            {
                InsuranceCOVID COVID = await db.COVID.FirstOrDefaultAsync(u => u.NSF == covid.NSF);
                if (COVID == null)
                {
                    db.COVID.Add(covid);
                    await db.SaveChangesAsync();
                }

            }

            
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> RemoveCar()
        {
            return View(await db.Cars.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCar(int? id)
        {
            if (id != null)
            {
                InsuranceСar car = await db.Cars.FirstOrDefaultAsync(p => p.Id == id);
                if (car != null)
                {
                    db.Cars.Remove(car);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> RemoveAuto()
        {
            return View(await db.AutoCitizens.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAuto(int? id)
        {
            if (id != null)
            {
                InsuranceAutoCitizen AutoCitizens = await db.AutoCitizens.FirstOrDefaultAsync(p => p.Id == id);
                if (AutoCitizens != null)
                {
                    db.AutoCitizens.Remove(AutoCitizens);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> RemoveCOVID()
        {
            return View(await db.COVID.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCOVID(int? id)
        {
            if (id != null)
            {
                InsuranceCOVID COVID = await db.COVID.FirstOrDefaultAsync(p => p.Id == id);
                if (COVID != null)
                {
                    db.COVID.Remove(COVID);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> RemoveMedic()
        {
            return View(await db.Medic.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMedic(int? id)
        {
            if (id != null)
            {
                InsuranceMedic Medic = await db.Medic.FirstOrDefaultAsync(p => p.Id == id);
                if (Medic != null)
                {
                    db.Medic.Remove(Medic);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
