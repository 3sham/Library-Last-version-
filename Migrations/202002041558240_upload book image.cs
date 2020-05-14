namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadbookimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImagePath");
        }
    }
}
