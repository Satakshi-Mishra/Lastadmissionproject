namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdmissionFees", "AllocationId", "dbo.Allotments");
            DropForeignKey("dbo.AdmissionFees", "CandidateId", "dbo.ApplicantDetails");
            DropIndex("dbo.AdmissionFees", new[] { "AllocationId" });
            DropIndex("dbo.AdmissionFees", new[] { "CandidateId" });
            DropTable("dbo.AdmissionFees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdmissionFees",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        AllocationId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        FeesAmount = c.Int(nullable: false),
                        Fees_Status = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateIndex("dbo.AdmissionFees", "CandidateId");
            CreateIndex("dbo.AdmissionFees", "AllocationId");
            AddForeignKey("dbo.AdmissionFees", "CandidateId", "dbo.ApplicantDetails", "CandidateId", cascadeDelete: true);
            AddForeignKey("dbo.AdmissionFees", "AllocationId", "dbo.Allotments", "AllocationId", cascadeDelete: true);
        }
    }
}
