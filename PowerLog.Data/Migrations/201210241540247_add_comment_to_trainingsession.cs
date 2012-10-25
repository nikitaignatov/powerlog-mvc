namespace PowerLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_comment_to_trainingsession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingSessions", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingSessions", "Comment");
        }
    }
}
