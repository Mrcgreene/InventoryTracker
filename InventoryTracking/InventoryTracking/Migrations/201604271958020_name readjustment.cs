namespace InventoryTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namereadjustment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemsModels", "itemQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.ItemsModels", "itemPrice", c => c.Double(nullable: false));
            DropColumn("dbo.ItemsModels", "Item_Quantity");
            DropColumn("dbo.ItemsModels", "Item_Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemsModels", "Item_Price", c => c.Double(nullable: false));
            AddColumn("dbo.ItemsModels", "Item_Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.ItemsModels", "itemPrice");
            DropColumn("dbo.ItemsModels", "itemQuantity");
        }
    }
}
