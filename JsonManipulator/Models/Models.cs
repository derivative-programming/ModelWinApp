using JsonManipulator.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulator.Models
{
    public class RootObject
    {
        [JsonRequired]
        [JsonProperty("root")]
        public root root { get; set; }
    }
    public class root
    {
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        [JsonProperty("projectVersionNumber")]
        public string projectVersionNumber { get; set; }
        [JsonRequired]
        [JsonProperty("name")]
        public string CodeNameSpaceRootName { get; set; }
        [JsonIgnore]
        public string CodeNameSpaceSecondaryName { get; set; } 
        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }
        [JsonProperty("databaseTableNamePrefix")]
        public string DatabaseTableNamePrefix { get; set; }
        [JsonProperty("isDatabaseAuditColumnsCreated")]
        public string isDatabaseAuditColumnsCreated { get; set; }
        [JsonProperty("isValidationMissesLogged")]
        public string isValidationMissesLogged { get; set; }
        [JsonProperty("suppressFillObjLookupTableScripts")]
        public string suppressFillObjLookupTableScripts { get; set; }
        [JsonRequired]
        [JsonProperty("namespace")]
        public List<NameSpaceObject> NameSpaceObjects { get; set; }
        

    }
    public class ModelFeatureObject
    { 
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("isCompleted")]
        public string isCompleted { get; set; }
    }
    public class NameSpaceObject
    {
        [JsonProperty("isDynaFlowAvailable")]
        public string isDynaFlowAvailable { get; set; }
        [JsonRequired] 
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("favoriteListContextObjectName")]
        public string favoriteListContextObjectName { get; set; }
        [JsonProperty("favoriteListDestinationTargetName")]
        public string favoriteListDestinationTargetName { get; set; }
        [JsonProperty("scheduleListContextObjectName")]
        public string scheduleListContextObjectName { get; set; }
        [JsonProperty("scheduleListDestinationTargetName")]
        public string scheduleListDestinationTargetName { get; set; } 
        [JsonProperty("object")]
        public List<ObjectMap> ObjectMap { get; set; }
        [JsonProperty("apiSite")]
        public List<apiSite> apiSite { get; set; }
        [JsonProperty("modelFeature")]
        public List<ModelFeatureObject> ModelFeatureObject { get; set; }
        [JsonProperty("isModelFeatureConfigUserDBVeiwer")]
        public string isModelFeatureConfigUserDBVeiwer { get; set; }
    }
    public class ObjectMap
    {
        [JsonProperty("name")]
        public string name { get; set; }
       
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("isLookup")]
        public string isLookup { get; set; }
        [JsonProperty("parentObjectName")]
        public string parentObjectName { get; set; }
        [JsonProperty("prop")]
        public List<property> property { get; set; }
        [JsonProperty("propSubscription")]
        public List<propSubscription> propSubscription { get; set; }
        [JsonProperty("calculatedProp")]
        public List<calculatedProp> calculatedProp { get; set; }
        [JsonProperty("fetch")]
        public List<fetch> fetch { get; set; }
        [JsonProperty("query")]
        public List<query> query { get; set; }
        [JsonProperty("modelPkg")]
        public List<modelPkg> modelPkg { get; set; }
        [JsonProperty("lookupItem")]
        public List<lookupItem> lookupItem { get; set; }
        [JsonProperty("childObject")]
        public List<childObject> childObject { get; set; }
        //[JsonProperty("objectDocument")]
        //public List<objectDocument> objectDocument { get; set; }
        //[JsonProperty("isImmutable")]
        //public string isImmutable { get; set; }
        //[JsonProperty("isFullResearchDatabaseViewAllowed")]
        //public string isFullResearchDatabaseViewAllowed { get; set; }
        //[JsonProperty("isNotImplemented")]
        //public string isNotImplemented { get; set; }
        //[JsonProperty("labelText")]
        //public String labelText { get; set; }
        //[JsonProperty("isExposedInAPI")]
        //public string isExposedInAPI { get; set; }
        //[JsonProperty("rolesAllowedToRead")]
        //public String rolesAllowedToRead { get; set; }
        //[JsonProperty("rolesAllowedToWrite")]
        //public String rolesAllowedToWrite { get; set; }
        //[JsonProperty("rolesAllowedToDelete")]
        //public String rolesAllowedToDelete { get; set; }
        //[JsonProperty("isExposedInObjectSearch")]
        //public string isExposedInObjectSearch { get; set; }
        //[JsonProperty("isUsingObjMirror")]
        //public string isUsingObjMirror { get; set; }
        //[JsonProperty("isAutoPruned")]
        //public string isAutoPruned { get; set; }
        //[JsonProperty("pruneToRecordCount")]
        //public String pruneToRecordCount { get; set; }
        //[JsonProperty("isReadAllowed")]
        //public string isReadAllowed { get; set; }
        //[JsonProperty("isWriteAllowed")]
        //public string isWriteAllowed { get; set; }
        //[JsonProperty("isDeleteAllowed")]
        //public string isDeleteAllowed { get; set; }
        //[JsonProperty("rolesAllowedForObjWFs")]
        //public string rolesAllowedForObjWFs { get; set; }
        //[JsonProperty("isAPIAuthorizationRequired")]
        //public string isAPIAuthorizationRequired { get; set; }
        //[JsonProperty("isSoftDeleteUsed")]
        //public string isSoftDeleteUsed { get; set; }
        //[JsonProperty("cacheAllRecs")]
        //public string cacheAllRecs { get; set; }
        //[JsonProperty("cacheIndividualRecs")]
        //public string cacheIndividualRecs { get; set; }
        [JsonProperty("report")]
        public List<Report> report { get; set; }
       
        [JsonProperty("objectWorkflow")]
        public List<objectWorkflow> objectWorkflow { get; set; }


        [JsonProperty("intersectionObj")]
        public List<intersectionObj> intersectionObj { get; set; }
        public string isSoftDeleteUsed { get; set; }
        [JsonProperty("cacheAllRecs")]
        public string isAllRecsCached { get; set; }
        [JsonProperty("cacheIndividualRecs")]
        public string isIndividualRecsCached { get; set; } 
    }
    public class property
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string CodeDescription { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
        [JsonProperty("isFK")]
        public string isFK { get; set; }
        [JsonProperty("isEncrypted")]
        public string isEncrypted { get; set; }
        [JsonProperty("forceDBColumnIndex")]
        public string isDBColumnIndexForced { get; set; }

        [JsonProperty("isFKLookup")]
        public string isFKLookup { get; set; }
        [JsonProperty("isNotPublishedToSubscriptions")]
        public string isNotPublishedToSubscriptions { get; set; }
        //[JsonProperty("isFKNonLookupIncludedInXMLFunction")]
        //public string isFKNonLookupIncludedInXMLFunction { get; set; }
        [JsonProperty("fKObjectName")]
        public string fKObjectName { get; set; }
        [JsonProperty("fKObjectPropertyName")]
        public string fKObjectPropertyName { get; set; }

        [JsonProperty("isQueryByAvailable")]
        public string isQueryByAvailable { get; set; }
        [JsonProperty("labelText")]
        public string labelText { get; set; }
        public string defaultValue { get; set; }
        //[JsonProperty("placeholderText")]
        //public string placeholderText { get; set; }
        //[JsonProperty("isVisible")]
        //public string isVisible { get; set; }
        //[JsonProperty("isRequired")]
        //public string isRequired { get; set; }
        //[JsonProperty("conditionalVisiblePropertyName")]
        //public string conditionalVisiblePropertyName { get; set; }
        //[JsonProperty("isEditAllowed")]
        //public string isEditAllowed { get; set; }
        //[JsonProperty("conditionalVisiblePropertyValue")]
        //public string conditionalVisiblePropertyValue { get; set; }
        //[JsonProperty("codeDescription")]
        //public string codeDescription { get; set; }
        //[JsonProperty("isExposedInObjectSearch")]
        //public string isExposedInObjectSearch { get; set; }
        //[JsonProperty("angularInputMask")]
        //public string angularInputMask { get; set; }
        //[JsonProperty("angularDispalyFilter")]
        //public string angularDispalyFilter { get; set; }
        //[JsonProperty("minValue")]
        //public string minValue { get; set; }
        //[JsonProperty("maxValue")]
        //public string maxValue { get; set; }
        //[JsonProperty("defaultValue")]
        //public string defaultValue { get; set; }
        //[JsonProperty("isIndexedInDB")]
        //public string isIndexedInDB { get; set; }
        //[JsonProperty("isDirtyReadAllowed")]
        //public string isDirtyReadAllowed { get; set; }


    }

    public class propSubscription
    {
        [JsonProperty("destinationContextObjectName")]
        public string destinationContextObjectName { get; set; }
        [JsonProperty("destinationTargetName")]
        public string destinationTargetName { get; set; }
        [JsonProperty("isIgnored")]
        public string isDisabled { get; set; }
         
    }
    public class calculatedProp
    {
        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; } 
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
    }
    public class intersectionObj
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("pairedObj")]
        public string pairedObj { get; set; } 
    }
    public class Report
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        //[JsonProperty("ownerObject")]
        //public string OwnerObject { get; set; }
        [JsonProperty("visualizationType")]
        public string visualizationType { get; set; }
        [JsonProperty("initObjectWorkflowName")]
        public string initObjectWorkflowName { get; set; }


        [JsonProperty("defaultOrderByColumnName")]
        public string defaultOrderByColumnName { get; set; }

        [JsonProperty("defaultOrderByDescending")]
        public string defaultOrderByDescending { get; set; }


        [JsonProperty("layoutName")]
        public string layoutName { get; set; }


        [JsonProperty("titleText")]
        public string pageTitleText { get; set; }
        [JsonProperty("introText")]
        public string pageIntroText { get; set; }
        [JsonProperty("roleRequired")]
        public string RoleRequired { get; set; }
        [JsonProperty("isCustomSqlUsed")]
        public string isCustomSqlUsed { get; set; }
        [JsonProperty("targetChildObject")]
        public string TargetChildObject { get; set; }

        [JsonProperty("isAutoRefresh")]
        public string isAutoRefresh { get; set; }

        [JsonProperty("isAutoRefreshVisible")]
        public string isAutoRefreshVisible { get; set; }

        [JsonProperty("isAutoRefreshFrequencyVisible")]
        public string isAutoRefreshFrequencyVisible { get; set; }

        [JsonProperty("isAutoRefreshDegraded")]
        public string isAutoRefreshDegraded { get; set; }

        [JsonProperty("autoRefreshFrequencyInMinutes")]
        public string autoRefreshFrequencyInMinutes { get; set; }

        [JsonProperty("isRefreshButtonHidden")]
        public string isRefreshButtonHidden { get; set; }


        [JsonProperty("isPagingAvailable")]
        public string isPagingAvailable { get; set; }
        [JsonProperty("isExportButtonsHidden")]
        public string isExportButtonsHidden { get; set; }
        [JsonProperty("isFilterSectionHidden")]
        public string isFilterSectionHidden { get; set; }
        [JsonProperty("isFilterSectionCollapsable")]
        public string isFilterSectionCollapsable { get; set; }
        [JsonProperty("isBreadcrumbSectionHidden")]
        public string isBreadcrumbSectionHidden { get; set; } 

        [JsonProperty("isCachingAllowed")]
        public string isCachingAllowed { get; set; }
        [JsonProperty("cacheExpirationInMinutes")]
        public string cacheExpirationInMinutes { get; set; }
        [JsonProperty("isButtonDropDownAllowed")]
        public string isButtonDropDownAllowed { get; set; }
        [JsonProperty("ratingLevelColumnName")]
        public string ratingLevelColumnName { get; set; }
        [JsonProperty("isRatingLevelChangingRowBackgroundColor")]
        public string isRatingLevelChangingRowBackgroundColor { get; set; }
        [JsonProperty("isSchedulingAllowed")]
        public string isSchedulingAllowed { get; set; }
        [JsonProperty("isFavoriteCreationAllowed")]
        public string isFavoriteCreationAllowed { get; set; }
        [JsonProperty("badgeCountPropertyName")]
        public string badgeCountPropertyName { get; set; }


        public string isHeaderLabelsVisible { get; set; }
        public string isHeaderVisible { get; set; }
        public string isReportDetailLabelColumnVisible { get; set; }    
        public string noRowsReturnedText { get; set; }
        public string formIntroText { get; set; }
        public string isIgnoredInDocumentation { get; set; }
        public string isAzureBlobStorageUsed { get; set; }
        public string isAzureTableUsed { get; set; }
        public string azureTableNameOverride { get; set; }
        public string azureTablePrimaryKeyColumn { get; set; }
        public string isAzureTablePrimaryKeyColumnDateTime { get; set; } 
        public string visualizationGridGroupByColumnName { get; set; }
        public string visualizationGridGroupByInfoTextColumnName { get; set; }
        public string visualizationPieChartSliceValueColumnName { get; set; }
        public string visualizationPieChartSliceDescriptionColumnName { get; set; }
        public string visualizationLineChartUTCDateTimeColumnName { get; set; }
        public string visualizationLineChartValueColumnName { get; set; }
        public string visualizationLineChartDescriptionColumnName { get; set; }
        public string isVisualizationLineChartGridHorizLineHidden { get; set; }
        public string isVisualizationLineChartGridVerticalLineHidden { get; set; }
        public string isVisualizationLineChartLegendHidden { get; set; }
        public string isVisualizationLineChartStairLines { get; set; }
        public string visualizationLineChartGridVerticalMaxValue { get; set; }
        public string visualizationLineChartGridVerticalMinValue { get; set; }
        public string visualizationLineChartGridVerticalStepValue { get; set; }
        public string isVisualizationLineChartVerticalLabelsHidden { get; set; }
        public string visualizationLineChartGridVerticalTitle { get; set; }
        public string visualizationLineChartGridHorizTitle { get; set; }
        public string visualizationLineChartGridVerticalMaxValLabel { get; set; }
        public string visualizationLineChartGridVerticalMinValLabel { get; set; }
        public string isVisualizationLineChartGridVerticalMaxDynamic { get; set; }
        public string visualizationFlowChartSourceNodeCodeColumnName { get; set; }
        public string visualizationFlowChartSourceNodeDescriptionColumnName { get; set; }
        public string visualizationFlowChartSourceNodeColorColumnName { get; set; }
        public string visualizationFlowChartFlowDescriptionColumnName { get; set; }
        public string visualizationFlowChartDestinationNodeCodeColumnName { get; set; }
        public string visualizationCardViewTitleColumn { get; set; }
        public string visualizationCardViewDescriptionColumn { get; set; }
        public string visualizationCardViewIsImageAvailable { get; set; }
        public string visualizationCardViewImageColumn { get; set; }
        public string visualizationCardViewGroupByColumnName { get; set; }
        public string visualizationCardViewGroupByInfoTextColumnName { get; set; }
        public string visualizationFolderIDColumnName { get; set; }
        public string visualizationFolderNameColumnName { get; set; }
        public string visualizationFolderParentIDColumnName { get; set; }
        public string visualizationFolderIsFolderColumnName { get; set; }
        public string visualizationFolderIsDragDropAllowed { get; set; }
        public string visualizationFolderDragDropEventContextObjectName { get; set; }
        public string visualizationFolderDragDropEventTargetName { get; set; }
        public string isPage { get; set; }
        [JsonProperty("isBasicHeaderAutomaticallyAdded")]
        public string isBasicHeaderAutomaticallyAdded { get; set; }

        [JsonProperty("reportButton")]
        public List<reportButton> reportButton { get; set; }
        [JsonProperty("reportParam")]
        public List<reportParam> reportParam { get; set; }
        [JsonProperty("reportColumn")]
        public List<reportColumn> reportColumn { get; set; }
    }
    public class reportButton
    {
        [JsonProperty("buttonType")]
        public string buttonType { get; set; }
        [JsonProperty("buttonName")]
        public string buttonName { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("destinationContextObjectName")]
        public String destinationContextObjectName { get; set; }
        [JsonProperty("destinationTargetName")]
        public string destinationTargetName { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isButtonCallToAction")]
        public string isButtonCallToAction { get; set; }


        public string isEnabled { get; set; }
        public string conditionalVisiblePropertyName { get; set; } 
    }
    public class reportParam
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("labelText")]
        public string labelText { get; set; }
      
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isFKList")]
        public string isFKList { get; set; }
        [JsonProperty("isFKListInactiveIncluded")]
        public string isFKListInactiveIncluded { get; set; }
        [JsonProperty("targetColumnName")]
        public string targetColumnName { get; set; }

        public string fKObjectName { get; set; } 
        public string isFK { get; set; }
        public string isFKLookup { get; set; }
        public string fKListOrderBy { get; set; }
        public string isFKListSearchable { get; set; }
        public string isUnknownLookupAllowed { get; set; }
        public string defaultValue { get; set; }
    }
    public class reportColumn
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("headerText")]
        public string headerText { get; set; }
        [JsonProperty("sourceObjectName")]
        public string sourceObjectName { get; set; }
        [JsonProperty("sourcePropertyName")]
        public string sourcePropertyName { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
       
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isButton")]
        public string isButton { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("destinationTargetName")]
        public String buttonDestinationTargetName { get; set; }
        [JsonProperty("destinationContextObjectName")]
        public String buttonDestinationContextObjectName { get; set; }
        [JsonProperty("minWidth")]
        public String minWidth { get; set; }

        public String maxWidth { get; set; }
        public String dateTimeDisplayFormat { get; set; }
        public String infoToolTipText { get; set; }
        public String isButtonCallToAction { get; set; }
        public String isHtml { get; set; }
        public String isColumnSumMetricAvailable { get; set; }
        public String isSummaryDisplayed { get; set; }
        public String isConditionallyDisplayed { get; set; }
        [JsonProperty("conditionalSqlLogic")]
        public String booleanCalculationSqlLogic { get; set; }
        public String isUnixEpochDateTime { get; set; }
        public String isNavURL { get; set; }
        public String NavURLLinkText { get; set; }
        public String isButtonClickedOnRowClick { get; set; }
        public String isMultiSelectColumn { get; set; }
        public String isForcedIntoExport { get; set; }
        public String isButtonAsyncObjWF { get; set; }
        public String isAsyncObjWFResultFileStreamedOut { get; set; }
        public String asyncObjWFResultFilePathParamName { get; set; }
        public String isJoinedToLeftColumn { get; set; }
        public String isJoinedToRightColumn { get; set; }
        public String conditionalVisiblePropertyName { get; set; }
        public String buttonBadgeCountPropertyName { get; set; }
        public String isFormFooter { get; set; }
        public String isImageURL { get; set; }
        public String isEncrypted { get; set; }
        public String isIgnored { get; set; }

    }
    public class objectWorkflow
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        //[JsonProperty("ownerObject")]
        //public string OwnerObject { get; set; }
        [JsonProperty("titleText")]
        public string pageTitleText { get; set; }
        [JsonProperty("introText")]
        public String pageIntroText { get; set; } 
        [JsonProperty("isPage")]
        public String isPage { get; set; }
        [JsonProperty("roleRequired")]
        public String RoleRequired { get; set; }
        [JsonProperty("objectWorkflowParam")]
        public List<objectWorkflowParam> objectWorkflowParam { get; set; }
        [JsonProperty("objectWorkflowOutputVar")]
        public List<objectWorkflowOutputVar> objectWorkflowOutputVar { get; set; }
        [JsonProperty("objectWorkflowButton")]
        public List<objectWorkflowButton> objectWorkflowButton { get; set; }
        [JsonProperty("dynaFlowTask")]
        public List<dynaFlowTask> dynaFlowTask { get; set; }

        public String initObjectWorkflowName { get; set; }
        public String isInitObjWFSubscribedToParams { get; set; }
        public String isExposedInBusinessObject { get; set; }
        public String isObjectDelete { get; set; }
        public String layoutName { get; set; }
        public String isWFSWorkflowCreated { get; set; }
        public String formTitleText { get; set; }
        public String formIntroText { get; set; }
        public String formFooterText { get; set; }
        public String formFooterImageURL { get; set; }
        public String isAutoSubmit { get; set; }
        public String isHeaderVisible { get; set; }
        public String isLoginPage { get; set; }
        public String isLogoutPage { get; set; }
        public String isImpersonationPage { get; set; }
        public String isCaptchaVisible { get; set; }
        public String isCreditCardEntryUsed { get; set; }
        public String headerImageURL { get; set; }
        public String footerImageURL { get; set; }
        [JsonProperty("isDynaFlow")]
        public String isRequestRunViaDynaFlowAllowed { get; set; }
        public String isDynaFlowTask { get; set; }
        public String isCustomPageViewUsed { get; set; }
        public String isIgnoredInDocumentation { get; set; }
        public String targetChildObject { get; set; }
        public String isAuthorizationRequired { get; set; }
    }
    public class objectWorkflowParam
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("labelText")]
        public string labelText { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("infoToolTipText")]
        public string infoToolTipText { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        public string isRequired { get; set; }
        public string requiredErrorText { get; set; }
        public string isSecured { get; set; }
        public string isFK { get; set; }
        public string fKObjectName { get; set; }
        public string fKObjectQueryName { get; set; }
        public string isFKLookup { get; set; }
        public string isFKList { get; set; }
        public string isFKListInactiveIncluded { get; set; }
        public string isFKListUnknownOptionRemoved { get; set; }
        public string fKListOrderBy { get; set; }
        public string isFKListOptionRecommended { get; set; }
        public string isFKListSearchable { get; set; }
        public string FKListRecommendedOption { get; set; }
        public string isRadioButtonList { get; set; }
        public string isFileUpload { get; set; }
        public string isCreditCardEntry { get; set; }
        public string isTimeZoneDetermined { get; set; }
        public string detailsText { get; set; }
        public string validationRuleRegExMatchRequired { get; set; }
        public string validationRuleRegExMatchRequiredErrorText { get; set; }
        public string isIgnored { get; set; }
        public string defaultValue { get; set; }
        [JsonProperty("sourceObjectName")]
        public string sourceObjectName { get; set; }
        [JsonProperty("sourcePropertyName")]
        public string sourcePropertyName { get; set; }

    }
    public class objectWorkflowOutputVar
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
        [JsonProperty("labelText")]
        public string headerLabelText { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("buttonNavURL")]
        public string buttonNavURL { get; set; }
        [JsonProperty("isLabelVisible")]
        public string isHeaderLabelVisible { get; set; }
        [JsonProperty("defaultValue")]
        public string defaultValue { get; set; }
        [JsonProperty("isLink")]
        public string isLink { get; set; }
        [JsonProperty("isAutoRedirectURL")]
        public string isAutoRedirectURL { get; set; }
        [JsonProperty("buttonObjectWFName")]
        public String buttonObjectWFName { get; set; } 
        [JsonProperty("conditionalVisiblePropertyName")]
        public String conditionalVisiblePropertyName { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isFK")]
        public string isFK { get; set; }
        [JsonProperty("fKObjectName")]
        public String fKObjectName { get; set; }
        [JsonProperty("isFKLookup")]
        public string isFKLookup { get; set; }
        [JsonProperty("isHeaderText")]
        public string isHeaderText { get; set; }
        public string isIgnored { get; set; }
        [JsonProperty("sourceObjectName")]
        public string sourceObjectName { get; set; }
        [JsonProperty("sourcePropertyName")]
        public string sourcePropertyName { get; set; }

    }
    public class objectWorkflowButton
    {
        [JsonProperty("buttonType")]
        public string buttonType { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("destinationTargetName")]
        public String destinationTargetName { get; set; }
        [JsonProperty("destinationContextObjectName")]
        public String destinationContextObjectName { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isButtonCallToAction")]
        public string isButtonCallToAction { get; set; }
        public string introText { get; set; }
        public string conditionalVisiblePropertyName { get; set; }
    }
    public class dynaFlowTask
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("contextObjectName")]
        public string contextObjectName { get; set; }
        [JsonProperty("isDynaFlowRequest")]
        public string isDynaFlowRequest { get; set; }
    }
    public class fetch
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("byObjectName")]
        public string byObjectName { get; set; }
        [JsonProperty("byObjectNamespaceName")]
        public string byObjectNamespaceName { get; set; }
        [JsonProperty("includeInByObjectNameXMLFunction")]
        public string includeInByObjectNameXMLFunction { get; set; }
    }


    public class modelPkg
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("pkgType")]
        public string pkgType { get; set; }
        [JsonProperty("role")]
        public string role { get; set; }
        [JsonProperty("isImported")]
        public string isImported { get; set; }
        [JsonProperty("isSubscriptionAllowed")]
        public string isSubscriptionAllowed { get; set; }
        [JsonProperty("isSubscribed")]
        public string isSubscribed { get; set; }
    }


    public class lookupItem
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("displayName")]
        public string displayName { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("isActive")]
        public string isActive { get; set; }
        [JsonProperty("customIntProp1Value")]
        public string customIntProp1Value { get; set; }
    }
    public class childObject
    {
        [JsonProperty("name")]
        public string name { get; set; }
         
    }

    public class query
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("storedProcName")]
        public string storedProcName { get; set; }
        [JsonProperty("isCustomSqlUsed")]
        public string isCustomSqlUsed { get; set; }
        [JsonProperty("queryParam")]
        public List<queryParam> queryParam { get; set; }
    }
    public class queryParam
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("storedProcParamName")]
        public string storedProcParamName { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string dataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string dataSize { get; set; }
    }
    public class objectDocument
    {

    }
    public class objectButton
    {

    }
    public class apiSite
    {   [JsonRequired]
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("versionNumber")]
        public string versionNumber { get; set; }
        [JsonProperty("isPublic")]
        public string isPublic { get; set; }
        [JsonProperty("isSiteLoggingEnabled")]
        public string isSiteLoggingEnabled { get; set; }
        [JsonProperty("apiLogReportName")]
        public String apiLogReportName { get; set; }
        [JsonProperty("apiEnvironment")]
        public List<apiEnvironment> apiEnvironment { get; set; }
        [JsonProperty("apiEndPoint")]
        public List<apiEndPoint> apiEndPoint { get; set; }
    }
    public class apiEnvironment
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }

    }
    public class apiEndPoint
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("isAPIAuthorizationRequired")]
        public string isAPIAuthorizationRequired { get; set; }
        [JsonProperty("isGetAvailable")]
        public string isGetAvailable { get; set; }
        [JsonProperty("isGetContextCodeAParam")]
        public string isGetContextCodeAParam { get; set; }
        [JsonProperty("GetContextCodeParamName")]
        public string GetContextCodeParamName { get; set; }
        [JsonProperty("isGetWithIdAvailable")]
        public string isGetWithIdAvailable { get; set; }
        [JsonProperty("isPostAvailable")]
        public string isPostAvailable { get; set; }
        public string isPublic { get; set; }
        [JsonProperty("isLazyPost")]
        public string isLazyPost { get; set; }
        [JsonProperty("isPutAvailable")]
        public string isPutAvailable { get; set; }
        [JsonProperty("isDeleteAvailable")]
        public string isDeleteAvailable { get; set; }
        [JsonProperty("pluralName")]
        public string pluralName { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("apiContextTargetName")]
        public string apiGetContextTargetName { get; set; }
        [JsonProperty("apiCodeParamName")]
        public string apiCodeParamName { get; set; }
        [JsonProperty("apiContextObjectName")]
        public string apiGetContextObjectName { get; set; }
        [JsonProperty("apiPostContextObjectName")]
        public string apiPostContextObjectName { get; set; }
        [JsonProperty("apiPostContextTargetName")]
        public string apiPostContextTargetName { get; set; }
        [JsonProperty("apiPutContextObjectName")]
        public string apiPutContextObjectName { get; set; }
        [JsonProperty("apiPutContextTargetName")]
        public string apiPutContextTargetName { get; set; }
        [JsonProperty("apiDeleteContextObjectName")]
        public string apiDeleteContextObjectName { get; set; }
        [JsonProperty("apiDeleteContextTargetName")]
        public string apiDeleteContextTargetName { get; set; }
        [JsonProperty("isEndPointLoggingEnabled")]
        public string isEndPointLoggingEnabled { get; set; }
    }
    public class SelectListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
