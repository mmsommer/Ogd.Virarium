namespace Ogd.Virarium.Data.Migrations
{
    using System.Data;
    using Migrator.Framework;

    [Migration(201208051019)]
    public class InsertNICsTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "NICs",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("MachineId", DbType.Int32, ColumnProperty.NotNull),
                new Column("IpAddress", DbType.String)
            );

            Database.AddForeignKey("FK_NICs_MachineId_Machines_Id", "NICs", "MachineId", "Machines", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("NICs");
        }
    }
}
