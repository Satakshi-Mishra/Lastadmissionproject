namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnull1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantDetails", "AllotmentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicantDetails", "AllotmentStatus");
        }
    }
}
