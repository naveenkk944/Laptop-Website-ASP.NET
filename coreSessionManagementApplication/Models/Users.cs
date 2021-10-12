using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreSessionManagementApplication.Models
{
    public class User

    {
        
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]

        public string usertype { get; set; }
        [Required]

        public string name { get; set; }
        [Required]
        public int Id { get; set; }


    }
}
