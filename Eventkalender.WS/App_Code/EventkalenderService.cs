﻿using Eventkalender.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://www.ics.lu.se.cali/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EventkalenderService : WebService
{
    private string physicalPath;

    private EventkalenderController eventkalenderController;

    public EventkalenderService()
    {
        physicalPath = HttpContext.Current.Server.MapPath("~/App_Data");

        string databaseFilePath = physicalPath + "/eventkalender-db.xml";
        eventkalenderController = new EventkalenderController(databaseFilePath);
    }

    [WebMethod]
    public string GetFile(string path)
    {
        string filePath = string.Format("{0}/Files/{1}", physicalPath, path);
        return File.ReadAllText(filePath);
    }

    //[WebMethod]
    //public void AddFile(string path, string content)
    //{
    //    string filePath = string.Format("{0}/Files/{1}", physicalPath, path);

    //    FileStream ms = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
    //    using (StreamWriter sw = new StreamWriter(ms))
    //    {
    //        sw.WriteLine(content);
    //    }
    //    //File.WriteAllText(path, content);
    //}

    [WebMethod]
    public Nation GetNation(int id)
    {
        return eventkalenderController.GetNation(id);
    }

    [WebMethod]
    public List<Nation> GetNations()
    {
        return eventkalenderController.GetNations();
    }

    [WebMethod]
    public void AddNation(string name)
    {
        eventkalenderController.AddNation(name);
    }

    [WebMethod]
    public void AddEvent(string name, string summary, DateTime startTime , DateTime endTime, int nationId)
    {
        //Lösning så att tid sätts in i rätt format för datetime?
        eventkalenderController.AddEvent(name,summary, startTime, endTime, nationId);
    }

    [WebMethod]
    public Event GetEvent(int id)
    {
        return eventkalenderController.GetEvent(id);
    }

    [WebMethod]
    public List<Event> GetEvents()
    {
        return eventkalenderController.GetEvents();
    }

    [WebMethod]
    public void AddPerson(string firstName, string lastName)
    {
        eventkalenderController.AddPerson(firstName, lastName);
    }

    [WebMethod]
    public Person GetPerson(int id)
    {
        return eventkalenderController.GetPerson(id);
    }

    [WebMethod]
    public List<Person> GetPersons()
    {
        return eventkalenderController.GetPersons();
    }
}