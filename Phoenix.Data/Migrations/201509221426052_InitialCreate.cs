namespace Phoenix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministrationLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IpAddress = c.String(),
                        RequestType = c.String(),
                        Url = c.String(),
                        PostParams = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FullName = c.String(maxLength: 50),
                        UrlId = c.String(),
                        Summary = c.String(maxLength: 140),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        DateRegister = c.DateTime(),
                        ContactInfo_Phone = c.String(),
                        ContactInfo_Twitter = c.String(),
                        ContactInfo_Website = c.String(),
                        ContactInfo_Facebook = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        AvatarURL_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.AvatarURL_Id)
                .Index(t => t.AvatarURL_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DatePublic = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        UrlId = c.String(),
                        AvatarURL_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Images", t => t.AvatarURL_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.AvatarURL_Id);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DatePublic = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        Url = c.String(),
                        UrlPhotos_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.UrlPhotos_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.UrlPhotos_Id);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdministrationLogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BlogPosts", "UrlPhotos_Id", "dbo.Images");
            DropForeignKey("dbo.BlogPosts", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Interviews", "AvatarURL_Id", "dbo.Images");
            DropForeignKey("dbo.Interviews", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AvatarURL_Id", "dbo.Images");
            DropIndex("dbo.BlogPosts", new[] { "UrlPhotos_Id" });
            DropIndex("dbo.BlogPosts", new[] { "AuthorId" });
            DropIndex("dbo.Interviews", new[] { "AvatarURL_Id" });
            DropIndex("dbo.Interviews", new[] { "AuthorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "AvatarURL_Id" });
            DropIndex("dbo.AdministrationLogs", new[] { "UserId" });
            DropTable("dbo.UserLanguages");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Interviews");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Images");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AdministrationLogs");
        }
    }
}
