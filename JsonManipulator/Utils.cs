using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulator
{
   public static class Utils
    {
        public static bool IsImplementationOfGenericType(this Type type, Type genericTypeDefinition)
        {
            if (!genericTypeDefinition.IsGenericTypeDefinition)
                return false;

            // looking for generic interface implementations
            if (genericTypeDefinition.IsInterface)
            {
                foreach (Type i in type.GetInterfaces())
                {
                    if (i.Name == genericTypeDefinition.Name && i.IsGenericTypeOf(genericTypeDefinition))
                        return true;
                }

                return false;
            }

            // looking for generic [base] types
            for (Type t = type; type != null; type = type.BaseType)
            {
                if (t.Name == genericTypeDefinition.Name && t.IsGenericTypeOf(genericTypeDefinition))
                    return true;
            }

            return false;
        }
        public static bool IsGenericTypeOf(this Type type, Type genericTypeDefinition) => type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition;
        public static DataTable getDataTypes()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("nvarchar", "nvarchar");
            _booleans.Rows.Add("bit", "bit");
            _booleans.Rows.Add("datetime", "datetime");
            _booleans.Rows.Add("uniqueidentifier", "uniqueidentifier");
            _booleans.Rows.Add("money", "money");
            _booleans.Rows.Add("bigint", "bigint");
            _booleans.Rows.Add("float", "float");
            _booleans.Rows.Add("decimal", "decimal");
            _booleans.Rows.Add("date", "date");
            _booleans.Rows.Add("varchar", "varchar");
            _booleans.Rows.Add("text", "text");
            return _booleans;
        }
        public static DataTable getBooleans()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("", "");
            _booleans.Rows.Add("true", "true");
            _booleans.Rows.Add("false", "false");
            return _booleans;
        }
        public static DataTable getButtons()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("submit", "submit");
            _booleans.Rows.Add("cancel", "cancel");
            _booleans.Rows.Add("other", "other");
            return _booleans;
        }
        public static DataTable getReportButtons()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("back", "back");
            _booleans.Rows.Add("add", "add");
            _booleans.Rows.Add("multiselectProcessing", "multiselectProcessing");
            _booleans.Rows.Add("breadcrumb", "breadcrumb");
            _booleans.Rows.Add("other", "other");
            return _booleans;
        }
        public static DataTable getVisualizationTypes()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("grid", "grid");
            _booleans.Rows.Add("detail", "detail");
            return _booleans;
        }
    }
}
