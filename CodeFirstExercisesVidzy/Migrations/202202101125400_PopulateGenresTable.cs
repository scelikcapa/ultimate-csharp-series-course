namespace CodeFirstExercisesVidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1,'Horror')");
            Sql("INSERT INTO Genres VALUES (2,'Action')");
            Sql("INSERT INTO Genres VALUES (3,'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
