namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOne3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropColumn("dbo.OrderDetails", "Id");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductId", newName: "Id");
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderDetails", "Id");
            CreateIndex("dbo.OrderDetails", "Id");
            AddForeignKey("dbo.OrderDetails", "Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Id", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Id" });
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderDetails", "Id");
            RenameColumn(table: "dbo.OrderDetails", name: "Id", newName: "ProductId");
            AddColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
