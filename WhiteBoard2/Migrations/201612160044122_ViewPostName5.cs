namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostName5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViewedPosts", "IdViewed", c => c.Int(nullable: false));
            DropColumn("dbo.ViewedPosts", "CountViews");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewedPosts", "CountViews", c => c.Int(nullable: false));
            DropColumn("dbo.ViewedPosts", "IdViewed");
        }
    }
}
