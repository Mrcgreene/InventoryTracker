namespace InventoryTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstoreIDtotable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemsModels", "storeID", c => c.Int(nullable: false));
            AddColumn("dbo.StoreModels", "StoreID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreModels", "StoreID");
            DropColumn("dbo.ItemsModels", "storeID");
        }
    }
}
