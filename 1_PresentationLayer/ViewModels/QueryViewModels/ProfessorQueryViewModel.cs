using _1_PresentationLayer.ViewModels.QueryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels.QueryViewModels
{
    public class ProfessorQueryViewModel : UserQueryViewModel
    {
        public ProfessorQueryViewModel()
        {

        }
        public string Cabinet { get; set; }


        public string Subject { get; set; }
    }
}