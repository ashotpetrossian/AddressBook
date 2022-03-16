using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewContacts()
        {
            ViewBag.Message = "Contact List";

            var data = ContactManager.LoadContacts();
            List<ContactModel> contacts = new List<ContactModel>();

            foreach (var row in data)
            {
                contacts.Add(new ContactModel
                {
                    ContactId = row.ContactId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    PhoneNumber = row.PhoneNumber,
                    EmailAddress = row.EmailAddress,
                    Address = row.Address,
                });
            }

            return View(contacts);
        }

        public ActionResult SelectContact(int id)
        {
            ViewBag.Message = "Select the Contact";

            var data = ContactManager.SelectContact(id);

            List<ContactModel> contacts = new List<ContactModel>();

            foreach (var row in data)
            {
                contacts.Add(new ContactModel
                {
                    ContactId = row.ContactId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    PhoneNumber = row.PhoneNumber,
                    EmailAddress = row.EmailAddress,
                    Address = row.Address,
                });
            }

            return View(contacts);
        }

        public ActionResult CreateContact()
        {
            ViewBag.Message = "Create New Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = ContactManager.CreateContact(model.ContactId,
                                                                  model.FirstName,
                                                                  model.LastName,
                                                                  model.PhoneNumber,
                                                                  model.EmailAddress,
                                                                  model.Address);
                return RedirectToAction("ViewContacts");
            }

            return View();
        }

        public ActionResult EditContact()
        {
            ViewBag.Message = "Edit the Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContact(ContactModel model, int id)
        {              
            int recordsCreated = ContactManager.UpdateContact(id,
                                                                model.FirstName,
                                                                model.LastName,
                                                                model.PhoneNumber,
                                                                model.EmailAddress,
                                                                model.Address);                

            return RedirectToAction("ViewContacts");
        }


        public ActionResult DeleteContact()
        {
            ViewBag.Message = "Delete the Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteContact(ContactModel model, int id)
        {         
            
            int recordsCreated = ContactManager.DeleteContact(id);
            return RedirectToAction("ViewContacts");
            
        }
    }
}