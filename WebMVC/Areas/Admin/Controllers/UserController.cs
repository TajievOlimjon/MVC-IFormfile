using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.Models;
using WebMVC.Areas.Admin.Services;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService )
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listOfusers = userService.GetUsers();
            return View(listOfusers);
        }

        

        // GET: UserController/Create
        [HttpGet]
        public ActionResult Add()
        {
            return View(new User());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userService.Add(user);
                    return RedirectToAction(nameof(Index));

                }
                return View(user);
            }
            catch
            {
                return View("Error!!!!");
            }
           
        }

        // GET: UserController/Edit/
        public ActionResult Edit(int Id)
        {
            var user = userService.GetUserById(Id);
            return View(user);
        }

        // POST: UserController/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid ==false)
                {
                    return View(user);
                }
                userService.Edit(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error !! not edit user ");
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user )
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(user);
                }
                var u = userService.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error !!! not delete user ");
            }
           
        }

    }
}
