namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursefee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseFee");
        }
    }
}
