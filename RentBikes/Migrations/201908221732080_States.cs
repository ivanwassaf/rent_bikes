namespace RentBikes.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class States : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into dbo.States (description) Values('Active');");
            Sql("INSERT into dbo.States (description) Values('Inactive');");
        }

        public override void Down()
        {
        }
    }
}
