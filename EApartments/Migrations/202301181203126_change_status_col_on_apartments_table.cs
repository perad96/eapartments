namespace EApartments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_status_col_on_apartments_table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apartments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apartments", "Status", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
