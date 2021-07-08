namespace FilRouge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        MotDePasse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Niveau = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reponse = c.String(),
                        Difficulte = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.QuestionId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NbDeQuestions = c.Int(nullable: false),
                        Depart = c.DateTime(nullable: false),
                        Fin = c.DateTime(nullable: false),
                        Note = c.Int(nullable: false),
                        Niveau = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recruteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        MotDePasse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizzQuestions", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuizzQuestions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuizzQuestions", new[] { "QuestionId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuizzId" });
            DropTable("dbo.Recruteurs");
            DropTable("dbo.Quizzs");
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.Candidats");
            DropTable("dbo.Administrateurs");
        }
    }
}
