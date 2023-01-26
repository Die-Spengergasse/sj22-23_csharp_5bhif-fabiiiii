using Xunit;
using Microsoft.EntityFrameworkCore;
using System;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe1.Test;

/// <summary>
/// Unittests für den DBContext.
/// Die Datenbank wird im Ordner SPG_Fachtheorie\SPG_Fachtheorie.Aufgabe1.Test\bin\Debug\net6.0\Invoice.db
/// erzeugt und kann mit SQLite Management Studio oder DBeaver betrachtet werden
/// </summary>
[Collection("Sequential")]
public class ApplicationContextTests
{
    private ApplicationContext GetContext(bool deleteDb = true)
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=Application1.db")
            .Options;

        var db = new ApplicationContext(options);
        if (deleteDb)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        return db;
    }
    /// <summary>
    /// Prüft, ob die Datenbank mit dem Model im InvoiceContext angelegt werden kann.
    /// </summary>
    [Fact]
    public void CreateDatabaseTest()
    {
        using var db = GetContext();
        Assert.IsType<ApplicationContext>(db);
    }


    [Fact]
    public void AddDepartmentSuccessTest()
    {
        // Arrange
        using var db = GetContext();
        Department department = new Department()
        {
            Name = "KD"
        };
        Department department2 = new Department()
        {
            Name = "HIF"
        };
        // Act
        db.Add(department);
        db.Add(department2);
        int actual = db.SaveChanges();

        // Assert
        Assert.Equal(2, actual);
    }
    [Fact]
    public void AddTaskSuccessTest()
    {
        using var db = GetContext();
        Task task = new Task()
        {
            Text = "xxxx",
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now,
            DepartmentNavigation = new Department() { Name = "KD"},
        };
        db.Add(task);
        db.SaveChanges();

        Assert.Equal(task,db.Tasks.Where(s => s.Text.Equals("xxxx")).First());
    }
    [Fact]
    public void AddApplicantSuccessTest()
    {
        using var db = GetContext();
        Applicant application = new Applicant()
        {
            Vorname = "Sel",
            NachName = "Tan",
            Geburtsdatum = DateTime.Now,
            DepartmentNavigation = new Department()
            {
                Name = "HIF"
            },
            ApplicantStatusNavigation = new ApplicantStatus()
            {
                RatedDate = DateTime.Now,
                Passed = true,
            }
        };
        
        db.Add(application);
        db.SaveChanges();

        Assert.Equal(application, db.Applicants.Where(s => s.Vorname.Equals("Sel")).First());

    }
    [Fact]
    public void AddUploadSuccessTest()
    {
        using var db = GetContext();
        Upload upload = new Upload()
        {
            Zeitstempel = DateTime.Now,
            URL = "https://url.com",
            ApplicationNavigation = new Applicant()
            {
                Vorname = "Sel",
                NachName = "Tan",
                Geburtsdatum= DateTime.Now,
                DepartmentNavigation = new Department()
                {
                    Name= "HIF"
                },
                ApplicantStatusNavigation= new ApplicantStatus()
                {
                    RatedDate = DateTime.Now,
                    Passed= true,
                }
            },
                

            TaskNavigation = new Task()
            {
                Text = "xxxx",
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                DepartmentNavigation = new Department() { Name = "KD" },
            }
        };

        db.Add(upload);
        db.SaveChanges();

        Assert.Equal(upload, db.Uploads.Where(s => s.ApplicationNavigation.Vorname.Equals("Sel")).First());

    }
    [Fact]
    public void AddApplicantWithApplicantStatusSuccessTest()
    {
        using var db = GetContext();
        Applicant applicant = new Applicant()
        {
            Vorname = "Sel",
            NachName = "Tan",
            Geburtsdatum = DateTime.Now,
            DepartmentNavigation = new Department() { Name = "HIF" },
            ApplicantStatusNavigation = new ApplicantStatus()
            {
                RatedDate = DateTime.Now,
                Passed = true
            }
        };
        db.Add(applicant);
        db.SaveChanges();

        Assert.Equal(applicant, db.Applicants.Where(s => s.Vorname.Equals("Sel")).First());


    }
}
