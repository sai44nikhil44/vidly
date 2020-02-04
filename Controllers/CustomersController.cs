using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Viewmodels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private MyDbContext context;
        
        public CustomersController()
        {
            context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = context.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                context.Customers.Add(customer);
            }

            else
            {
                var CustomerInDb = context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDb.Name = customer.Name;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.IsSubscribedToNewsPaper = customer.IsSubscribedToNewsPaper;
            }
            
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }
        public ViewResult Index()
        {
            var customers = context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.membershipTypes.ToList()
            };
            return View("CustomerForm",ViewModel);

        }
/*        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }*/
        }
    
}