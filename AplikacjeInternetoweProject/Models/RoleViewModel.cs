using Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacjeInternetoweProject.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {

        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}