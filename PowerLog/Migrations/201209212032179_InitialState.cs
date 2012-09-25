namespace PowerLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logs", "Exercise_ID", "dbo.Exercises");
            DropIndex("dbo.Logs", new[] { "Exercise_ID" });
            CreateTable(
                "dbo.ExerciseLogs",
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
            
            DropTable("dbo.Logs");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            DropIndex("dbo.ExerciseLogs", new[] { "Exercise_ID" });
            DropForeignKey("dbo.ExerciseLogs", "Exercise_ID", "dbo.Exercises");
            DropTable("dbo.ExerciseLogs");
            CreateIndex("dbo.Logs", "Exercise_ID");
            AddForeignKey("dbo.Logs", "Exercise_ID", "dbo.Exercises", "ID");
        }
    }
}
