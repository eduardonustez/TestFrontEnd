using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required]
        public string ProjectName{get;set;}
        [Required]
        public string Location{get;set;}
        public bool IsEdit{get;set;}
    }
}
