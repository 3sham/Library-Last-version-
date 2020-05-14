namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnphonetotablemember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Phone");
        }
    }
}
