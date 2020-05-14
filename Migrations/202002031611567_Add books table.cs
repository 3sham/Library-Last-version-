namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbookstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Book_ID = c.Guid(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Available = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                        Author = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Book_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
