namespace movierev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNamess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "UserId");
        }
    }
}
