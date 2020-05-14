namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationbetweenlocationsandbook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "location_Loc_ID", c => c.Int());
            CreateIndex("dbo.Books", "location_Loc_ID");
            AddForeignKey("dbo.Books", "location_Loc_ID", "dbo.Locations", "Loc_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "location_Loc_ID", "dbo.Locations");
            DropIndex("dbo.Books", new[] { "location_Loc_ID" });
            DropColumn("dbo.Books", "location_Loc_ID");
        }
    }
}
