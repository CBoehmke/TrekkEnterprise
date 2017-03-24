namespace TrekkEnterpriseV4.Migrations.EnterpriseContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enterprise",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        AccessCode = c.String(nullable: false, maxLength: 30),
                        IsAndroid = c.Boolean(nullable: false),
                        ApkName = c.String(),
                        Route = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DownloadCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Parent", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enterprise", "ParentID", "dbo.Parent");
            DropForeignKey("dbo.Enterprise", "ClientID", "dbo.Client");
            DropIndex("dbo.Enterprise", new[] { "ParentID" });
            DropIndex("dbo.Enterprise", new[] { "ClientID" });
            DropTable("dbo.Parent");
            DropTable("dbo.Enterprise");
            DropTable("dbo.Client");
        }
    }
}
