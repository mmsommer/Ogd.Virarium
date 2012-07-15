using System.Data;
using Migrator.Framework;

namespace Ogd.Virarium.Data.Migrations
{
    [Migration(201207152109)]
    public class InsertInfectionsTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Infections",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("MachineId", DbType.Int32, ColumnProperty.NotNull),
                new Column("VirusId", DbType.Int32, ColumnProperty.NotNull),
                new Column("StartDate", DbType.DateTime, ColumnProperty.NotNull),
                new Column("EndDate", DbType.DateTime, ColumnProperty.Null)
            );

            Database.AddForeignKey("FK_Infections_MachineId_Machines_Id", "Infections", "MachineId", "Machines", "Id");
            Database.AddForeignKey("FK_Infections_VirusId_Virusses_Id", "Infections", "VirusId", "Virusses", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("Infections");
        }
    }
}
