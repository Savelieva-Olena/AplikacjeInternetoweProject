namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCartItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.ShoppingCartItems", new[] { "Product_Id" });
            DropTable("dbo.ShoppingCartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        ShoppingCartItemId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ShoppingCartItemId);
            
            CreateIndex("dbo.ShoppingCartItems", "Product_Id");
            AddForeignKey("dbo.ShoppingCartItems", "Product_Id", "dbo.Products", "Id");
        }
    }
}
