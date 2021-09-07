namespace FinalProject_OnlineShop_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auths", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auths", "Role");
        }
    }
}
