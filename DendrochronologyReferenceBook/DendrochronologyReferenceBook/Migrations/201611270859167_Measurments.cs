namespace DendrochronologyReferenceBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Measurments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PreviewUrl = c.String(),
                        SamplingYear = c.Int(nullable: false),
                        Data = c.String(),
                        LinkKoordinates = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "AvatarLink", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Measurements", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "AvatarLink");
            DropTable("dbo.Measurements");
        }
    }
}
