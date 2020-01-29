namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Orders", "ApplicationUserId");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Orders", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
        }
    }
}
