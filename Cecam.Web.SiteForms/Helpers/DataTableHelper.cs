using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Cecam.Web.SiteForms.Helpers
{
    public static class DataTableHelper
    {
        public static DataTable ConvertListToTable<T>(IEnumerable<T> list)
        {
            DataTable table = CreateTable<T>();
            Type objectType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objectType);

            foreach(T item in list)
            {
                DataRow row = table.NewRow();

                foreach(PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) == null ? DBNull.Value : prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }
    }
}