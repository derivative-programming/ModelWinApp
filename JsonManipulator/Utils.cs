using JsonManipulator.Models;
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

        public static List<string> GetDBObjectNameList()
        {
            return GetNameList(true, false, false, false);
        }
        public static List<string> GetDestinationNameList()
        { 
            return GetNameList(false,true,true,false);
        }


        public static List<string> GetNameList(bool includeDBObjects, bool includeReports, bool includePageForms, bool includeNonPageObjFlows)
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            {
                if (includeDBObjects)
                {
                    result.Add(dbObject.name);
                }

                if (dbObject.objectWorkflow != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.IsPage != null)
                        {
                            if (includePageForms && 
                                !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                                !objWF.Name.Trim().ToLower().EndsWith("initobjwf"))
                            {
                                result.Add(objWF.Name);
                            }

                            if (includeNonPageObjFlows &&
                                !(
                                    !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                                    !objWF.Name.Trim().ToLower().EndsWith("initobjwf")
                                ))
                            {
                                result.Add(objWF.Name);
                            }
                        }
                        else
                        {

                            if (includePageForms &&
                                !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                                !objWF.Name.Trim().ToLower().EndsWith("initobjwf") && 
                                objWF.IsPage.Trim().ToLower() == "true")
                            {
                                result.Add(objWF.Name);
                            }

                            if (includeNonPageObjFlows && 
                                objWF.IsPage.Trim().ToLower() == "false")
                            {
                                result.Add(objWF.Name);
                            }
                        }
                    }
                }

                if (includeReports & dbObject.report != null)
                {
                    foreach (var rpt in dbObject.report)
                    {
                        result.Add(rpt.name);
                    }
                }

            } 

            return result;
        }

        public static List<string> GetRoleList()
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            {
                if (dbObject.objectWorkflow != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.RoleRequired != null && objWF.RoleRequired.Trim().Length > 0 && !result.Contains(objWF.RoleRequired))
                            result.Add(objWF.RoleRequired.Trim());

                    }
                }
                if (dbObject.report != null)
                {
                    foreach (var report in dbObject.report)
                    {
                        if (report.RoleRequired != null && report.RoleRequired.Trim().Length > 0 && !result.Contains(report.RoleRequired))
                            result.Add(report.RoleRequired.Trim());
                    }
                }

            }

            return result;
        }

        public static List<string> GetFormPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("IsPage");

            return result;
        }
        public static List<string> GetFormButtonPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("IsPage");

            return result;
        }
        public static List<string> GetDBObjPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("IsPage");

            return result;
        }
        public static List<string> GetReportPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("IsPage");

            return result;
        }
        public static List<string> GetReportButtonPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("IsPage");

            return result;
        }
        public static List<string> GetReportColumnPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("IsPage");

            return result;
        }

        public static Models.ObjectMap GetDestinationOwnerObject(string destinationName)
        {
            Models.ObjectMap result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            { 
                if (dbObject.objectWorkflow != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.Name.ToLower().Trim() == destinationName.ToLower().Trim())
                        {
                            result = dbObject;
                        }
                    }
                }

                if (dbObject.report != null)
                {
                    foreach (var rpt in dbObject.report)
                    { 
                        if (rpt.name.ToLower().Trim() == destinationName.ToLower().Trim())
                        {
                            result = dbObject;
                        }
                    }
                }

            }


            return result;
        }

        public static Models.Report GetReportModelItem(string name)
        {
            Models.Report result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            { 
                if (dbObject.report != null)
                {
                    foreach (var rpt in dbObject.report)
                    {
                        if (rpt.name.ToLower().Trim() == name.ToLower().Trim())
                        {
                            result = rpt;
                        }
                    }
                }

            }
            return result;
        }


        public static Models.objectWorkflow GetObjWFModelItem(string name)
        {
            Models.objectWorkflow result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            {
                if (dbObject.report != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.Name.ToLower().Trim() == name.ToLower().Trim())
                        {
                            result = objWF;
                        }
                    }
                }

            }
            return result;
        }


        public static Models.ObjectMap GetObjectModelItem(string name)
        {
            Models.ObjectMap result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            {
                if (dbObject.name.ToLower().Trim() == name.ToLower().Trim())
                {
                    result = dbObject;
                }
            }
            return result;
        }
    }
}
