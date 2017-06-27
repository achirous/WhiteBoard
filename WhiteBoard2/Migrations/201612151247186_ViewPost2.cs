namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPost2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViewedPosts", "CountViews", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViewedPosts", "CountViews");
        }
    }
}
