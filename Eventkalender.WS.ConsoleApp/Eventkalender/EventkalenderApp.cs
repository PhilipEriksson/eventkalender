﻿using Eventkalender.Database;
using Eventkalender.WS.ConsoleApp.EventkalenderReference;
using System;

namespace Eventkalender.WS.ConsoleApp
{
    public class EventkalenderApp
    {
        private int caseSwitch;
        private int id;
        private bool returnBool;

        private EventkalenderServiceSoapClient eventClient;

        public EventkalenderApp()
        {
            eventClient = new EventkalenderServiceSoapClient();
        }

        public void GetNation()
        {
            Console.WriteLine("Ange nationens ID: ");
            string userInput = Console.ReadLine();
            bool isNumeric = int.TryParse(userInput, out id);
            if (!isNumeric)
            {
                Console.WriteLine("Du måste sätta in ett tal.");
            }

            EventkalenderReference.Nation n = eventClient.GetNation(id);
            if (n != null)
            {
                Console.WriteLine("\nNationens namn är: {0}", n.Name);
                Console.WriteLine("Nationen har följande events: ");
                EventkalenderReference.Event[] events = n.Events;
                for (int j = 0; j < events.Length; j++)
                {
                    Console.WriteLine(events[j].Name);
                }
            }
            else
            {
                Console.WriteLine("Det finns ingen nation med detta id: {0}", id);
            }
            ExitQuestion();
        }

        public void GetNations()
        {
            Console.WriteLine("Följande är alla nationer: ");
            EventkalenderReference.Nation[] nations = eventClient.GetNations();
            for (int j = 0; j < nations.Length; j++)
            {
                Console.WriteLine(nations[j].Name);
            }
            ExitQuestion();
        }

        public void GetEvent()
        {
            Console.WriteLine("Ange eventets ID: ");
            string userInput = Console.ReadLine();
            bool isNumeric = int.TryParse(userInput, out id);
            if (!isNumeric)
            {
                Console.WriteLine("Du måste sätta in ett tal.");
            }

            EventkalenderReference.Event e = eventClient.GetEvent(id);
            if (e != null)
            {
                Console.WriteLine("\nEventets namn är: {0}", e.Name);
                Console.WriteLine("{0} anordnar {1}", e.Nation.Name, e.Name);
            }
            else
            {
                Console.WriteLine("Det finns inget event med detta id: {0}", id);
            }
            ExitQuestion();
        }

        public void GetEvents()
        {
            Console.WriteLine("Följande är alla events: ");
            EventkalenderReference.Event[] events = eventClient.GetEvents();
            for (int j = 0; j < events.Length; j++)
            {
                Console.WriteLine(events[j].Name);
            }
            ExitQuestion();
        }

        public void GetPerson()
        {
            Console.WriteLine("Ange personens ID: ");
            string userInput = Console.ReadLine();
            id = int.Parse(userInput);
            bool isNumeric = int.TryParse(userInput, out id);
            if (!isNumeric)
            {
                Console.WriteLine("Du måste sätta in ett tal.");
            }

            EventkalenderReference.Person p = eventClient.GetPerson(id);
            if (p != null)
            {
                Console.WriteLine("\nPersonens namn är: {0}, {1}", p.FirstName, p.LastName);
                Console.WriteLine("{0} ska gå på följande events:", p.FirstName);
                EventkalenderReference.Event[] events = p.Events;
                for (int j = 0; j < events.Length; j++)
                {
                    Console.WriteLine(events[j].Name);
                }
            }
            else
            {
                Console.WriteLine("Det finns inget event med detta id: {0}", id);
            }
            ExitQuestion();
        }

        public void GetPersons()
        {
            Console.WriteLine("Följande är alla personer: ");
            EventkalenderReference.Person[] personer = eventClient.GetPersons();
            for (int j = 0; j < personer.Length; j++)
            {
                Console.WriteLine("{0} {1}", personer[j].FirstName, personer[j].LastName);
            }
            ExitQuestion();
        }

        public void GetFile()
        {
            Console.WriteLine("Ange filsökvägen: ");
            string userInput = Console.ReadLine();
            string content = eventClient.GetFile(userInput);
            Console.WriteLine("Innehåll i filen {0}:", userInput);
            Console.WriteLine(content);
            ExitQuestion();
        }

        public void AddFile()
        {
            Console.WriteLine("Ange filnamn: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Ange innehåll: ");
            string content = Console.ReadLine();
            eventClient.AddFile(fileName, content);
            Console.WriteLine("Fil tillagd!");
            ExitQuestion();
        }

        public void GetFiles()
        {
            ArrayOfString files = eventClient.GetFiles();
            for (int i = 0; i < files.Count; i++)
            {
                Console.WriteLine(files[i]);
            }
            ExitQuestion();
        }

        public void ReturnMethod()
        {
            returnBool = false;
            Console.WriteLine("\nDu är nu tillbaka i Huvudmenyn\n");
        }

        public void ExitQuestion()
        {
            Console.WriteLine("\nVill du avsluta EventkalenderAppen? Tryck J");
            Console.WriteLine("Vill du återgå till senaste menyn? Skriv in valfritt värde");
            string userInput = Console.ReadLine();
            if (userInput.ToUpper().Equals("J"))
            {
                returnBool = false;
            }
        }

        public void Start()
        {
            Console.WriteLine("Hej och välkommen till EventkalenderApp\n");
            while (true)
            {
                returnBool = true;

                Console.WriteLine("Välj vad du vill göra!\n");
                Console.WriteLine("Hämta specifik Nation: Tryck 1");
                Console.WriteLine("Hämta alla Nationer: Tryck 2");
                Console.WriteLine("Hämta specifikt Event: Tryck 3");
                Console.WriteLine("Hämta alla Events: Tryck 4");
                Console.WriteLine("Hämta specifik Person: Tryck 5");
                Console.WriteLine("Hämta alla Personer: Tryck 6");
                Console.WriteLine("Hämta en fil: Tryck 7");
                Console.WriteLine("Lägg till en fil: Tryck 8");
                Console.WriteLine("Visa alla filer: Tryck 9");
                Console.WriteLine("För att gå tillbaka: Tryck -1");

                string userInput = Console.ReadLine();
                bool isNumeric = int.TryParse(userInput, out caseSwitch);
                if (!isNumeric || (caseSwitch < -1 || caseSwitch > 9))
                {
                    Console.WriteLine("Du måste sätta in ett nummer mellan -1 och 9!");
                    ExitQuestion();
                }
                try
                {
                    switch (caseSwitch)
                    {
                        case 1:
                            GetNation();
                            break;
                        case 2:
                            GetNations();
                            break;
                        case 3:
                            GetEvent();
                            break;
                        case 4:
                            GetEvents();
                            break;
                        case 5:
                            GetPerson();
                            break;
                        case 6:
                            GetPersons();
                            break;
                        case 7:
                            GetFile();
                            break;
                        case 8:
                            AddFile();
                            break;
                        case 9:
                            GetFiles();
                            break;
                        case -1:
                            ReturnMethod();
                            break;
                        case 0:
                            Program.VeryGoodMethod();
                            break;
                    }
                    if (!returnBool)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(ExceptionHandler.GetErrorMessage(e));
                    ExitQuestion();
                }
            }
        }
    }
}