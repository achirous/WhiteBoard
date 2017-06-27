namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewPostName6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViewedPosts", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViewedPosts", "Count");
        }
    }
}
