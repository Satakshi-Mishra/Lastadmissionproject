namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantDetails", "FeeStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicantDetails", "FeeStatus");
        }
    }
}
