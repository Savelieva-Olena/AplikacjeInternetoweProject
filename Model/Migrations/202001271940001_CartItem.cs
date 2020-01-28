namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CartId", "dbo.Carts");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "CartId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        ShoppingCartItemId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ShoppingCartItemId)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.Products", "CartId");
            DropTable("dbo.Carts");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CartId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingCartItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.ShoppingCartItems", new[] { "Product_Id" });
            DropTable("dbo.ShoppingCartItems");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Products", "CartId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
