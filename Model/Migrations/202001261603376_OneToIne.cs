namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToIne : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderDetails", name: "OrderDetailID", newName: "Id");
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropColumn("dbo.OrderDetails", "ProductId");
            RenameColumn(table: "dbo.OrderDetails", name: "Id", newName: "OrderDetailID");
        }
    }
}
