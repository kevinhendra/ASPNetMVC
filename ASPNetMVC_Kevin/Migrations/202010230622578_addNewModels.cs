namespace ASPNetMVC_Kevin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tb_M_Divisi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Divisi", "DepartmentId", "dbo.Tb_M_Department");
            DropIndex("dbo.Tb_M_Divisi", new[] { "DepartmentId" });
            DropTable("dbo.Tb_M_Divisi");
            DropTable("dbo.Tb_M_Department");
        }
    }
}
