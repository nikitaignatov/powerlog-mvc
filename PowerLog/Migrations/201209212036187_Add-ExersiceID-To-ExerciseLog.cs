namespace PowerLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExersiceIDToExerciseLog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseLogs", "Exercise_ID", "dbo.Exercises");
            DropIndex("dbo.ExerciseLogs", new[] { "Exercise_ID" });
            RenameColumn(table: "dbo.ExerciseLogs", name: "Exercise_ID", newName: "ExerciseID");
            AddForeignKey("dbo.ExerciseLogs", "ExerciseID", "dbo.Exercises", "ID", cascadeDelete: true);
            CreateIndex("dbo.ExerciseLogs", "ExerciseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExerciseLogs", new[] { "ExerciseID" });
            DropForeignKey("dbo.ExerciseLogs", "ExerciseID", "dbo.Exercises");
            RenameColumn(table: "dbo.ExerciseLogs", name: "ExerciseID", newName: "Exercise_ID");
            CreateIndex("dbo.ExerciseLogs", "Exercise_ID");
            AddForeignKey("dbo.ExerciseLogs", "Exercise_ID", "dbo.Exercises", "ID");
        }
    }
}
