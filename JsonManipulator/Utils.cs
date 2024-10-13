using JsonManipulator.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            _booleans.Rows.Add("bigint", "bigint");
            _booleans.Rows.Add("bit", "bit");
            _booleans.Rows.Add("date", "date");
            _booleans.Rows.Add("datetime", "datetime");
            _booleans.Rows.Add("decimal", "decimal");
            _booleans.Rows.Add("float", "float");
            _booleans.Rows.Add("int", "int");
            _booleans.Rows.Add("money", "money");
            _booleans.Rows.Add("nvarchar", "nvarchar");
            _booleans.Rows.Add("text", "text");
            _booleans.Rows.Add("uniqueidentifier", "uniqueidentifier");
            _booleans.Rows.Add("varchar", "varchar");
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
        public static DataTable getAutoCompleteAddressTargetTypes()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("", "");
            _booleans.Rows.Add("AddressLine1", "AddressLine1");
            _booleans.Rows.Add("AddressLine2", "AddressLine2");
            _booleans.Rows.Add("City", "City");
            _booleans.Rows.Add("StateAbbrev", "StateAbbrev");
            _booleans.Rows.Add("Zip", "Zip");
            _booleans.Rows.Add("Country", "Country");
            _booleans.Rows.Add("Latitude", "Latitude");
            _booleans.Rows.Add("Longitude", "Longitude");
            return _booleans;
        }
        public static DataTable getNavButtonTypes()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("", "");
            _booleans.Rows.Add("primary", "primary");
            _booleans.Rows.Add("secondary", "secondary");
            return _booleans;
        }
        public static List<string> getBooleanList()
        {
            List<string> _booleans = new List<string>(); 
            _booleans.Add("");
            _booleans.Add("true");
            _booleans.Add("false");
            return _booleans;
        }
        public static List<string> getNavButtonList()
        {
            List<string> _booleans = new List<string>();
            _booleans.Add("");
            _booleans.Add("primary");
            _booleans.Add("secondary");
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
            _booleans.Rows.Add("multiSelectProcessing", "multiSelectProcessing");
            _booleans.Rows.Add("breadcrumb", "breadcrumb");
            _booleans.Rows.Add("other", "other");
            return _booleans;
        }
        public static DataTable getVisualizationTypes()
        {
            DataTable _booleans = new DataTable();
            _booleans.Columns.Add("Display");
            _booleans.Columns.Add("Value");
            _booleans.Rows.Add("BarChart", "BarChart");
            _booleans.Rows.Add("Cards", "Cards");
            _booleans.Rows.Add("DetailTwoColumn", "DetailTwoColumn");
            _booleans.Rows.Add("DetailThreeColumn", "DetailThreeColumn");
            _booleans.Rows.Add("FlowChart", "FlowChart");
            _booleans.Rows.Add("FolderWithDetail", "FolderWithDetail");
            _booleans.Rows.Add("Grid", "Grid");
            _booleans.Rows.Add("LineChart", "LineChart");
            _booleans.Rows.Add("PieChart", "PieChart");
            return _booleans;
        }

        public static List<string> GetApiSiteNameList()
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();

            if (nameSpaceObject.apiSite == null)
                return result;

            foreach (var apiSite in nameSpaceObject.apiSite)
            {
                result.Add(apiSite.name); 
            }

            return result;
        }
        public static List<string> GetDBObjectNameList()
        {
            return GetNameList(true, false, false, false, false);
        }
        public static List<string> GetDestinationNameList()
        { 
            return GetNameList(false,true,true,false, false);
        }


        public static List<string> GetDFTList()
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            { 

                if (dbObject.objectWorkflow != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask == "true")
                        {
                            result.Add(objWF.Name);
                            continue;
                        } 
                    }
                } 
            }

            return result;
        }



        public static List<string> GetLookupList()
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            {

                if (dbObject.isLookup == "true")
                {
                    result.Add(dbObject.name);
                }
            }

            return result;
        }
        public static List<string> GetNameList(bool includeDBObjects, bool includeReports, bool includePageForms, 
            bool includeNonPageObjFlows, bool includeInitPageObjFlows)
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
                        if(includePageForms)
                        {
                            if (Utils.IsObjectWorkflowAForm(objWF))
                            {
                                result.Add(objWF.Name);
                                continue;
                            } 
                        }
                        if (includeNonPageObjFlows)
                        {
                            if (Utils.IsObjectWorkflowAFlow(objWF) &&
                                !Utils.IsObjectWorkflowAPageInitFlow(objWF))
                            {
                                result.Add(objWF.Name);
                                continue;
                            } 
                        }
                        if (includeInitPageObjFlows)
                        {
                            if (Utils.IsObjectWorkflowAFlow(objWF) &&
                                Utils.IsObjectWorkflowAPageInitFlow(objWF))
                            {
                                result.Add(objWF.Name);
                                continue;
                            }
                        }
                        //if (objWF.IsPage == null)
                        //{
                        //    if (includePageForms && 
                        //        !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                        //        !objWF.Name.Trim().ToLower().EndsWith("initobjwf"))
                        //    {
                        //        result.Add(objWF.Name);
                        //        continue;
                        //    }

                        //    if (includeNonPageObjFlows &&
                        //        !(
                        //            !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                        //            !objWF.Name.Trim().ToLower().EndsWith("initobjwf")
                        //        ))
                        //    {
                        //        result.Add(objWF.Name);
                        //        continue;
                        //    }
                        //}
                        //else
                        //{

                        //    if (includePageForms &&
                        //        !objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                        //        !objWF.Name.Trim().ToLower().EndsWith("initobjwf") && 
                        //        objWF.IsPage.Trim().ToLower() == "true")
                        //    {
                        //        result.Add(objWF.Name);
                        //        continue;
                        //    }

                        //    if (includeNonPageObjFlows && 
                        //        objWF.IsPage.Trim().ToLower() == "false")
                        //    {
                        //        result.Add(objWF.Name);
                        //        continue;
                        //    }
                        //}
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

        public static property GetObjectPropListSelection(string targetObjectName, string fullyQualifiedLineageSelected)
        {
            property result = null;

            
            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();

            string nextObjectName = targetObjectName;

            bool done = false;
            while (!done)
            {
                bool itemAdded = false;
                foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
                {
                    if (!dbObject.name.Equals(nextObjectName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    foreach (property prop in dbObject.property)
                    {
                        if (fullyQualifiedLineageSelected == dbObject.name + "." + prop.name)
                        {
                                return prop;

                        }
                        if (prop.isFKLookup == "true" && !prop.fKObjectName.Equals("pac",StringComparison.OrdinalIgnoreCase))
                        {
                            List<string> lookupProps = GetObjectPropList(prop.fKObjectName, false);
                            for(int i = 0;i < lookupProps.Count;i++)
                            {
                                if (fullyQualifiedLineageSelected == dbObject.name + "." + lookupProps[i])
                                {
                                    return GetObjectPropListSelection(prop.fKObjectName,fullyQualifiedLineageSelected.Remove(0, (dbObject.name + ".").Length));

                                }
                            }

                        }
                        itemAdded = true;
                    }
                    if(dbObject.parentObjectName != null &&
                        dbObject.parentObjectName.Trim().Length > 0 &&
                        !dbObject.parentObjectName.Trim().Equals("Tac",StringComparison.OrdinalIgnoreCase) &&
                        !dbObject.parentObjectName.Trim().Equals("Pac", StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        nextObjectName = dbObject.parentObjectName;
                    }
                    else
                    {
                        done = true;
                    }
                }
                if(!itemAdded)
                {
                    done = true;
                }
            }

            return result;
        }
        public static ObjectMap GetObjectPropListSelectionParentObj(string targetObjectName, string fullyQualifiedLineageSelected)
        {
            ObjectMap result = null;


            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();

            string nextObjectName = targetObjectName;

            bool done = false;
            while (!done)
            {
                bool itemAdded = false;
                foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
                {
                    if (!dbObject.name.Equals(nextObjectName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    foreach (property prop in dbObject.property)
                    {
                        if (fullyQualifiedLineageSelected == dbObject.name + "." + prop.name)
                        {
                            return dbObject;

                        }
                        if (fullyQualifiedLineageSelected == dbObject.name + ".Code")
                        {
                            return dbObject;

                        }
                        if (prop.isFKLookup == "true" && !prop.fKObjectName.Equals("pac", StringComparison.OrdinalIgnoreCase))
                        {
                            List<string> lookupProps = GetObjectPropList(prop.fKObjectName, false);
                            for (int i = 0; i < lookupProps.Count; i++)
                            {
                                if (fullyQualifiedLineageSelected == dbObject.name + "." + lookupProps[i])
                                {
                                    return GetObjectPropListSelectionParentObj(prop.fKObjectName, fullyQualifiedLineageSelected.Remove(0, (dbObject.name + ".").Length));

                                }
                            }

                        }
                        itemAdded = true;
                    }
                    if (dbObject.parentObjectName != null &&
                        dbObject.parentObjectName.Trim().Length > 0 &&
                        !dbObject.parentObjectName.Trim().Equals("Tac", StringComparison.OrdinalIgnoreCase) &&
                        !dbObject.parentObjectName.Trim().Equals("Pac", StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        nextObjectName = dbObject.parentObjectName;
                    }
                    else
                    {
                        done = true;
                    }
                }
                if (!itemAdded)
                {
                    done = true;
                }
            }

            return result;
        }


        public static List<string> GetObjectPropList(string targetObjectName, bool includeLineage)
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();

            string nextObjectName = targetObjectName;

            bool done = false;
            while (!done)
            {
                bool itemAdded = false;
                foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
                {
                    if (!dbObject.name.Equals(nextObjectName, StringComparison.OrdinalIgnoreCase))
                        continue;
                    result.Add(dbObject.name + ".Code");
                    result.Add(dbObject.name + "." + dbObject.name + "ID");
                    foreach (property prop in dbObject.property)
                    {
                        result.Add(dbObject.name + "." + prop.name);
                        if(prop.isFKLookup == "true" && !prop.fKObjectName.Equals("pac",StringComparison.OrdinalIgnoreCase))
                        {
                            List<string> lookupProps = GetObjectPropList(prop.fKObjectName, false);
                            for(int i = 0;i < lookupProps.Count;i++)
                            {
                                result.Add(dbObject.name + "." + lookupProps[i]);
                            }

                        }
                        itemAdded = true;
                    }
                    if(includeLineage && dbObject.parentObjectName != null &&
                        dbObject.parentObjectName.Trim().Length > 0 &&
                        !dbObject.parentObjectName.Trim().Equals("Tac",StringComparison.OrdinalIgnoreCase) &&
                        !dbObject.parentObjectName.Trim().Equals("Pac", StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        nextObjectName = dbObject.parentObjectName;
                    }
                    else
                    {
                        done = true;
                    }
                }
                if(!itemAdded)
                {
                    done = true;
                }
            }
            return result;
        }


        public static List<string> GetReportColList(string targetReportName, bool booleanColumnsOnly = false)
        {
            List<string> result = new List<string>();

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
              
            bool itemAdded = false;
            foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
            {
                if (dbObject.report == null)
                    continue;
                foreach (Report report in dbObject.report)
                {
                    if (!report.name.Equals(targetReportName, StringComparison.OrdinalIgnoreCase))
                        continue;
                    foreach (reportColumn col in report.reportColumn)
                    {
                        if(booleanColumnsOnly &&
                            col.dataType != null &&
                            col.dataType.Equals("bit",StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(col.name);
                        }
                        else
                        {
                            if(!booleanColumnsOnly)
                                result.Add(col.name);
                        }
                        itemAdded = true;
                    }
                    break;
                }
                if (itemAdded)
                {
                    break;
                }
            }

            return result;
        }


        public static Report GetReport(string targetReportName)
        {
            Report result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
             
            foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
            {
                foreach (Report report in dbObject.report)
                {
                    if (!report.name.Equals(targetReportName, StringComparison.OrdinalIgnoreCase))
                        continue;
                    return report;
                } 
            }

            return result;
        }

        public static ObjectMap GetReportOwnerObject(string targetReportName)
        {
            ObjectMap result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();

            foreach (ObjectMap dbObject in nameSpaceObject.ObjectMap)
            {
                foreach (Report report in dbObject.report)
                {
                    if (!report.name.Equals(targetReportName, StringComparison.OrdinalIgnoreCase))
                        continue;
                    return dbObject;
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

        public static List<string> GetRootPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("apiVersion".ToLower());
            result.Add("isValidationMissesLogged".ToLower());
            result.Add("suppressFillObjLookupTableScripts".ToLower());
           // result.Add("isDatabaseAuditColumnsCreated".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetNavButtonPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("destinationContextObjectName".ToLower());
            //result.Add("isEnabled".ToLower());
            result.Add("conditionalVisiblePropertyName".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetModelFeaturePropertiesToIgnore()
        {
            List<string> result = new List<string>(); 

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetFormPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("ispage");
            result.Add("name");

            result.Add("initObjectWorkflowName");
            //result.Add("isInitObjWFSubscribedToParams");
            //result.Add("isExposedInBusinessObject");
            result.Add("isObjectDelete");
            //result.Add("layoutName");
            result.Add("isWFSWorkflowCreated");
         //   result.Add("formTitleText");
         //   result.Add("formIntroText");
            //result.Add("formFooterText");
            result.Add("formFooterImageURL");
            //result.Add("isAutoSubmit");
            //result.Add("isHeaderVisible");
         //   result.Add("isLoginPage");
            //result.Add("isLogoutPage");
            result.Add("isImpersonationPage");
            //result.Add("isCaptchaVisible");
            result.Add("isCreditCardEntryUsed");
            result.Add("headerImageURL");
            result.Add("footerImageURL");
            result.Add("isDynaFlow");
            result.Add("isDynaFlowTask");
            result.Add("isCustomPageViewUsed");
            result.Add("isIgnoredInDocumentation");
            //result.Add("targetChildObject");
            //result.Add("isAuthorizationRequired");

            for(int i = 0;i < result.Count;i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetFlowPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("ispage");
            result.Add("name");

            result.Add("IntroText");
            result.Add("TitleText");
            result.Add("initObjectWorkflowName");
            result.Add("isInitObjWFSubscribedToParams");
            //result.Add("isExposedInBusinessObject");
            result.Add("isObjectDelete");
            result.Add("layoutName");
            result.Add("isWFSWorkflowCreated");
            result.Add("formTitleText");
            result.Add("formIntroText");
            result.Add("formFooterText");
            result.Add("formFooterImageURL");
            result.Add("isAutoSubmit");
            result.Add("isHeaderVisible");
            result.Add("isLoginPage");
            result.Add("isLogoutPage");
            result.Add("isImpersonationPage");
            result.Add("isCaptchaVisible");
            result.Add("isCreditCardEntryUsed");
            result.Add("headerImageURL");
            result.Add("footerImageURL");
            //result.Add("isDynaFlow");
            //result.Add("isDynaFlowTask");
            result.Add("isCustomPageViewUsed");
            result.Add("isIgnoredInDocumentation");
            result.Add("targetChildObject");
            //result.Add("isAuthorizationRequired");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetFormButtonPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("destinationContextObjectName".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetFormOutputVarPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            //result.Add("destinationContextObjectName".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }


        public static List<string> GetFormParamPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            //result.Add("isRequired".ToLower());
            //result.Add("requiredErrorText".ToLower());
            //result.Add("isSecured".ToLower());
            //result.Add("isFK".ToLower());
            //result.Add("fKObjectName".ToLower());
            result.Add("fKObjectQueryName".ToLower());
            //result.Add("isFKLookup".ToLower());
            //result.Add("isFKList".ToLower());
            //result.Add("isFKListInactiveIncluded".ToLower());
            //result.Add("isFKListUnknownOptionRemoved".ToLower());
            //result.Add("fKListOrderBy".ToLower());
            result.Add("isFKListOptionRecommended".ToLower());
            //.Add("isFKListSearchable".ToLower());
            result.Add("FKListRecommendedOption".ToLower());
            //result.Add("isRadioButtonList".ToLower());
            //result.Add("isFileUpload".ToLower());
            result.Add("isCreditCardEntry".ToLower());
            result.Add("isTimeZoneDetermined".ToLower());
            //result.Add("detailsText".ToLower());
            //result.Add("validationRuleRegExMatchRequired".ToLower());
            //result.Add("validationRuleRegExMatchRequiredErrorText".ToLower());
            //result.Add("isIgnored".ToLower());
            result.Add("defaultValue".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetFormDFTPropertiesToIgnore()
        {
            List<string> result = new List<string>();

            result.Add("name".ToLower());
            result.Add("contextObjectName".ToLower());
            result.Add("isDynaFlowRequest".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetDBObjPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            result.Add("calculatedProp".ToLower());
            result.Add("propSubscription".ToLower());
            result.Add("fetch".ToLower());
            result.Add("query".ToLower());
            result.Add("modelPkg".ToLower());
            result.Add("childObject".ToLower());
            result.Add("isLookup".ToLower());
            //result.Add("isSoftDeleteUsed".ToLower());
            //result.Add("cacheAllRecs".ToLower());
            //result.Add("cacheIndividualRecs".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetDBObjPropPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            //result.Add("isFKLookup".ToLower());
            //result.Add("isNotPublishedToSubscriptions".ToLower());
            //result.Add("fKObjectName".ToLower());
            //result.Add("fKObjectPropertyName".ToLower());
            //result.Add("isQueryByAvailable".ToLower());
            result.Add("defaultValue".ToLower());
            result.Add("name");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetDBObjLookupItemPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name".ToLower()); 

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetReportPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            result.Add("initObjectWorkflowName".ToLower());
            //result.Add("isAutoRefresh".ToLower());
            //result.Add("isAutoRefreshVisible".ToLower());
            //result.Add("isAutoRefreshFrequencyVisible".ToLower());
            //result.Add("isAutoRefreshDegraded".ToLower());
            //result.Add("isRefreshButtonHidden".ToLower());
            //result.Add("autoRefreshFrequencyInMinutes".ToLower()); 
            //result.Add("defaultOrderByDescending".ToLower());
            //result.Add("layoutName".ToLower());
            //result.Add("isExportButtonsHidden".ToLower());
            //result.Add("isFilterSectionHidden".ToLower());
            result.Add("isCachingAllowed".ToLower());
            //result.Add("isButtonDropDownAllowed".ToLower());
            //result.Add("ratingLevelColumnName".ToLower());
            //result.Add("isRatingLevelChangingRowBackgroundColor".ToLower());
            result.Add("cacheExpirationInMinutes".ToLower());
            //result.Add("isFilterSectionCollapsable".ToLower());
            //result.Add("isBreadcrumbSectionHidden".ToLower());
            //result.Add("isSchedulingAllowed".ToLower());
            //result.Add("isFavoriteCreationAllowed".ToLower());
            result.Add("badgeCountPropertyName".ToLower());

            result.Add("isHeaderLabelsVisible".ToLower());
            //result.Add("isHeaderVisible".ToLower());
            result.Add("isReportDetailLabelColumnVisible".ToLower());
            //.Add("noRowsReturnedText".ToLower());
            result.Add("formIntroText".ToLower());
            result.Add("isIgnoredInDocumentation".ToLower());
            result.Add("isAzureBlobStorageUsed".ToLower());
           // result.Add("isAzureTableUsed".ToLower());
            result.Add("azureTableNameOverride".ToLower());
          //  result.Add("azureTablePrimaryKeyColumn".ToLower());
            result.Add("isAzureTablePrimaryKeyColumnDateTime".ToLower());
            result.Add("visualizationGridGroupByColumnName".ToLower());
            result.Add("visualizationGridGroupByInfoTextColumnName".ToLower());
            result.Add("visualizationPieChartSliceValueColumnName".ToLower());
            result.Add("visualizationPieChartSliceDescriptionColumnName".ToLower());
            result.Add("visualizationLineChartUTCDateTimeColumnName".ToLower());
            result.Add("visualizationLineChartValueColumnName".ToLower());
            result.Add("visualizationLineChartDescriptionColumnName".ToLower());
            result.Add("isVisualizationLineChartGridHorizLineHidden".ToLower());
            result.Add("isVisualizationLineChartGridVerticalLineHidden".ToLower());
            result.Add("isVisualizationLineChartLegendHidden".ToLower());
            result.Add("isVisualizationLineChartStairLines".ToLower());
            result.Add("visualizationLineChartGridVerticalMaxValue".ToLower());
            result.Add("visualizationLineChartGridVerticalMinValue".ToLower());
            result.Add("visualizationLineChartGridVerticalStepValue".ToLower());
            result.Add("isVisualizationLineChartVerticalLabelsHidden".ToLower());
            result.Add("visualizationLineChartGridVerticalTitle".ToLower());
            result.Add("visualizationLineChartGridHorizTitle".ToLower());
            result.Add("visualizationLineChartGridVerticalMaxValLabel".ToLower());
            result.Add("visualizationLineChartGridVerticalMinValLabel".ToLower());
            result.Add("isVisualizationLineChartGridVerticalMaxDynamic".ToLower());
            result.Add("visualizationFlowChartSourceNodeCodeColumnName".ToLower());
            result.Add("visualizationFlowChartSourceNodeDescriptionColumnName".ToLower());
            result.Add("visualizationFlowChartSourceNodeColorColumnName".ToLower());
            result.Add("visualizationFlowChartFlowDescriptionColumnName".ToLower());
            result.Add("visualizationFlowChartDestinationNodeCodeColumnName".ToLower());
            result.Add("visualizationCardViewTitleColumn".ToLower());
            result.Add("visualizationCardViewDescriptionColumn".ToLower());
            result.Add("visualizationCardViewIsImageAvailable".ToLower());
            result.Add("visualizationCardViewImageColumn".ToLower());
            result.Add("visualizationCardViewGroupByColumnName".ToLower());
            result.Add("visualizationCardViewGroupByInfoTextColumnName".ToLower());
            result.Add("visualizationFolderIDColumnName".ToLower());
            result.Add("visualizationFolderNameColumnName".ToLower());
            result.Add("visualizationFolderParentIDColumnName".ToLower());
            result.Add("visualizationFolderIsFolderColumnName".ToLower());
            result.Add("visualizationFolderIsDragDropAllowed".ToLower());
            result.Add("visualizationFolderDragDropEventContextObjectName".ToLower());
            result.Add("visualizationFolderDragDropEventTargetName".ToLower());
            result.Add("isPage".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetReportButtonPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("destinationContextObjectName".ToLower());
            //result.Add("isEnabled".ToLower());
           // result.Add("conditionalVisiblePropertyName".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetReportFilterPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            //result.Add("isFKList".ToLower());
            //result.Add("isFKListInactiveIncluded".ToLower());
            result.Add("fKObjectName".ToLower());
            result.Add("isFK".ToLower());
            result.Add("isFKLookup".ToLower());
            result.Add("fKListOrderBy".ToLower());
            //result.Add("isFKListSearchable".ToLower());
            result.Add("isUnknownLookupAllowed".ToLower());
            result.Add("defaultValue".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetReportColumnPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("buttonDestinationContextObjectName".ToLower());
            //result.Add("minWidth".ToLower());
            //result.Add("name");
            //result.Add("isButton".ToLower());
            //result.Add("buttonText".ToLower());
            //result.Add("buttonDestinationTargetName".ToLower());

            result.Add("maxWidth".ToLower());
            result.Add("dateTimeDisplayFormat".ToLower());
            //result.Add("infoToolTipText".ToLower());
            //result.Add("isButtonCallToAction".ToLower());
            //result.Add("isHtml".ToLower());
            result.Add("isColumnSumMetricAvailable".ToLower());
            result.Add("isSummaryDisplayed".ToLower());
            result.Add("isConditionallyDisplayed".ToLower());
           // result.Add("isFilterAvailable".ToLower());
            //result.Add("conditionalSqlLogic".ToLower());
            //result.Add("isUnixEpochDateTime".ToLower());
            // result.Add("isNavURL".ToLower());
            // result.Add("NavURLLinkText".ToLower());
            result.Add("isButtonClickedOnRowClick".ToLower());
            //result.Add("isMultiSelectColumn".ToLower());
            result.Add("isForcedIntoExport".ToLower());
            //result.Add("isButtonAsyncObjWF".ToLower());

            //result.Add("isAsyncObjWFResultFileStreamedOut".ToLower());
            //result.Add("asyncObjWFResultFilePathParamName".ToLower());
            //result.Add("isJoinedToLeftColumn".ToLower());
            //result.Add("isJoinedToRightColumn".ToLower());
            //result.Add("conditionalVisiblePropertyName".ToLower());
            result.Add("buttonBadgeCountPropertyName".ToLower());
            result.Add("isFormFooter".ToLower());
            //result.Add("isImageURL".ToLower());
            result.Add("isEncrypted".ToLower());
            //result.Add("isIgnored".ToLower());

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }


        public static List<string> GetApiSitePropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }
        public static List<string> GetApiSiteEnvironmentPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetApiSiteEndPointPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name"); 
            result.Add("apiGetContextObjectName");
            result.Add("apiPostContextObjectName");
            result.Add("apiPutContextObjectName");
            result.Add("apiDeleteContextObjectName");
            result.Add("apiDeleteContextObjectName");
            result.Add("isAPIAuthorizationRequired");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }


        public static List<string> GetDBObjModelServiceSubPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("name");
            result.Add("isImported");
            result.Add("isSubscriptionAllowed");
            result.Add("role");
            result.Add("pkgType"); 

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static List<string> GetDBObjPropSubPropertiesToIgnore()
        {
            List<string> result = new List<string>();
            result.Add("destinationTargetName");
            result.Add("destinationContextObjectName");

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].ToLower();
            }

            return result;
        }

        public static Models.ObjectMap GetOwnerObject(string name)
        {
            Models.ObjectMap result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var dbObject in nameSpaceObject.ObjectMap)
            { 
                if (dbObject.objectWorkflow != null)
                {
                    foreach (var objWF in dbObject.objectWorkflow)
                    {
                        if (objWF.Name.ToLower().Trim() == name.ToLower().Trim())
                        {
                            result = dbObject;
                        }
                    }
                }

                if (dbObject.report != null)
                {
                    foreach (var rpt in dbObject.report)
                    { 
                        if (rpt.name.ToLower().Trim() == name.ToLower().Trim())
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

        public static Models.apiSite GetApiSiteModelItem(string name)
        {
            Models.apiSite result = null;

            NameSpaceObject nameSpaceObject = Form1._model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var apiSite in nameSpaceObject.apiSite)
            { 
                if (apiSite.name.ToLower().Trim() == name.ToLower().Trim())
                {
                    result = apiSite;
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
                if (dbObject.objectWorkflow != null)
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

        public static bool IsObjectWorkflowAForm(Models.objectWorkflow objWF)
        {
            bool result = false;
            if (objWF.isPage == null)
            {
                if (objWF.isRequestRunViaDynaFlowAllowed != null && objWF.isRequestRunViaDynaFlowAllowed.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (!objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                    !objWF.Name.Trim().ToLower().EndsWith("initobjwf"))
                {
                    result = true;
                } 
            }
            else
            {

                if (objWF.isPage.Trim().ToLower() == "true")
                {
                    result = true;
                } 
            }
            return result;
        }

        public static bool IsObjectWorkflowAFlow(Models.objectWorkflow objWF)
        { 
            return !IsObjectWorkflowAForm(objWF);
        }


        public static bool IsObjectWorkflowAPageInitFlow(Models.objectWorkflow objWF)
        {
            bool result = false;

            if (objWF.isPage == null)
            {
                if (objWF.isRequestRunViaDynaFlowAllowed != null && objWF.isRequestRunViaDynaFlowAllowed.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (!(!objWF.Name.Trim().ToLower().EndsWith("initreport") &&
                    !objWF.Name.Trim().ToLower().EndsWith("initobjwf")))
                {
                    result = true;
                }
            }
            else
            {
                 
                if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (objWF.isPage.Trim().ToLower() == "false" &&
                    (objWF.Name.Trim().ToLower().EndsWith("initreport") ||
                    objWF.Name.Trim().ToLower().EndsWith("initobjwf")))
                {
                    result = true;
                }
            }

            return result;
        }


        public static bool IsObjectWorkflowADynaFlow(Models.objectWorkflow objWF)
        {
            bool result = false;

            if (objWF.isRequestRunViaDynaFlowAllowed != null && objWF.isRequestRunViaDynaFlowAllowed.Trim().ToLower() == "true")
            {
                result = true;
            }

            return result;
        }

        public static bool IsObjectWorkflowADynaFlowTask(Models.objectWorkflow objWF)
        {
            bool result = false;

            if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask.Trim().ToLower() == "true")
            {
                result = true;
            }

            return result;
        }

        public static void SortJsonFile(string sourceFile)
        {
            // string sourceFile = soureFolder + @"codegenerator.model.json"; 
            string initialModel = System.IO.File.ReadAllText(sourceFile);
            var model = JObject.Parse(initialModel);

            model = SortJsonProperties(model);
            JObject fullModel = JObject.Parse(model.ToString());
            SortJsonFile(ref fullModel);
             
            System.IO.File.WriteAllText(sourceFile, fullModel.ToString());

        }


        public static JObject SortJsonProperties(JObject jsonObject)
        {
            var sortedObject = new JObject();

            // Sort the properties alphabetically
            foreach (var property in jsonObject.Properties().OrderBy(p => p.Name))
            {
                // Recursively sort properties if the property value is an object or array
                if (property.Value is JObject childObject)
                {
                    sortedObject[property.Name] = SortJsonProperties(childObject);
                }
                else if (property.Value is JArray array)
                {
                    sortedObject[property.Name] = SortJsonArray(array);
                }
                else
                {
                    sortedObject[property.Name] = property.Value;
                }
            }

            return sortedObject;
        }

        private static JArray SortJsonArray(JArray array)
        {
            var sortedArray = new JArray();

            foreach (var item in array)
            {
                if (item is JObject childObject)
                {
                    sortedArray.Add(SortJsonProperties(childObject));
                }
                else
                {
                    sortedArray.Add(item);
                }
            }

            return sortedArray;
        }




        private static void SortJsonFile(ref JObject fullModel)
        {
            var objArray = fullModel.SelectTokens("$.root.namespace[*].object[*]");
            var sortedJson = fullModel.SelectTokens("$.root.namespace[*].object[*]").OrderBy(x => ((JObject)x).Property("name").Value.ToString()).ToList();

            for (var i = 0; i < objArray.Count(); i++)
            { 
                fullModel.SelectToken("$.root.namespace[*].object[" + i.ToString() + "]").Replace(sortedJson[i]);
                 

                var prop = fullModel.SelectTokens("$.root.namespace[*].object[" + i.ToString() + "].prop[*]").OrderBy(x => ((JObject)x).Property("name").Value.ToString()).ToList();
                for (var p = 0; p < prop.Count(); p++)
                {
                    fullModel.SelectToken("$.root.namespace[*].object[" + i.ToString() + "].prop[" + p.ToString() + "]").Replace(prop[p]);
                }



                var reports = fullModel.SelectTokens("$.root.namespace[*].object[" + i.ToString() + "].report[*]").OrderBy(x => ((JObject)x).Property("name").Value.ToString()).ToList();
                for (var r = 0; r < reports.Count(); r++)
                {
                    fullModel.SelectToken("$.root.namespace[*].object[" + i.ToString() + "].report[" + r.ToString() + "]").Replace(reports[r]);
                }

                var objectWorkflow = fullModel.SelectTokens("$.root.namespace[*].object[" + i.ToString() + "].objectWorkflow[*]").OrderBy(x => ((JObject)x).Property("name").Value.ToString()).ToList();
                for (var o = 0; o < objectWorkflow.Count(); o++)
                {
                    fullModel.SelectToken("$.root.namespace[*].object[" + i.ToString() + "].objectWorkflow[" + o.ToString() + "]").Replace(objectWorkflow[o]);
                }

            }


        }

        public static string GetFirstPropertyValue(ref JObject fullModel, string xpath, string propertyName)
        {
            string result = string.Empty;
            JToken jTokenResult = null;

            foreach ( JToken jToken in fullModel.SelectTokens(xpath,true))
            {
                jTokenResult = jToken;
            }

            //JToken jToken = fullModel.SelectToken(xpath, true);

            result = ((JObject)jTokenResult).Property(propertyName).Value.ToString();

            return result;
        }


        public static void UpdatePropertyValue(ref JObject fullModel,string xpath,string propertyName, string newValue)
        {

            JToken jToken = fullModel.SelectToken(xpath, true);

            ((JObject)jToken).Property(propertyName).Value = newValue;

        }


        public static string Capitalize(string value)
        {
            //Regex.Replace("ThisIsMyCapsDelimitedString", "(\\B[A-Z])", " $1")
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static string ConvertPascalToSpaced(string value)
        {
            return Regex.Replace(value, "(\\B[A-Z])", " $1").Replace("_", " ").Replace("  ", " "); 
        }

        public static string GetProjectName()
        {

            return ((Form1)Application.OpenForms["Form1"]).GetProjectName();
        }
        public static string GetProjectVersionNumber()
        {

            return ((Form1)Application.OpenForms["Form1"]).GetProjectVersionNumber();
        }

        public static Models.propSubscription GetPropSubscriptionFor(Models.ObjectMap objectMap, string name)
        {
            Models.propSubscription result = null;
             
            if (objectMap.propSubscription == null)
            {
                objectMap.propSubscription = new List<propSubscription>();
            }

            if (objectMap.propSubscription.Where(x => x.destinationTargetName == name).ToList().Count > 0)
            {
                result = objectMap.propSubscription.Where(x => x.destinationTargetName == name).FirstOrDefault();
            }

            return result;
        }
         
        public static bool IsPropSubscriptionEnabledFor(Models.ObjectMap objectMap, string name)
        {
            bool result = false;

            Models.propSubscription propSubscription = GetPropSubscriptionFor(objectMap, name);
            if (propSubscription != null &&
                propSubscription.isDisabled == "false")
            {
                result = true;
            }

            return result;
        }
        public static void AddPropSubscriptionFor(Models.ObjectMap objectMap, string name)
        {
            Models.propSubscription propSubscription = GetPropSubscriptionFor(objectMap, name); 
            if(propSubscription == null)
            {
                Models.ObjectMap ownerObjectMap = GetOwnerObject(name);
                propSubscription = new propSubscription();
                propSubscription.destinationTargetName = name;
                propSubscription.destinationContextObjectName = ownerObjectMap.name;
                objectMap.propSubscription.Add(propSubscription);
            }
            propSubscription.isDisabled = "false";
        }
        public static void RemovePropSubscriptionFor(Models.ObjectMap objectMap, string name)
        {
            Models.propSubscription propSubscription = GetPropSubscriptionFor(objectMap, name);
            if (propSubscription != null)
            {
                propSubscription.isDisabled = "true";
            } 
        }

        public static String ReplaceSpecialCharacters(String rootString)
        { 
            if (rootString.Length == 0)
                return rootString;

            rootString = rootString.Trim();

            rootString = rootString.Replace("\n", " ");
            rootString = rootString.Replace("_", " ");
            rootString = rootString.Replace("=", " ");
            rootString = rootString.Replace("+", " ");
            rootString = rootString.Replace("<", " ");
            rootString = rootString.Replace(">", " ");
            rootString = rootString.Replace("!", " ");
            rootString = rootString.Replace("?", " ");
            rootString = rootString.Replace("*", " ");
            rootString = rootString.Replace("@", " ");
            rootString = rootString.Replace("$", " ");
            rootString = rootString.Replace("%", " ");
            rootString = rootString.Replace("^", " ");
            rootString = rootString.Replace("{", " ");
            rootString = rootString.Replace("}", " ");
            rootString = rootString.Replace("\"", " ");
            rootString = rootString.Replace("`", " ");
            rootString = rootString.Replace("^", " ");
            rootString = rootString.Replace(".", "");
            rootString = rootString.Replace(",", " ");
            rootString = rootString.Replace(":", " ");
            rootString = rootString.Replace(";", " ");
            rootString = rootString.Replace("\"", "");
            rootString = rootString.Replace("(", "");
            rootString = rootString.Replace(")", "");
            rootString = rootString.Replace("[", "");
            rootString = rootString.Replace("]", "");
            rootString = rootString.Replace("//", "");
            //rootString = rootString.Replace("-", " ");
            rootString = rootString.Replace("‘", "");
            rootString = rootString.Replace("/", " ");
            rootString = rootString.Replace("#", " ");
            rootString = rootString.Replace("'", "");
            rootString = rootString.Replace("--", " ");

            rootString = rootString.Replace(" ", "");


            rootString = rootString.Trim();
            return rootString;

        }
    }
}
