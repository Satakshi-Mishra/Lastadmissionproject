namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnul : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allotments", "CandidateId", "dbo.ApplicantDetails");
        }
        
        public override void Down()
        {
        }
    }
}
