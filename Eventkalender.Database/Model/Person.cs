﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventkalender.Database.Model
{
    [Serializable]
    public class Person
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
            private set { }
        }

        public virtual ICollection<Event> Events { get; set; }
    }
}