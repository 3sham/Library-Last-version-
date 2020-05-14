namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpublishertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.publishers",
                c => new
                    {
                        Pub_Id = c.Int(nullable: false, identity: true),
                        Pub_Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Pub_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.publishers");
        }
    }
}
