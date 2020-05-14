namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablemembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Memb_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Memb_Date = c.DateTime(nullable: false, storeType: "date"),
                        Expiry_Date = c.DateTime(nullable: false, storeType: "date"),
                        Memb_Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Memb_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
