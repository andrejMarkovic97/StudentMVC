using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace _1_PresentationLayer.ViewModels
{
    public class ProfessorViewModel : UserViewModel
    {
        public string Cabinet { get; set; }


        public string Subject { get; set; }
    }
    
}