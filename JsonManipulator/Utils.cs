using JsonManipulator.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static List<string> getBooleanList()
        {
            List<string> _booleans = new List<string>(); 
            _booleans.Add("");
            _booleans.Add("true");
            _booleans.Add("false");
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
            _booleans.Rows.Add("BarChart", "BarChart");
            _booleans.Rows.Add("Cards", "Cards");
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
            result.Add("isExposedInBusinessObject");
            result.Add("isObjectDelete");
            result.Add("layoutName");
            result.Add("isWFSWorkflowCreated");
            //result.Add("formTitleText");
            //result.Add("formIntroText");
            //result.Add("formFooterText");
            result.Add("formFooterImageURL");
            //result.Add("isAutoSubmit");
            //result.Add("isHeaderVisible");
            result.Add("isLoginPage");
            result.Add("isLogoutPage");
            result.Add("isImpersonationPage");
            result.Add("isCaptchaVisible");
            result.Add("isCreditCardEntryUsed");
            result.Add("headerImageURL");
            result.Add("footerImageURL");
            result.Add("isDynaFlow");
            result.Add("isDynaFlowTask");
            result.Add("isCustomPageViewUsed");
            result.Add("isIgnoredInDocumentation");
            result.Add("targetChildObject");
            result.Add("isAuthorizationRequired");

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
            result.Add("isDynaFlow");
            result.Add("isDynaFlowTask");
            result.Add("isCustomPageViewUsed");
            result.Add("isIgnoredInDocumentation");
            result.Add("targetChildObject");
            result.Add("isAuthorizationRequired");

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
            result.Add("fKObjectName".ToLower());
            result.Add("fKObjectQueryName".ToLower());
            //result.Add("isFKLookup".ToLower());
            //result.Add("isFKList".ToLower());
            //result.Add("isFKListInactiveIncluded".ToLower());
            result.Add("isFKListUnknownOptionRemoved".ToLower());
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
            result.Add("isIgnored".ToLower());
            result.Add("defaultValue".ToLower());

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
            result.Add("isFKLookup".ToLower());
            result.Add("isNotPublishedToSubscriptions".ToLower());
            result.Add("fKObjectName".ToLower());
            result.Add("fKObjectPropertyName".ToLower());
            result.Add("isQueryByAvailable".ToLower());
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
            result.Add("enumValue".ToLower()); 

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
            result.Add("layoutName".ToLower());
            //result.Add("isExportButtonsHidden".ToLower());
            //result.Add("isFilterSectionHidden".ToLower());
            result.Add("isCachingAllowed".ToLower());
            result.Add("isButtonDropDownAllowed".ToLower());
            result.Add("ratingLevelColumnName".ToLower());
            result.Add("isRatingLevelChangingRowBackgroundColor".ToLower());
            result.Add("cacheExpirationInMinutes".ToLower());
            //result.Add("isFilterSectionCollapsable".ToLower());
            //result.Add("isBreadcrumbSectionHidden".ToLower());
            result.Add("isSchedulingAllowed".ToLower());
            result.Add("isFavoriteCreationAllowed".ToLower());
            result.Add("badgeCountPropertyName".ToLower());

            result.Add("isHeaderLabelsVisible".ToLower());
            result.Add("isHeaderVisible".ToLower());
            result.Add("isReportDetailLabelColumnVisible".ToLower());
            //.Add("noRowsReturnedText".ToLower());
            result.Add("formIntroText".ToLower());
            result.Add("isIgnoredInDocumentation".ToLower());
            result.Add("isAzureBlobStorageUsed".ToLower());
            result.Add("isAzureTableUsed".ToLower());
            result.Add("azureTableNameOverride".ToLower());
            result.Add("azureTablePrimaryKeyColumn".ToLower());
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
            result.Add("conditionalVisiblePropertyName".ToLower());

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
            result.Add("minWidth".ToLower());
            result.Add("name");
            //result.Add("isButton".ToLower());
            //result.Add("buttonText".ToLower());
            //result.Add("buttonDestinationTargetName".ToLower());

            result.Add("maxWidth".ToLower());
            result.Add("dateTimeDisplayFormat".ToLower());
            //result.Add("infoToolTipText".ToLower());
            //result.Add("isButtonCallToAction".ToLower());
            result.Add("isHtml".ToLower());
            result.Add("isColumnSumMetricAvailable".ToLower());
            result.Add("isSummaryDisplayed".ToLower());
            result.Add("isConditionallyDisplayed".ToLower());
            //result.Add("conditionalSqlLogic".ToLower());
            //result.Add("isUnixEpochDateTime".ToLower());
            result.Add("isNavURL".ToLower());
            result.Add("NavURLLinkText".ToLower());
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
            result.Add("isImageURL".ToLower());
            result.Add("isEncrypted".ToLower());
            result.Add("isIgnored".ToLower());

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
            result.Add("apiContextObjectName");
            result.Add("apiPostContextObjectName");
            result.Add("apiPutContextObjectName");
            result.Add("apiDeleteContextObjectName");

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
            if (objWF.IsPage == null)
            {
                if (objWF.isDynaFlow != null && objWF.isDynaFlow.Trim().ToLower() == "true")
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

                if (objWF.IsPage.Trim().ToLower() == "true")
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

            if (objWF.IsPage == null)
            {
                if (objWF.isDynaFlow != null && objWF.isDynaFlow.Trim().ToLower() == "true")
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

                if (objWF.isDynaFlow != null && objWF.isDynaFlow.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (objWF.isDynaFlowTask != null && objWF.isDynaFlowTask.Trim().ToLower() == "true")
                {
                    result = false;
                }
                else if (objWF.IsPage.Trim().ToLower() == "false" &&
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

            if (objWF.isDynaFlow != null && objWF.isDynaFlow.Trim().ToLower() == "true")
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
            JObject fullModel = JObject.Parse(model.ToString());
            SortJsonFile(ref fullModel);
             
            System.IO.File.WriteAllText(sourceFile, fullModel.ToString());

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
            return Regex.Replace(value, "(\\B[A-Z])", " $1"); 
        }
    }
}
