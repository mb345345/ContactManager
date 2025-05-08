using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerDal.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static T GetValueOrDefault<T>(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(index))
                return default;

            return (T)reader.GetValue(index);
        }

        public static T? GetNullable<T>(this SqlDataReader reader, string columnName) where T : struct
        {
            int index = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(index))
                return null;

            return (T)reader.GetValue(index);
        }
    }
}
