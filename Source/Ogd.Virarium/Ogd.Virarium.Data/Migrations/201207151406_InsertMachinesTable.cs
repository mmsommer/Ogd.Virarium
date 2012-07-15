﻿using System.Data;
using Migrator.Framework;

namespace Ogd.Virarium.Data.Migrations
{
    [Migration(201207151406)]
    public class InsertMachinesTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Machines",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, ColumnProperty.NotNull)
            );
        }

        public override void Down()
        {
            Database.RemoveTable("Machines");
        }
    }
}
