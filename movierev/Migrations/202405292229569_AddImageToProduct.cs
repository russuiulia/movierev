namespace movierev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Image", c => c.String());
        }
    }
}
