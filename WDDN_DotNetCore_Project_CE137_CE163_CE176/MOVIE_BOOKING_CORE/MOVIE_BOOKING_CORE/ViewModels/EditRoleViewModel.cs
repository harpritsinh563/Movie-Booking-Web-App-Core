﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string> ();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage ="Role Name is mandatory *")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

    }
}
