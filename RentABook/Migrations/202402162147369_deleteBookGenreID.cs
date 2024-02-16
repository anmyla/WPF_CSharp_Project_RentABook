namespace RentABook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBookGenreID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "BookGenre_GenreId1" });
            DropColumn("dbo.Books", "BookGenre_GenreId");
            RenameColumn(table: "dbo.Books", name: "BookGenre_GenreId1", newName: "BookGenre_GenreId");
            AlterColumn("dbo.Books", "BookGenre_GenreId", c => c.Int());
            CreateIndex("dbo.Books", "BookGenre_GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "BookGenre_GenreId" });
            AlterColumn("dbo.Books", "BookGenre_GenreId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Books", name: "BookGenre_GenreId", newName: "BookGenre_GenreId1");
            AddColumn("dbo.Books", "BookGenre_GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "BookGenre_GenreId1");
        }
    }
}
