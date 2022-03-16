using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class ContactModel
    {
        [Display(Name ="Contact Id")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid ContactId")]
        public int ContactId { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="You need to provide your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to provide your last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You need to provide your phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to provide your Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You need to provide your address")]
        public string Address { get; set; }

    }
}