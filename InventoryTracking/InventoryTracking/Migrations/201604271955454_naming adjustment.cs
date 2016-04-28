namespace InventoryTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namingadjustment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemsModels", "Item_Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ItemsModels", "Item_Price", c => c.Double(nullable: false));
            DropColumn("dbo.ItemsModels", "itemQuantity");
            DropColumn("dbo.ItemsModels", "itemPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemsModels", "itemPrice", c => c.Double(nullable: false));
            AddColumn("dbo.ItemsModels", "itemQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.ItemsModels", "Item_Price");
            DropColumn("dbo.ItemsModels", "Item_Quantity");
        }
    }
}
