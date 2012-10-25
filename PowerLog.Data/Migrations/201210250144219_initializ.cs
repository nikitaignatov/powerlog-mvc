namespace PowerLog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoggedExercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TrainingSessionId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Reps = c.Int(nullable: false),
                        Comment = c.String(),
                        FailedToLift = c.Boolean(nullable: false),
                        ToFailure = c.Boolean(nullable: false),
                        MaxEffort = c.Boolean(nullable: false),
                        LongNegative = c.Boolean(nullable: false),
                        ForcedReps = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .ForeignKey("dbo.TrainingSessions", t => t.TrainingSessionId)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId)
                .Index(t => t.UserId)
                .Index(t => t.TrainingSessionId)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.TrainingSessions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 10),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        IsShared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BodyPart = c.String(),
                        Utility = c.String(),
                        Mechanics = c.String(),
                        Force = c.String(),
                        Sport = c.String(),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TrainingSessions", new[] { "UserId" });
            DropIndex("dbo.LoggedExercises", new[] { "ExerciseId" });
            DropIndex("dbo.LoggedExercises", new[] { "TrainingSessionId" });
            DropIndex("dbo.LoggedExercises", new[] { "UserId" });
            DropForeignKey("dbo.TrainingSessions", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.LoggedExercises", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.LoggedExercises", "TrainingSessionId", "dbo.TrainingSessions");
            DropForeignKey("dbo.LoggedExercises", "UserId", "dbo.UserProfiles");
            DropTable("dbo.Exercises");
            DropTable("dbo.TrainingSessions");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.LoggedExercises");
        }
    }
}
