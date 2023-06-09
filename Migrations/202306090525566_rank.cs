namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantDetails", "Rank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicantDetails", "Rank");
        }
    }
}
