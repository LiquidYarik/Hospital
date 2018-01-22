namespace Hospital.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalDB : DbContext
    {
        // Your context has been configured to use a 'HospitalDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Hospital.Models.HospitalDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HospitalDB' 
        // connection string in the application configuration file.
        public HospitalDB()
            : base("name=HospitalDB")
        {
        }
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Patients> patients { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Disease> diseases { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}