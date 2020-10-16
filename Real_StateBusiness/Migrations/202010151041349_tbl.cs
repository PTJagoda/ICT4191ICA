namespace Real_StateBusiness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_tbl",
                c => new
                    {
                        BranchNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.BranchNo);
            
            CreateTable(
                "dbo.Owner_tbl",
                c => new
                    {
                        OwnerNo = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        TellNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerNo);
            
            CreateTable(
                "dbo.Rent_tbl",
                c => new
                    {
                        PropertyNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Ptype = c.String(),
                        Rooms = c.String(),
                        OwnerRef = c.String(maxLength: 128),
                        StaffRef = c.String(maxLength: 128),
                        BranchRef = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PropertyNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchRef)
                .ForeignKey("dbo.Owner_tbl", t => t.OwnerRef)
                .ForeignKey("dbo.Staff_tbl", t => t.StaffRef)
                .Index(t => t.OwnerRef)
                .Index(t => t.StaffRef)
                .Index(t => t.BranchRef);
            
            CreateTable(
                "dbo.Staff_tbl",
                c => new
                    {
                        StaffNo = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        Position = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        BranchRef = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchRef)
                .Index(t => t.BranchRef);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent_tbl", "StaffRef", "dbo.Staff_tbl");
            DropForeignKey("dbo.Staff_tbl", "BranchRef", "dbo.Branch_tbl");
            DropForeignKey("dbo.Rent_tbl", "OwnerRef", "dbo.Owner_tbl");
            DropForeignKey("dbo.Rent_tbl", "BranchRef", "dbo.Branch_tbl");
            DropIndex("dbo.Staff_tbl", new[] { "BranchRef" });
            DropIndex("dbo.Rent_tbl", new[] { "BranchRef" });
            DropIndex("dbo.Rent_tbl", new[] { "StaffRef" });
            DropIndex("dbo.Rent_tbl", new[] { "OwnerRef" });
            DropTable("dbo.Staff_tbl");
            DropTable("dbo.Rent_tbl");
            DropTable("dbo.Owner_tbl");
            DropTable("dbo.Branch_tbl");
        }
    }
}
