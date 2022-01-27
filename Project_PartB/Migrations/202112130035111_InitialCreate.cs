namespace Project_PartB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        a_id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 20),
                        description = c.String(nullable: false, maxLength: 50),
                        sub_date_time = c.DateTime(nullable: false, storeType: "date"),
                        oral_mark = c.Int(nullable: false),
                        total_mark = c.Int(nullable: false),
                        s_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.a_id)
                .ForeignKey("dbo.Students", t => t.s_id, cascadeDelete: true)
                .Index(t => t.s_id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        s_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 20),
                        last_name = c.String(nullable: false, maxLength: 20),
                        date_of_birth = c.DateTime(nullable: false, storeType: "date"),
                        tuitions_fees = c.Decimal(nullable: false, precision: 6, scale: 2),
                        c_id = c.Int(),
                    })
                .PrimaryKey(t => t.s_id)
                .ForeignKey("dbo.Courses", t => t.c_id)
                .Index(t => t.c_id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        c_id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        stream = c.String(nullable: false, maxLength: 20),
                        type = c.String(nullable: false, maxLength: 20),
                        start_date = c.DateTime(nullable: false, storeType: "date"),
                        end_date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.c_id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        t_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 20),
                        last_name = c.String(nullable: false, maxLength: 20),
                        subject = c.String(nullable: false, maxLength: 20),
                        c_id = c.Int(),
                    })
                .PrimaryKey(t => t.t_id)
                .ForeignKey("dbo.Courses", t => t.c_id)
                .Index(t => t.c_id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        p_id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 20),
                        description = c.String(nullable: false, maxLength: 50),
                        sub_date_time = c.DateTime(nullable: false),
                        oral_mark = c.Int(nullable: false),
                        total_mark = c.Int(nullable: false),
                        type = c.String(nullable: false, maxLength: 20),
                        s_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.p_id)
                .ForeignKey("dbo.Students", t => t.s_id, cascadeDelete: true)
                .Index(t => t.s_id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "s_id", "dbo.Students");
            DropForeignKey("dbo.Trainers", "c_id", "dbo.Courses");
            DropForeignKey("dbo.Students", "c_id", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "s_id", "dbo.Students");
            DropIndex("dbo.Projects", new[] { "s_id" });
            DropIndex("dbo.Trainers", new[] { "c_id" });
            DropIndex("dbo.Students", new[] { "c_id" });
            DropIndex("dbo.Assignments", new[] { "s_id" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Projects");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Assignments");
        }
    }
}
