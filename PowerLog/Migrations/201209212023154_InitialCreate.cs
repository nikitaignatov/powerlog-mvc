namespace PowerLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Single(nullable: false),
                        Reps = c.Int(nullable: false),
                        Exercise_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ID)
                .Index(t => t.Exercise_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Logs", new[] { "Exercise_ID" });
            DropForeignKey("dbo.Logs", "Exercise_ID", "dbo.Exercises");
            DropTable("dbo.Logs");
            DropTable("dbo.Exercises");
        }
    }
}
