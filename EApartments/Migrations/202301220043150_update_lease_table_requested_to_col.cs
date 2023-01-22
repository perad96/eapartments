namespace EApartments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_lease_table_requested_to_col : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leases", "ExtensionRequestedTo", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leases", "ExtensionRequestedTo", c => c.DateTime(nullable: false));
        }
    }
}
