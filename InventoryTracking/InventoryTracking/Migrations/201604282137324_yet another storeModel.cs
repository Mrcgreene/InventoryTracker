namespace InventoryTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yetanotherstoreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreModels");
        }
    }
}
