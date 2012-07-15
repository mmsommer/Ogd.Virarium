using System.Data;
using Migrator.Framework;

namespace Ogd.Virarium.Data.Migrations
{
    [Migration(201207151416)]
    public class InsertVirussesTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Virusses",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, ColumnProperty.NotNull)
            );
        }

        public override void Down()
        {
            Database.RemoveTable("Virusses");
        }
    }
}
