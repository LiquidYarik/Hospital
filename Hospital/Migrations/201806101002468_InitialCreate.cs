namespace Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        DiseaseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SpecializationID = c.Int(),
                    })
                .PrimaryKey(t => t.DiseaseID)
                .ForeignKey("dbo.Specializations", t => t.SpecializationID)
                .Index(t => t.SpecializationID);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.SpecializationID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        SpecializationID = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Specializations", t => t.SpecializationID)
                .Index(t => t.SpecializationID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientPassword = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        DiseaseID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Diseases", t => t.DiseaseID)
                .Index(t => t.DiseaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecializationID", "dbo.Specializations");
            DropForeignKey("dbo.Schedules", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Schedules", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DiseaseID", "dbo.Diseases");
            DropForeignKey("dbo.Diseases", "SpecializationID", "dbo.Specializations");
            DropIndex("dbo.Patients", new[] { "DiseaseID" });
            DropIndex("dbo.Schedules", new[] { "PatientID" });
            DropIndex("dbo.Schedules", new[] { "DoctorID" });
            DropIndex("dbo.Doctors", new[] { "SpecializationID" });
            DropIndex("dbo.Diseases", new[] { "SpecializationID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Schedules");
            DropTable("dbo.Doctors");
            DropTable("dbo.Specializations");
            DropTable("dbo.Diseases");
        }
    }
}
