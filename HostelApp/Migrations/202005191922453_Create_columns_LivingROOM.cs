namespace HostelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_columns_LivingROOM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LivingRooms", "TenantsCount", c => c.Int(nullable: false));
            AddColumn("dbo.LivingRooms", "MaxTenants", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LivingRooms", "MaxTenants");
            DropColumn("dbo.LivingRooms", "TenantsCount");
        }
    }
}
