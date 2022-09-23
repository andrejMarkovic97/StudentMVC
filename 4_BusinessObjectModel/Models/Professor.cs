using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_user")]
    public class Professor : User
    {
        public Professor()
        {

        }
        [Column("cabinet")]
        public string Cabinet { get; set; }

        [Column("subject")]
        public string Subject { get; set; }
    }
}