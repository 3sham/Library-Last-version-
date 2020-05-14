namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablelocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Loc_ID = c.Int(nullable: false, identity: true),
                        Floor = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        Room = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        shelf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Loc_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
