namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationbetweenbookandpublisher : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "publisher_Pub_Id", newName: "Pub_id");
            RenameIndex(table: "dbo.Books", name: "IX_publisher_Pub_Id", newName: "IX_Pub_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_Pub_id", newName: "IX_publisher_Pub_Id");
            RenameColumn(table: "dbo.Books", name: "Pub_id", newName: "publisher_Pub_Id");
        }
    }
}
