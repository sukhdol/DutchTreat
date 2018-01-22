using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly DutchContext _context;
        private readonly IMailService _mailService;

        public AppController(DutchContext context,IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
//            throw new InvalidOperationException("bad things happened!");

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send the email

                _mailService.SendMessage("sukh.dol77@gmail.com",
                    model.Subject,
                    $"From: {model.Name} - {model.Email}, Message: {model.Message}");

                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // show errors
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
        }
    }
}
