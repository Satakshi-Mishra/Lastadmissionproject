namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnull2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicantDetails", "Courses_CourseId", "dbo.Courses");
            DropIndex("dbo.ApplicantDetails", new[] { "Courses_CourseId" });
            RenameColumn(table: "dbo.ApplicantDetails", name: "Courses_CourseId", newName: "CourseId");
            AlterColumn("dbo.ApplicantDetails", "CourseId", c => c.Int(nullable: true));
            CreateIndex("dbo.ApplicantDetails", "CourseId");
            AddForeignKey("dbo.ApplicantDetails", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantDetails", "CourseId", "dbo.Courses");
            DropIndex("dbo.ApplicantDetails", new[] { "CourseId" });
            AlterColumn("dbo.ApplicantDetails", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.ApplicantDetails", name: "CourseId", newName: "Courses_CourseId");
            CreateIndex("dbo.ApplicantDetails", "Courses_CourseId");
            AddForeignKey("dbo.ApplicantDetails", "Courses_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
