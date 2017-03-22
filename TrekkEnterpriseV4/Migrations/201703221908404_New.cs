namespace TrekkEnterpriseV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccessCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccessCode");
        }
    }
}
