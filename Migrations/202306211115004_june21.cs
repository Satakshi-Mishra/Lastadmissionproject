namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class june21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdmissionFees", "FeesAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdmissionFees", "FeesAmount", c => c.Int(nullable: false));
        }
    }
}
