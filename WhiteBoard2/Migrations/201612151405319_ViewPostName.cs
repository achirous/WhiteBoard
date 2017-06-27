namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViewedPosts", "ViewedPostName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViewedPosts", "ViewedPostName");
        }
    }
}
