using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoItems.Data;
using ToDoItemsApp.Models;

namespace ToDoItemsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? categoryId)
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            ToDoItemsListViewModel vm = new ToDoItemsListViewModel();
            if (categoryId == null || categoryId == 0)
            {
                vm.ToDoItems = db.GetAll();
            }
            else
            {
                vm.ToDoItems = db.GetItemsForCategory(categoryId.Value);
            }
            vm.Categories = db.GetCategories();
            vm.SelectedCategory = categoryId;
            return View(vm);
        }

        public ActionResult NewCategory()
        {
            return View();
        }

        public ActionResult NewTask()
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            NewTaskViewModel vm = new NewTaskViewModel();
            vm.Categories = db.GetCategories();
            return View(vm);
        }

        public ActionResult ViewTask(int id)
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            var vm = new ViewItemViewModel { ToDoItem = db.GetItem(id) };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddTask(ToDoItem item, int categoryId)
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            item.Completed = false;
            db.AddTask(item, categoryId);
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult AddCategory(string name)
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            db.AddCategory(name);
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult SetCompleted(int id)
        {
            ToDoItemsDb db = new ToDoItemsDb(Properties.Settings.Default.ConStr);
            db.SetCompleted(id);
            return Redirect("/");
        }
    }
}