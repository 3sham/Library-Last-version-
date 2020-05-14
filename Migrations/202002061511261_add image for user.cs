namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimageforuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImagePath");
        }
    }
}
