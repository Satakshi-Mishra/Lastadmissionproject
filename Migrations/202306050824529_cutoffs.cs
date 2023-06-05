namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cutoffs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CutOff", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CutOff");
        }
    }
}
