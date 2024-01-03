using BridgeEditViewMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Pipes;
using BridgeEditViewMVC.Entities;
using System.Reflection;

namespace BridgeEditViewMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var item = new Book() {Id = 1, Author = "Jara", Price = 222, Publisher = "MediaX", Title = "Holoubci"};

            //var item = new Toy() { Name = "Babka", Color = "Pink", Description = "Panther", Price = 333 };

            var formItems = new List<FormItem>();
            var type = item.GetType();

            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                var formItem = new FormItem(prop.Name, prop.GetValue(item)?.ToString() ?? "", prop.PropertyType.Name);
                formItems.Add(formItem);
            }

            //TODO - view model is dynamic;
            // show model properties from type reflection
            // edit - select control based on reflection type (string/integer etc)
            // POST method must also use reflection

            //TODO: use entity and entityviewmodel (avoid viewbag, viewdata)
            //TODO: granular view based on access 

            ViewBag.TypeName = type.AssemblyQualifiedName;

            return View(formItems);
        }

        [HttpPost]
        public IActionResult Save(List<FormItem> formItems)
        {
            //TODO resolve persistence - create DB, table, store Items
            ViewBag.TypeName = Request.Form["typeName"];
            var item = ObjFactory.GetObjectWithoutSwitch(formItems, ViewBag.TypeName);
            return View("Index", formItems);
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


    }

    public static class ObjFactory
    {
        public static object GetObject(List<FormItem> formItems, string typeName)
        {
            switch (typeName)
            {
                case "Book":
                    var book = new Book()
                    {
                        Id = Int32.Parse(formItems.First(i => i.PropertyName == "Id").PropertyValue),
                        Author = formItems.First(i=> i.PropertyName=="Author").PropertyValue,
                        Price = Int32.Parse(formItems.First(i => i.PropertyName == "Price").PropertyValue),
                        Publisher = formItems.First(i => i.PropertyName == "Publisher").PropertyValue,
                        Title = formItems.First(i => i.PropertyName == "Title").PropertyValue,
                    };
                    return book;
                default:
                    throw new NotImplementedException();
            }
        }

        public static object GetObjectWithoutSwitch(List<FormItem> formItems, string typeName)
        {
            var t = Type.GetType(typeName);
            var instance = Activator.CreateInstance(t);
            var properties = t.GetProperties();

            foreach (var formItem in formItems)
            {
                var property = properties.First(p => p.Name == formItem.PropertyName);

                switch (formItem.PropertyType)
                {
                    case "String":
                        property.SetValue(instance, formItem.PropertyValue);
                        break;

                    case "Int32":
                        property.SetValue(instance, Int32.Parse(formItem.PropertyValue));
                        break;
                }
            }

            return instance!;
        }
    }
}