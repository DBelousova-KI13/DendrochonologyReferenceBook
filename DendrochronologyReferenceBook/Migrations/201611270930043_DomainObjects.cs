namespace DendrochronologyReferenceBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainObjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Downloads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Measurement_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Measurement_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Literatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        DownloadFormat = c.String(),
                        Comment = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Measurements", "Specie_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "City_Id", c => c.Int());
            CreateIndex("dbo.Measurements", "Specie_Id");
            CreateIndex("dbo.AspNetUsers", "City_Id");
            AddForeignKey("dbo.Measurements", "Specie_Id", "dbo.Species", "Id");
            AddForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities", "Id");
            DropColumn("dbo.Measurements", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Measurements", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Literatures", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Downloads", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Downloads", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Measurements", "Specie_Id", "dbo.Species");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Literatures", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "City_Id" });
            DropIndex("dbo.Measurements", new[] { "Specie_Id" });
            DropIndex("dbo.Downloads", new[] { "User_Id" });
            DropIndex("dbo.Downloads", new[] { "Measurement_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropColumn("dbo.AspNetUsers", "City_Id");
            DropColumn("dbo.Measurements", "Specie_Id");
            DropTable("dbo.Rights");
            DropTable("dbo.Literatures");
            DropTable("dbo.Species");
            DropTable("dbo.Downloads");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
