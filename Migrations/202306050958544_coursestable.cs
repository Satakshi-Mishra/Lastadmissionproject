namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursestable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
        }
    }
}
