namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoAddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PhotoPath", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "PhotoPath");
        }
    }
}
