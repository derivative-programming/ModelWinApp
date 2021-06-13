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
        //[JsonRequired]
        //[JsonProperty("apiVersion")]
        //public string apiVersion { get; set; }
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonRequired]
        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }
        [JsonIgnore]
        public string CodeNameSpaceRootName { get; set; }
        [JsonIgnore]
        public string CodeNameSpaceSecondaryName { get; set; }
        //[JsonProperty("isValidationMissesLogged")]
        //public string isValidationMissesLogged { get; set; }
        [JsonRequired]
        [JsonProperty("namespace")]
        public List<NameSpaceObject> NameSpaceObjects { get; set; }
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
        [JsonRequired]
        [JsonProperty("object")]
        public List<ObjectMap> ObjectMap { get; set; }
        [JsonProperty("apiSite")]
        public List<apiSite> apiSite { get; set; }
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
        //[JsonProperty("calculatedProp")]
        //public List<calculatedProp> calculatedProp { get; set; }
        //[JsonProperty("fetch")]
        //public List<fetch> fetch { get; set; }
        //[JsonProperty("query")]
        //public List<query> query { get; set; }
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
    }
    public class property
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string CodeDescription { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
        [JsonProperty("isFK")]
        public string isFK { get; set; }
        [JsonProperty("isEncrypted")]
        public string isEncrypted { get; set; }
        [JsonProperty("forceDBColumnIndex")]
        public string forceDBColumnIndex { get; set; }
       
        //[JsonProperty("isFKLookup")]
        //public string isFKLookup { get; set; }
        //[JsonProperty("isFKNonLookupIncludedInXMLFunction")]
        //public string isFKNonLookupIncludedInXMLFunction { get; set; }
        //[JsonProperty("fKObjectName")]
        //public string fKObjectName { get; set; }
        //[JsonProperty("fKObjectPropertyName")]
        //public string fKObjectPropertyName { get; set; }
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
    public class calculatedProp
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("placeholderText")]
        public string placeholderText { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
        [JsonProperty("angularDispalyFilter")]
        public string angularDispalyFilter { get; set; }
        [JsonProperty("angularInputMask")]
        public string angularInputMask { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("defaultValue")]
        public string defaultValue { get; set; }
        [JsonProperty("fKObjectName")]
        public string fKObjectName { get; set; }
        [JsonProperty("fKObjectPropertyName")]
        public string fKObjectPropertyName { get; set; }
        [JsonProperty("isDirtyReadAllowed")]
        public string isDirtyReadAllowed { get; set; }
        [JsonProperty("isEditAllowed")]
        public string isEditAllowed { get; set; }
        [JsonProperty("isExposedInObjectSearch")]
        public string isExposedInObjectSearch { get; set; }
        [JsonProperty("isFK")]
        public string isFK { get; set; }
        [JsonProperty("isFKLookup")]
        public string isFKLookup { get; set; }
        [JsonProperty("isIndexedInDB")]
        public string isIndexedInDB { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("labelText")]
        public String labelText { get; set; }
        [JsonProperty("maxValue")]
        public String maxValue { get; set; }
        [JsonProperty("minValue")]
        public String minValue { get; set; }
        [JsonProperty("conditionalVisiblePropertyName")]
        public String conditionalVisiblePropertyName { get; set; }
        [JsonProperty("conditionalVisiblePropertyValue")]
        public String conditionalVisiblePropertyValue { get; set; }
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
        [JsonProperty("titleText")]
        public string TitleText { get; set; }
        [JsonProperty("introText")]
        public string IntroText { get; set; }
        [JsonProperty("roleRequired")]
        public string RoleRequired { get; set; }
        [JsonProperty("isCustomSqlUsed")]
        public string IsCustomSqlUsed { get; set; }
        [JsonProperty("targetChildObject")]
        public string TargetChildObject { get; set; }
        [JsonProperty("isPagingAvailable")]
        public string IsPagingAvailable { get; set; }
        [JsonProperty("isExportButtonHidden")]
        public string IsExportButtonHidden { get; set; }
        [JsonProperty("reportButton")]
        public List<reportButton> reportButton { get; set; }
        [JsonProperty("reportParam")]
        public List<reportParam> reportParam { get; set; }
        [JsonProperty("reportColumn")]
        public List<reportColumn> reportColumn { get; set; }
    }
    public class reportButton
    {
        [JsonProperty("buttonName")]
        public string buttonName { get; set; }
        [JsonProperty("buttonType")]
        public string buttonType { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("destinationTargetName")]
        public string destinationTargetName { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
        [JsonProperty("isButtonCallToAction")]
        public string isButtonCallToAction { get; set; }
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
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
    }
    public class reportColumn
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        [JsonProperty("labelText")]
        public string LabelText { get; set; }
        [JsonProperty("sourceObjectName")]
        public string sourceObjectName { get; set; }
        [JsonProperty("sourcePropertyName")]
        public string sourcePropertyName { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
       
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
       
    }
    public class objectWorkflow
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("ownerObject")]
        public string OwnerObject { get; set; }
        [JsonProperty("titleText")]
        public string TitleText { get; set; }
        [JsonProperty("introText")]
        public String IntroText { get; set; } 
        [JsonProperty("isPage")]
        public String IsPage { get; set; }
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
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("infoToolTipText")]
        public string infoToolTipText { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }

    }
    public class objectWorkflowOutputVar
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("sqlServerDBDataType")]
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
        [JsonProperty("labelText")]
        public string labelText { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("buttonNavURL")]
        public string buttonNavURL { get; set; }
        [JsonProperty("isLabelVisible")]
        public string isLabelVisible { get; set; }
        [JsonProperty("defaultValue")]
        public string defaultValue { get; set; }
        [JsonProperty("isLink")]
        public string isLink { get; set; }
        [JsonProperty("isAutoRedirectURL")]
        public string isAutoRedirectURL { get; set; }
        [JsonProperty("buttonObjectWFName")]
        public String buttonObjectWFName { get; set; }
        [JsonProperty("angularDispalyFilter")]
        public String angularDispalyFilter { get; set; }
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

    }
    public class objectWorkflowButton
    {
        [JsonProperty("buttonType")]
        public string buttonType { get; set; }
        [JsonProperty("buttonText")]
        public string buttonText { get; set; }
        [JsonProperty("destinationTargetName")]
        public String destinationTargetName { get; set; }
        [JsonProperty("isVisible")]
        public string isVisible { get; set; }
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
        public string sqlServerDBDataType { get; set; }
        [JsonProperty("sqlServerDBDataTypeSize")]
        public string sqlServerDBDataTypeSize { get; set; }
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
        public string apiContextTargetName { get; set; }
        [JsonProperty("apiCodeParamName")]
        public string apiCodeParamName { get; set; }
        [JsonProperty("apiContextObjectName")]
        public string apiContextObjectName { get; set; }
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
