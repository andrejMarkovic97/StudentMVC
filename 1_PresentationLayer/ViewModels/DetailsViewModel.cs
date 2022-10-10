using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {

        }
        public string Title { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsReadOnly { get; set; }
    }
}