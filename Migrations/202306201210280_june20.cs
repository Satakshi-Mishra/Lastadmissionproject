namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class june20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmissionFees",
                c => new
                    {
                        PaymentId = c.Int(nullable: false),
                        AllocationId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        FullName = c.String(),
                        FeesAmount = c.Int(nullable: false),
                        FeesStatus = c.String(),
                        PaymentMode = c.String(),
                        CardType = c.String(),
                        CardNumber = c.Long(nullable: false),
                        CVV = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Allotments", t => t.AllocationId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicantDetails", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.AllocationId)
                .Index(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdmissionFees", "CandidateId", "dbo.ApplicantDetails");
            DropForeignKey("dbo.AdmissionFees", "AllocationId", "dbo.Allotments");
            DropIndex("dbo.AdmissionFees", new[] { "CandidateId" });
            DropIndex("dbo.AdmissionFees", new[] { "AllocationId" });
            DropTable("dbo.AdmissionFees");
        }
    }
}
