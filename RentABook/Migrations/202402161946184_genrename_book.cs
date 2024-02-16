namespace RentABook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genrename_book : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "GenreName");
        }
    }
}
