namespace Ogd.Virarium.Data.Migrations
{
    using System.Data;
    using Migrator.Framework;

    [Migration(201208051016)]
    public class InsertMachinesTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Machines",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, ColumnProperty.NotNull),
                new Column("MachineType", DbType.Int32, ColumnProperty.NotNull)
            );
        }

        public override void Down()
        {
            Database.RemoveTable("Machines");
        }
    }
}
