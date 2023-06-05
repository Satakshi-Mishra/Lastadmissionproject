namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Logins", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Logins", "Email");
            DropColumn("dbo.Logins", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "UserName", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Logins");
            DropColumn("dbo.Logins", "Email");
            AddPrimaryKey("dbo.Logins", "UserName");
        }
    }
}
