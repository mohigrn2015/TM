using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Name is required")]
        public string employee_name { get; set; }

        [Required(ErrorMessage = "Father's name is required")]
        public string fathers_name { get; set; }

        [Required(ErrorMessage = "Mother's name is required")]
        public string mothers_name { get; set; }

        [Required(ErrorMessage = "Present Address is required")]
        public string present_address { get; set; }

        [Required(ErrorMessage = "Permanent Address is required")]
        public string permanent_address { get; set; }

        [Required(ErrorMessage = "NID is required")]
        public string nid { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }


        [Required(ErrorMessage = "Contact no is required")]
        public string contact_no { get; set; }

        [Required(ErrorMessage = "Gurdian Contact no is required")]
        public string g_contact_no { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        public string blood_group { get; set; }
        [Required(ErrorMessage = "designation is required")]
        public int designation_id { get; set; }
        public string designation_name { get; set; }
        [Required(ErrorMessage = "team is required")]
        public int team_id { get; set; }

    }
}
