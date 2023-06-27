namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noextratables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeritLists", "CandidateId", "dbo.ApplicantDetails");
            DropIndex("dbo.MeritLists", new[] { "CandidateId" });
            DropTable("dbo.MeritLists");
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.MeritLists",
                c => new
                    {
                        MeritId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        HigherSecondaryAggregateMarks = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeritId);
            
            CreateIndex("dbo.MeritLists", "CandidateId");
            AddForeignKey("dbo.MeritLists", "CandidateId", "dbo.ApplicantDetails", "CandidateId", cascadeDelete: true);
        }
    }
}
