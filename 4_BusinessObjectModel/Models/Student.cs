using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("student")]
    public class Student
    {
        public Student()
        {

        }
        [Key]
        [Column("id")]
        public Guid ID { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("birth_date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("adress")]
        public string Adress { get; set; }
        
        [Required]
        [Column("discriminator")]
        [EnumDataType(typeof(Discriminator))]
        public Discriminator Discriminator { get; set; }

        public override string ToString()
        {
            return $"First Name : {FirstName},\nLast name : {LastName},\nBirth date: {BirthDate.ToShortDateString()},\n" +
                $"Email : {Email},\nPhone number : {PhoneNumber},\nAdress: {Adress}";
        }
    }
}