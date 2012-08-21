namespace Ogd.Virarium.Data.Migrations
{
    using System.Data;
    using Migrator.Framework;

    [Migration(201208051026)]
    public class InsertConnectionsTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Connections",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("NICAId", DbType.Int32, ColumnProperty.NotNull),
                new Column("NICBId", DbType.Int32, ColumnProperty.NotNull)
            );

            Database.AddForeignKey("FK_Connections_NICAId_NICs_Id", "Connections", "NICAId", "NICs", "Id");
            Database.AddForeignKey("FK_Connections_NICBId_NICs_Id", "Connections", "NICBId", "NICs", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("Connections");
        }
    }
}
