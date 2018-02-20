﻿using Eventkalender.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Eventkalender.PK.CronusReference;
using Eventkalender.PK.EventkalenderReference;

namespace Eventkalender.PK.GUI
{
    /// <summary>
    /// Interaction logic for GUI_Prototyp.xaml
    /// </summary>
    public partial class GUI_Prototyp : Window
    {
        DateTime dateStart;
        DateTime dateEnd;
        private EventkalenderController eventkalenderController;
        private EventkalenderViewModel eventkalenderViewModel;
        private CronusServiceSoapClient cronusClient;
        private EventkalenderServiceSoapClient eventkalenderWSClient;
        

        public GUI_Prototyp()
        {
            InitializeComponent();
            DataContext = new EventkalenderViewModel();
            eventkalenderController = new EventkalenderController("Resources/eventkalender-db.xml");
            eventkalenderViewModel = new EventkalenderViewModel();
            cronusClient = new CronusServiceSoapClient();
            eventkalenderWSClient = new EventkalenderServiceSoapClient();
        }

      /*  public void GetMetadataByDataTuples(CronusReference.DataTuple[] inputTuple)
        {
            CronusReference.DataTuple[] data = inputTuple;
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i].ToString());
            }
        }

        public void GetMetadataListOfString(List<string> metod)
        {
            foreach (string row in metod)
            {
                Console.WriteLine(row);
            }
        } */

        public void GetEmployeeMetadata()
        {
            cronusClient.GetEmployeeMetadata();
            cronusClient.GetIndexes();
        }

        public void GetEmployeeAbsenceMetadata()
        {
            cronusClient.GetEmployeeAbsenceMetadata();
        }
       
        public List<string> MetadataCombobox
        {
            get
            {
                List<string> lst = new List<string>();
                lst.Add("GetIndexes");
                lst.Add("GetKeys");
                return lst;
            } 
            private set { }
        }

        public List<string> GetMetadata
        {
            get
            {
                switch (cmbMetaData.SelectedIndex)
                {
                    case 0:
                        List<string> values = cronusClient.GetTableConstraints(); //Combobox.whatever(i) i = val i listan
                        return values;
                }
                return null;


            }
            set { }
        }
        private void btnEraseFromListClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult raderaResultat = MessageBox.Show("Vill ni verkligen ta bort innehållet?", "Radera", MessageBoxButton.YesNo);
            if (raderaResultat == MessageBoxResult.Yes)
            {
                if (cmbFilterList.SelectedIndex == 0)
                {
                    int index = datagridPersonNation.SelectedIndex;
                    Database.Nation nation = eventkalenderViewModel.Nations.ElementAt(index);
                    eventkalenderController.DeleteNation(nation.Id);
                    datagridPersonNation.Items.RemoveAt(index);
                }
                if (cmbFilterList.SelectedIndex == 1)
                {
                    int index = datagridPersonNation.SelectedIndex;
                    Database.Person person = eventkalenderViewModel.Persons.ElementAt(index);
                    eventkalenderController.DeletePerson(person.Id);
                    datagridPersonNation.Items.RemoveAt(index);
                }
            }
        }

        private void btnDeleteEventClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult raderaResultat = MessageBox.Show("Vill ni verkligen ta bort innehållet?", "Radera", MessageBoxButton.YesNo);
            if (raderaResultat == MessageBoxResult.Yes)
            {
                int index = datagridEvents.SelectedIndex;

                Database.Event ev = eventkalenderViewModel.Events.ElementAt(index);
                eventkalenderController.DeleteEvent(ev.Id);
                datagridEvents.Items.RemoveAt(index);
            }
        }

        private void btnRegNationNameClick(object sender, RoutedEventArgs e)
        {
            if (txtBoxNationName.Text != "")
            {
                eventkalenderController.AddNation(txtBoxNationName.Text);
                txtBoxNationName.Text = "";
            }
            else
            {
                MessageBox.Show("Inget värde ifyllt");
            }
        }
        private void btnRegPers_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxFirstName.Text != "" && txtBoxLastName.Text != "")
            {
                eventkalenderController.AddPerson(txtBoxFirstName.Text, txtBoxLastName.Text);
                txtBoxFirstName.Text = "";
                txtBoxLastName.Text = "";
            }
            else if (txtBoxLastName.Text == "")
            {
                MessageBox.Show("Glöm inte ange efternamnet");
            }
            else if (txtBoxFirstName.Text == "")
            {
                MessageBox.Show("Glöm inte ange förnamnet");
            }
        }

        private void btnRegsterEventClick(object sender, RoutedEventArgs e)
        {
            if(Utility.CheckIfEmpty(txtBoxEventName.Text, cmBoxNation.Text, dtpickStartDate.Text, cmbStartTime.Text, dtpickEndDate.Text, cmbEndTime.Text, txtBoxSummary.Text))
            {
                dateStart = Utility.ToDate(dtpickStartDate.Text, cmbStartTime.Text);
                dateEnd = Utility.ToDate(dtpickEndDate.Text, cmbEndTime.Text);

                int index = cmBoxNation.SelectedIndex;
                Database.Nation n = eventkalenderViewModel.Nations.ElementAt(index);
                
                eventkalenderController.AddEvent(txtBoxEventName.Text, txtBoxSummary.Text, dateStart, dateEnd, n.Id);
            }
            else
            {

            }
        }

        private void cmbMetaData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagridCronus.ItemsSource = GetMetadata;
        }

        private void cmBoxSearchEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cmBoxSearchEvents.SelectedIndex;
            if(index > -1)
            {
                Database.Nation n = eventkalenderViewModel.Nations.ElementAt(index);
                datagridEvents.ItemsSource = n.Events;
            }
            else
            {
                datagridEvents.ItemsSource = eventkalenderViewModel.Events;
            }

        }

        private void cmbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cmbEvents.SelectedIndex;
            if (index > -1)
            {
                Database.Nation n = eventkalenderViewModel.Nations.ElementAt(index);
                datagridFindEvents.ItemsSource = n.Events;
            }
            
        }

        private void cmbFilterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbFilterList.SelectedIndex == 0)
            {
                datagridPersonNation.ItemsSource = eventkalenderViewModel.Nations;
            }
            if(cmbFilterList.SelectedIndex == 1)
            {
                datagridPersonNation.ItemsSource = eventkalenderViewModel.Persons;
            }
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
