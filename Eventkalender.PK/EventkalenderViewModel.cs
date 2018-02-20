﻿using System;
using System.Collections;
using Eventkalender.Database;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Eventkalender.PK.GUI

{
    class EventkalenderViewModel : INotifyPropertyChanged
    {
        private EventkalenderController eventkalenderController = new EventkalenderController("Resources/eventkalender-db.xml");
        private List<string> timesList;
        private ObservableCollection<Database.Event> events;
        private ObservableCollection<Database.Nation> nations;
        private ObservableCollection<Database.Person> persons;
        EventkalenderDAL eventkalenderDAL = new EventkalenderDAL("Resources/eventkalender-db");

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       /* protected void OnPropertyChanged(ObservableCollection<object> lst)
        {
            
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }*/


        public ObservableCollection<Database.Event> Events
        {
            get
            {
                if (events == null)
                {
                    
                    return events = new ObservableCollection<Database.Event>(eventkalenderController.GetEvents());
                }
                return events;
            }
            set
            {
            }
        }

        public ObservableCollection<Database.Nation> Nations
        {
            get
            {
                if (nations == null)
                {

                    return nations = new ObservableCollection<Database.Nation>(eventkalenderController.GetNations());
                }
                return nations;
            }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nations"));
                }
            }
        }

        public ObservableCollection<Database.Person> Persons
        {
            get
            {
                if (persons == null)
                {
                    return persons = new ObservableCollection<Database.Person>(eventkalenderController.GetPersons());
                }
                return persons;
            }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Persons"));
                }
            }
        }
        public List<string> TimesList
        {
            set
            { }
            get
            {
                if (timesList == null)
                {
                    return timesList = Utility.GenerateList();
                }
                return timesList;
            }
        }

        public void AddNation(string name)
        {
            Nation n = new Nation(name);

            Nations.Add(n);
            eventkalenderDAL.AddNation(n);
        }

        public void DeleteNation(int id)
        {
            Nation n = new Nation("");
            n.Id = id;

            Nations.Remove(n);
            eventkalenderDAL.DeleteNation(n);
        }
        
        public void AddPerson(string name, string lastname)
        {
            Person p = new Person(name, lastname);

            Persons.Add(p);
            eventkalenderDAL.AddPerson(p);
        }

        public void DeletePerson(int id)
        {
            Person p = new Person("","");
            p.Id = id;

            Persons.Remove(p);
            eventkalenderDAL.DeletePerson(p);
        }
    }
}
