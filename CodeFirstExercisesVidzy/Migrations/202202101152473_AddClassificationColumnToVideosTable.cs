namespace CodeFirstExercisesVidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassificationColumnToVideosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classification", c => c.Byte(nullable: false, defaultValue:1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Classification");
        }
    }
}
