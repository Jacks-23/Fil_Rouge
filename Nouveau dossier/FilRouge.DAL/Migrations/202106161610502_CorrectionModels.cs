namespace FilRouge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrateurs", "Identifiant", c => c.String());
            AddColumn("dbo.QuizzClasses", "DateDeCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recruteurs", "Identifiant", c => c.String());
            DropColumn("dbo.QuizzClasses", "Depart");
            DropColumn("dbo.QuizzClasses", "Fin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizzClasses", "Fin", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuizzClasses", "Depart", c => c.DateTime(nullable: false));
            DropColumn("dbo.Recruteurs", "Identifiant");
            DropColumn("dbo.QuizzClasses", "DateDeCreation");
            DropColumn("dbo.Administrateurs", "Identifiant");
        }
    }
}
