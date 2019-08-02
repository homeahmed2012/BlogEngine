namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtToPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Created_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Created_at");
        }
    }
}
