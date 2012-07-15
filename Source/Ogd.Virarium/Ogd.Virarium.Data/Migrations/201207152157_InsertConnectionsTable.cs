using System.Data;
using Migrator.Framework;

namespace Ogd.Virarium.Data.Migrations
{
    [Migration(201207152157)]
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

            Database.AddColumn(
                "NICs",
                new Column("ConnectionId", DbType.Int32)
            );

            Database.AddForeignKey("FK_NICs_ConnectionId_Connections_Id", "NICs", "ConnectionId", "Connections", "Id");
        }

        public override void Down()
        {
            Database.RemoveForeignKey("NICs", "FK_NICs_ConnectionId_Connections_Id");
            Database.RemoveColumn("NICs", "ConnectionId");

            Database.RemoveTable("Connections");
        }
    }
}
