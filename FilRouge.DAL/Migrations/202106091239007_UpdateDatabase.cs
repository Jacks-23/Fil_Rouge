namespace FilRouge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Quizzs", newName: "QuizzClasses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.QuizzClasses", newName: "Quizzs");
        }
    }
}
