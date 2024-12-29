using Assignment3_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_.Controllers
{
    public class DepartmentController : Controller
    {
        private List<Department> departments = new List<Department>
        {
            new Department { Id = 1, Name = "Computer Science" },
            new Department { Id = 2, Name = "Management" },
            new Department { Id = 3, Name = "Maths" }
        };

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Saugat", DepartmentId = 1 },
            new Employee { Id = 2, Name = "Satish", DepartmentId = 2 },
            new Employee { Id = 3, Name = "Ramesh", DepartmentId = 3 },
            new Employee { Id = 4, Name = "Shuvam", DepartmentId = 1 },
            new Employee { Id = 5, Name = "Navaraj", DepartmentId = 2 }
        };


        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee obj)
        {
            if (ModelState.IsValid)
            {   
                //If every validaition is valid then add the employee to the list and then go back to Index and display the new list of employees.
                employees.Add(obj);
                return RedirectToAction("Index");
            }
            //Invalid vaye chai tyo invalid employee ko details lagera pheri Add.cshtml mai return garaune to show the validation erros.
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the employee by Id
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
                //Employee id na vete return 404 not found. Express ko res.status(404).send("Not found").
            }
            return View(employee); //id bata aako employe lai send to Edit view.
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj); 
            }

            // Tyo employee lai id le find garera return to Index afet updating.
            var employee = employees.FirstOrDefault(e => e.Id == obj.Id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = obj.Name;
            employee.DepartmentId =obj.DepartmentId;

            return RedirectToAction("Index");
        }
    }
}

