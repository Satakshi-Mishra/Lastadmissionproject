namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allotments", "CourseId", "dbo.Courses");
        }
        
        public override void Down()
        {
        }
    }
}
