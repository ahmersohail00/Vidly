namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreandNaatFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Naats", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Naats", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Naats", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Naats", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Naats", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Naats", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Naats", "GenreId");
            AddForeignKey("dbo.Naats", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }  
        
        public override void Down()
        {
            DropForeignKey("dbo.Naats", "GenreId", "dbo.Genres");
            DropIndex("dbo.Naats", new[] { "GenreId" });
            AlterColumn("dbo.Naats", "Name", c => c.String());
            DropColumn("dbo.Naats", "NumberAvailable");
            DropColumn("dbo.Naats", "NumberInStock");
            DropColumn("dbo.Naats", "ReleaseDate");
            DropColumn("dbo.Naats", "DateAdded");
            DropColumn("dbo.Naats", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
