namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdmissionFees", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdmissionFees", "CourseName");
        }
    }
}
