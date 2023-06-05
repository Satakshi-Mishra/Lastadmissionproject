namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allotments",
                c => new
                    {
                        AllocationId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllocationId)
                .ForeignKey("dbo.ApplicantDetails", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ApplicantDetails",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 8),
                        Mobile = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        HigherSecondaryAggregateMarks = c.Int(nullable: false),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        SeatAvailable = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.AdmissionFees",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        AllocationId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        FeesAmount = c.Int(nullable: false),
                        Fees_Status = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Allotments", t => t.AllocationId, cascadeDelete: false)
                .ForeignKey("dbo.ApplicantDetails", t => t.CandidateId, cascadeDelete: false)
                .Index(t => t.AllocationId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.MeritLists",
                c => new
                    {
                        MeritId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        HigherSecondaryAggregateMarks = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeritId)
                .ForeignKey("dbo.ApplicantDetails", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeritLists", "CandidateId", "dbo.ApplicantDetails");
            DropForeignKey("dbo.AdmissionFees", "CandidateId", "dbo.ApplicantDetails");
            DropForeignKey("dbo.AdmissionFees", "AllocationId", "dbo.Allotments");
            DropForeignKey("dbo.Allotments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ApplicantDetails", "Courses_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Allotments", "CandidateId", "dbo.ApplicantDetails");
            DropIndex("dbo.MeritLists", new[] { "CandidateId" });
            DropIndex("dbo.AdmissionFees", new[] { "CandidateId" });
            DropIndex("dbo.AdmissionFees", new[] { "AllocationId" });
            DropIndex("dbo.ApplicantDetails", new[] { "Courses_CourseId" });
            DropIndex("dbo.Allotments", new[] { "CourseId" });
            DropIndex("dbo.Allotments", new[] { "CandidateId" });
            DropTable("dbo.Logins");
            DropTable("dbo.MeritLists");
            DropTable("dbo.AdmissionFees");
            DropTable("dbo.Courses");
            DropTable("dbo.ApplicantDetails");
            DropTable("dbo.Allotments");
        }
    }
}
