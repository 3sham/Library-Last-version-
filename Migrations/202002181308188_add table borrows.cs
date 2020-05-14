namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableborrows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        Borro_ID = c.Guid(nullable: false, identity: true),
                        Due_date = c.DateTime(nullable: false, storeType: "date"),
                        Return_date = c.DateTime(nullable: false),
                        Issue = c.String(),
                        Memb_ID = c.Int(),
                        Book_id = c.Guid(),
                    })
                .PrimaryKey(t => t.Borro_ID)
                .ForeignKey("dbo.Books", t => t.Book_id)
                .ForeignKey("dbo.Members", t => t.Memb_ID)
                .Index(t => t.Memb_ID)
                .Index(t => t.Book_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "Memb_ID", "dbo.Members");
            DropForeignKey("dbo.Borrows", "Book_id", "dbo.Books");
            DropIndex("dbo.Borrows", new[] { "Book_id" });
            DropIndex("dbo.Borrows", new[] { "Memb_ID" });
            DropTable("dbo.Borrows");
        }
    }
}
