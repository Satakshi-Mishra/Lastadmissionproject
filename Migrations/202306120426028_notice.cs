namespace Lastadmissionproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeName = c.String(),
                        NoticeDescription = c.String(),
                        NoticeCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notices");
        }
    }
}
