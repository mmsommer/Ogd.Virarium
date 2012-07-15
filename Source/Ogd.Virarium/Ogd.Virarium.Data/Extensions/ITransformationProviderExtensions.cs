using System;
using Migrator.Framework;

namespace Ogd.Virarium.Data.Extensions
{
    public static class ITransformationProviderExtensions
    {
        public static int Insert(this ITransformationProvider database, string table, string[] columns, string[][] rows)
        {
            return Map(table, columns, rows, database.Insert);
        }

        public static int Delete(this ITransformationProvider database, string table, string[] columns, string[][] rows)
        {
            return Map(table, columns, rows, database.Delete);
        }

        private static int Map(string table, string[] columns, string[][] rows, Func<string, string[], string[], int> func)
        {
            var rowsAffected = 0;

            foreach (var values in rows)
            {
                rowsAffected += func(table, columns, values);
            }

            return rowsAffected;
        }
    }
}
