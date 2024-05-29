namespace movierev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Movies", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Movies", "ApplicationUser_Id");
            AddForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
