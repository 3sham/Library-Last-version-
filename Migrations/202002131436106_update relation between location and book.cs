namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterelationbetweenlocationandbook : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "location_Loc_ID", newName: "Loc_id");
            RenameIndex(table: "dbo.Books", name: "IX_location_Loc_ID", newName: "IX_Loc_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_Loc_id", newName: "IX_location_Loc_ID");
            RenameColumn(table: "dbo.Books", name: "Loc_id", newName: "location_Loc_ID");
        }
    }
}
