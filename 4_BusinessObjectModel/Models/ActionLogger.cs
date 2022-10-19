using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    public class ActionLogger
    {
        public ActionLogger()
        {

        }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
        public DateTime TimeOfAction { get; set; }
        public Guid? AlteredUserID { get; set; }
    }
}