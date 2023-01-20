namespace EApartments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_occupant_table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Occupants", "ApartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Occupants", "ApartmentId", c => c.Int(nullable: false));
        }
    }
}
