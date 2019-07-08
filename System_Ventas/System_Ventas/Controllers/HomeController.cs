using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System_Ventas.Models;

namespace System_Ventas.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            CreateRoles(serviceProvider);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            String mensaje;
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                String[] rolesName = { "Admin", "User", "Invitado" };
                foreach (var item in rolesName)
                {
                    var roleExist = await roleManager.RoleExistsAsync(item);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                }
                var user = await userManager.FindByIdAsync("15c95f3a-652b-4315-bb22-05a49400b90c");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            
        }

        private async Task Tareas()
        {
            Thread.Sleep(20 * 1000);
            String tarea = "Tarea finalizada...";
        }
    }
}
