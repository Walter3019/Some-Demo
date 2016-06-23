namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EMS_PSS_Project.Models;
    using EMS_PSS_Project.DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<EMS_PSS_Project.DAL.EMS_PSS_DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMS_PSS_Project.DAL.EMS_PSS_DBContext context)
        {
            // 200 Valid SIN Entries using 
            string[] sinList = new string[] {   "123456790", "123456808","123456816","123456824","123456832","123456840","123456857","123456865","123456873","123456881",
                                                "123456899","123456907","123456915","123456923","123456931","123456949","123456956","123456964","123456972","123456980","123456998","123457004",
                                                "123457012","123457020","123457038","123457046","123457053","123457061","123457079","123457087","123457095","123457103","123457111","123457129",
                                                "123457137","123457145","123457152","123457160","123457178","123457186","123457194","123457202","123457210","123457228","123457236","123457244",
                                                "123457251","123457269","123457277","123457285","491456794","491456802","491456810","491456828","491456836","491456844","491456851","491456869",
                                                "491456877","491456885","491456893","491456901","491456919","491456927","491456935","491456943","491456950","491456968","491456976","491456984",
                                                "491456992","491457008","491457016","491457024","491457032","491457040","491457057","491457065","491457073","491457081","491457099","491457107",
                                                "491457115","491457123","491457131","691457147","691457154","691457162","691457170","691457188","691457196","691457204","691457212","691457220",
                                                "691457238","691457246","691457253","691457261","691457279","691457287","691457295","691457303","691457311","691457329","691457337","691457345",
                                                "691457352","691457360","691457378","691457386","791457393","791457401","791457419","791457427","791457435","791457443","791457450","791457468",
                                                "791457476","791457484","791457492","791457500","791457518","791457526","791457534","791457542","791457559","791457567","791457575","791457583",
                                                "791457591","791457609","791457617","791457625","791457633","791457641","791457658","791457666","791457674","791457682","791457690","791457708",
                                                "791457716","791457724","791457732","791457740","791457757","791457765","791457773","791457781","223456799","223456807","223456815","223456823",
                                                "223456831","223456849","223456856","223456864","223456872","223456880","223456898","223456906","223456914","223456922","223456930","223456948",
                                                "223456955","223456963","223456971","223456989","223456997","223457003","223457011","223457029","223457037","223457045","223457052","223457060",
                                                "223457078","223457086","223457094","223457102","223457110","223457128","223457136","223457144","223457151","223457169","223457177","223457185",
                                                "223457193","223457201","223457219","223457227","223457235","223457243","223457250","223457268","223457276","223457284","223457292","223457300",
                                                "223457318","223457326","223457334","223457342","223457359","223457367","223457375","223457383","223457391","223457409","223457417","223457425",
                                                "223457433","223457441","223457458","223457466","223457474","223457482","223457490","223457508","223457516","223457524","223457532","223457540",
                                                "223457557","223457565","223457573","223457581","223457599","223457607","223457615","223457623","223457631","223457649","223457656","223457664",
                                                "223457672","223457680","223457698","223457706","223457714","223457722","223457730","223457748","223457755","223457763","223457771","223457789" };

            /*
             * Person Information.
             */
            //var Persons = new List<EMS_Person>
            //{
            //     new EMS_Person{First_Name="Carson",Last_Name="Alexander", Date_Of_Birth=DateTime.Parse("2005-09-01"), Social_Insurance_Number="791457476"},
            //     new EMS_Person{First_Name="Meredith",Last_Name="Alonso", Date_Of_Birth=DateTime.Parse("2002-09-01"), Social_Insurance_Number="223457599"},
            //     new EMS_Person{First_Name="Arturo",Last_Name="Anand", Date_Of_Birth=DateTime.Parse("2003-09-01"), Social_Insurance_Number="223457458"},
            //     new EMS_Person{First_Name="Gytis",Last_Name="Barzdukas", Date_Of_Birth=DateTime.Parse("2002-09-01"), Social_Insurance_Number="223457565"},
            //     new EMS_Person{First_Name="Yan",Last_Name="Li", Date_Of_Birth=DateTime.Parse("2002-09-01"), Social_Insurance_Number="223457557"},
            //     new EMS_Person{First_Name="Peggy",Last_Name="Justice", Date_Of_Birth=DateTime.Parse("2001-09-01"), Social_Insurance_Number="223456831"},
            //     new EMS_Person{First_Name="Laura",Last_Name="Norman", Date_Of_Birth=DateTime.Parse("2003-09-01"), Social_Insurance_Number="691457352"},
            //     new EMS_Person{First_Name="Nino",Last_Name="Olivetto", Date_Of_Birth=DateTime.Parse("2005-09-01"), Social_Insurance_Number="691457253"}
            //};

            //Persons.ForEach(s => context.EMS_Person.Add(s));
            //context.SaveChanges();

            /*
             * Company Information.
             */
            //var Company = new List<EMS_Company>
            //{
            //    new EMS_Company{CompanyDescription="3M Canada Company"},
            //    new EMS_Company{CompanyDescription="Accenture Inc."},
            //    new EMS_Company{CompanyDescription="Bell Canada"},
            //    new EMS_Company{CompanyDescription="General Electric Canada / GE"},
            //    new EMS_Company{CompanyDescription="IMAX"},
            //    new EMS_Company{CompanyDescription="Samsung Electronics Canada Inc."},
            //    new EMS_Company{CompanyDescription="Yukon, Government of"},
            //    new EMS_Company{CompanyDescription="Digital Extremes Ltd."},
            //    new EMS_Company{CompanyDescription="OpenText Corporation"},
            //};

            //Company.ForEach(s => context.EMS_Company.Add(s));
            //context.SaveChanges();

            /*
             * Fulltime Employee Information.
             */
            //var Fulltime_Employees = new List<EMS_Fulltime_Employee>
            //{
            //    new EMS_Fulltime_Employee{Fulltime_Employee_ID=1, Company_ID=1, Date_Of_Hire=DateTime.Parse("1960-05-23"), Date_Of_Termination=DateTime.Parse("2016-05-23"), Salary=550000.00m, Person_ID = 1, Reason_For_Leaving = "1", Status = false, Completion = false },
            //    new EMS_Fulltime_Employee{Fulltime_Employee_ID=2, Company_ID=2, Date_Of_Hire=DateTime.Parse("1965-06-02"), Date_Of_Termination=DateTime.Parse("2016-05-23"), Salary=550000.00m, Person_ID = 2, Reason_For_Leaving = "1", Status = false, Completion = false },
            //    new EMS_Fulltime_Employee{Fulltime_Employee_ID=3, Company_ID=3, Date_Of_Hire=DateTime.Parse("1988-07-12"), Date_Of_Termination=DateTime.Parse("2016-05-23"), Salary=550000.00m, Person_ID = 3, Reason_For_Leaving = "1", Status = false, Completion = false },
            //    new EMS_Fulltime_Employee{Fulltime_Employee_ID=4, Company_ID=4, Date_Of_Hire=DateTime.Parse("1991-08-17"), Date_Of_Termination=DateTime.Parse("2016-05-23"), Salary=550000.00m, Person_ID = 4, Reason_For_Leaving = "1", Status = false, Completion = false }
            //};

            //Fulltime_Employees.ForEach(s => context.EMS_Fulltime.Add(s));
            //context.SaveChanges();

            /*
             * Information of User.
             */
            //var level = new List<EMS_SecurityLevel>
            //{
            //     new EMS_SecurityLevel{ SecurityLevel_ID = 1, ScurityDescription = "General"},
            //     new EMS_SecurityLevel{ SecurityLevel_ID = 2, ScurityDescription = "Admin"}
            //};

            //level.ForEach(s => context.EMS_SecurityLevel.Add(s));
            //context.SaveChanges();


            ///*
            // * Information of User.
            // */
            //var Users = new List<EMS_Users>
            //{
            //     new EMS_Users{First_Name="Lingchen",Last_Name="Meng", PassWord="2", User_Name="s1", SecurityLevel_ID=1},
            //     new EMS_Users{First_Name="Xuan",Last_Name="Zhang", PassWord="1", User_Name="s2", SecurityLevel_ID=2},
            //};

            //Users.ForEach(s => context.EMS_Users.Add(s));
            //context.SaveChanges();
        }
    }
}
