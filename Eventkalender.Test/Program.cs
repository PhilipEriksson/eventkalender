﻿using Eventkalender.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventkalender.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EventkalenderDAL d = new EventkalenderDAL("Resources/eventkalender-db.xml");

            d.GetEvent(1);


            
            //CronusController cronusController = new CronusController("Resources/cronus-db.xml");

            //cronusController.AddEmployee("FFF", "Philip", "Eriksson");

            /*
            Employee e = cronusController.GetEmployee("AL");

            List<Employee> employees = cronusController.GetEmployees();

            cronusController.UpdateEmployee("FFFFF", "pHHIILLIP", "Eriksson");*/
            //cronusController.DeleteEmployee("FFF");
            Console.ReadKey();
        }
    }
}
