using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using RosterApp.Models;

namespace RosterApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly RosterContext _context;

    public HomeController(ILogger<HomeController> logger, RosterContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Route for int of month
    [Route("Home/Calendar/{month:int}")]
    public IActionResult Calendar(int? month)
    {
        if (month == null ||month < 1 ||month > 12)
        {
            month = DateTime.Now.Month;
        }

        return View(month);
    }

    public IActionResult Employees()
    {
        var allExpenses = _context.Employees.ToList();

        return View(allExpenses);
    }
    public IActionResult CreateEditEmployee(int? Id)
    {
        if (Id != null)
        {
            //If not null, it means editing something. Load employee by ID
            var employeeInDb = _context.Employees.SingleOrDefault(employee => employee.Id == Id);
            return View(employeeInDb);
        }


        return View();
    }

    public IActionResult DeleteEmployee(int id)
    {
        var employeeInDb = _context.Employees.SingleOrDefault(employee => employee.Id == id);
        _context.Employees.Remove(employeeInDb);
        _context.SaveChanges();

        return RedirectToAction("Employees");
    }

    public IActionResult CreateEditEmployeeForm(Employee model)
    {
        if (model.Id == 0)
        {
            //If no ID, creating one
            _context.Employees.Add(model);
        } else
        {
            //If there is, then we are editing something
            _context.Employees.Update(model);
        }

        _context.SaveChanges();

        return RedirectToAction("Employees");
    }
    public IActionResult Index()
    {
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
}
