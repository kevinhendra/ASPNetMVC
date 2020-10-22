namespace ASPNetMVC_Kevin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelDepartmment : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_M_Department");
        }
    }
}
