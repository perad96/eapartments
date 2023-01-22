namespace EApartments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_lease_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leases", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leases", "Status");
        }
    }
}
