using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulator.OpenAPIs
{
    public static class ApiManager
    {
        public static bool _IsLoggedIn = false;
        public static DateTime _ApiKeyExpirationDateTime = DateTime.MinValue;
        public static string _ApiKey = string.Empty;

        private static string GetApiBaseUrl()
        {
            return "https://dp-appservice-ares-api-dev.azurewebsites.net";
           // return "https://localhost:44348";
        }
         
        public static void Initialize()
        {
            _ApiKeyExpirationDateTime = Convert.ToDateTime(LocalStorage.GetValue("ModelServicesApiKeyExpirationUTCDateTime", DateTime.MinValue.ToString()));
            if(_ApiKeyExpirationDateTime.Ticks > DateTime.UtcNow.Ticks)
            {
                _IsLoggedIn = true;
                _ApiKey = LocalStorage.GetValue("ModelServicesApiKey", "");
            } 
        }

        private static System.Net.Http.HttpClient BuildClient()
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Api-Key", _ApiKey);
            return httpClient;
        }
        public async static Task<bool> LogInAsync(string email, string password)
        {
            bool result = false;

            try
            {
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
                LoginClient loginClient = new LoginClient(GetApiBaseUrl(), httpClient);

                LoginPostModel loginPostModel = new LoginPostModel();
                loginPostModel.Email = email;
                loginPostModel.Password = password;

                LoginPostResponse loginPostResponse = await loginClient.PostAsync(loginPostModel);
                _IsLoggedIn = false;
                _ApiKey = string.Empty;
                if(loginPostResponse.Success)
                {
                    _IsLoggedIn = true;
                    _ApiKey = loginPostResponse.ModelServicesAPIKey;
                    _ApiKeyExpirationDateTime = DateTime.UtcNow.AddDays(1);
                    LocalStorage.SetValue("ModelServicesApiKey", _ApiKey);
                    LocalStorage.SetValue("ModelServicesApiKeyExpirationUTCDateTime", _ApiKeyExpirationDateTime.ToString());
                    LocalStorage.Save();
                }

                result = true;
            }
            catch(System.Exception)
            {

            }
            

            return result;
        }

        public async static Task<bool> RegisterAsync(string email, 
            string password,
            string confirmPassword,
            string firstName,
            string lastName,
            bool optIn)
        {
            bool result = false;

            try
            {
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
                RegisterClient registerClient = new RegisterClient(GetApiBaseUrl(), httpClient);

                RegisterPostModel registerPostModel = new RegisterPostModel();
                registerPostModel.Email = email;
                registerPostModel.Password = password;
                registerPostModel.ConfirmPassword = confirmPassword;
                registerPostModel.FirstName = firstName;
                registerPostModel.LastName = lastName;
                registerPostModel.OptIntoTerms = optIn;


                RegisterPostResponse registerPostResponse = await registerClient.PostAsync(registerPostModel);
                _IsLoggedIn = false;
                _ApiKey = string.Empty;
                if (registerPostResponse.Success)
                {
                    _IsLoggedIn = true;
                    _ApiKey = registerPostResponse.ModelServicesAPIKey;
                    _ApiKeyExpirationDateTime = DateTime.UtcNow.AddDays(1);
                    LocalStorage.SetValue("ModelServicesApiKey", _ApiKey);
                    LocalStorage.SetValue("ModelServicesApiKeyExpirationUTCDateTime", _ApiKeyExpirationDateTime.ToString());
                    LocalStorage.Save();
                }

                result = true;
            }
            catch (System.Exception)
            {

            }


            return result;
        }

        public async static Task<JsonManipulator.PrepRequestListModel> GetPrepRequestListAsync()
        {
            JsonManipulator.PrepRequestListModel result = null;

            try
            {
               
                PrepRequestClient prepRequestClient = new PrepRequestClient(GetApiBaseUrl(), BuildClient());


                result = await prepRequestClient.GetAsync(
                    null,1,100, "ModelPrepRequestRequestedUTCDateTime", true, string.Empty);
                 
            }
            catch (System.Exception)
            {

            } 

            return result;
        }


        public async static Task<JsonManipulator.ValidationRequestListModel> GetValidationRequestListAsync()
        {

            JsonManipulator.ValidationRequestListModel result = null;
             
            try
            { 
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(
                    null, 1, 100, "ModelValidationRequestRequestedUTCDateTime", true, string.Empty);

            }
            catch (System.Exception)
            {

            }

            return result;
        }



        public async static Task<JsonManipulator.ChangeRptRequestListModel> GetChangeRptRequestListAsync()
        {

            JsonManipulator.ChangeRptRequestListModel result = null;

            try
            {
                ChangeRptRequestClient client = new ChangeRptRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(
                    null, 1, 100, "ModelChangeRptRequestRequestedUTCDateTime", true, string.Empty);

            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<JsonManipulator.FabricationRequestListModel> GetFabricationRequestListAsync()
        {
            JsonManipulator.FabricationRequestListModel result = null;

            try
            { 
                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(
                    null, 1, 100, "ModelFabricationRequestRequestedUTCDateTime", true, string.Empty);

            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<JsonManipulator.ModelFeatureListModel> GetModelFeatureListAsync()
        {
            JsonManipulator.ModelFeatureListModel result = null;

            try
            {
                ModelFeatureClient client = new ModelFeatureClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(
                    1, 100, "RequestUTCDateTime", true, string.Empty);

            }
            catch (System.Exception ex)
            {

            }

            return result;
        }


        public async static Task<JsonManipulator.TemplateSetListModel> GetTemplateSetListAsync()
        {
            JsonManipulator.TemplateSetListModel result = null;

            try
            {
                TemplateSetClient client = new TemplateSetClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(
                    1, 100, "RequestUTCDateTime", true, string.Empty);

            }
            catch (System.Exception ex)
            {

            }

            return result;
        }


        public async static Task<JsonManipulator.PrepRequestListModel> GetPrepRequestDetailAsync(Guid prepRequestCode)
        {
            JsonManipulator.PrepRequestListModel result = null;

            try
            { 
                PrepRequestClient client = new PrepRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(prepRequestCode,null,null,null,null,null);

            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<JsonManipulator.ValidationRequestListModel> GetValidationRequestDetailAsync(Guid validationRequestCode)
        {
            JsonManipulator.ValidationRequestListModel result = null;

            try
            { 
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(validationRequestCode, null, null, null, null, null);

            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<JsonManipulator.ChangeRptRequestListModel> GetChangeRptRequestDetailAsync(Guid ChangeRptRequestCode)
        {
            JsonManipulator.ChangeRptRequestListModel result = null;

            try
            {
                ChangeRptRequestClient client = new ChangeRptRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(ChangeRptRequestCode, null, null, null, null, null);

            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<JsonManipulator.FabricationRequestListModel> GetFabricationRequestDetailAsync(Guid fabricationRequestCode)
        {

            JsonManipulator.FabricationRequestListModel result = null;

            try
            { 
                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());


                result = await client.GetAsync(fabricationRequestCode, null, null, null, null, null);

            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<bool> AddPrepRequestAsync(string description, string modelFilePath)
        {
            bool result = false;

            try
            {
                string tmpZipFile = System.IO.Path.GetTempFileName();
                System.IO.File.Move(tmpZipFile, tmpZipFile + ".zip");
                tmpZipFile = tmpZipFile + ".zip";
                System.IO.File.Delete(tmpZipFile);

                string tmpFolderPath = string.Empty;
                tmpFolderPath = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory(tmpFolderPath);
                System.IO.File.Copy(modelFilePath, tmpFolderPath + @"\" + System.IO.Path.GetFileName(modelFilePath));
                System.IO.Compression.ZipFile.CreateFromDirectory(tmpFolderPath, tmpZipFile);

                PrepRequestClient prepRequestClient = new PrepRequestClient(GetApiBaseUrl(), BuildClient());

                PrepRequestPostModel postModel = new PrepRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(tmpZipFile));
                postModel.Description = description; 
                PrepRequestPostResponse response = await prepRequestClient.PostAsync(postModel);

                System.IO.Directory.Delete(tmpFolderPath, true);
                System.IO.File.Delete(tmpZipFile);

                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<string> AddMergeRequestAsync(string remoteModelUrl, string modelFilePath)
        {
            string result = string.Empty;

            try
            {
                string tmpZipFile = System.IO.Path.GetTempFileName();
                System.IO.File.Move(tmpZipFile, tmpZipFile + ".zip");
                tmpZipFile = tmpZipFile + ".zip";
                System.IO.File.Delete(tmpZipFile);

                string tmpFolderPath = string.Empty;
                tmpFolderPath = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory(tmpFolderPath);
                System.IO.File.Copy(modelFilePath, tmpFolderPath + @"\" + System.IO.Path.GetFileName(modelFilePath));
                System.IO.Compression.ZipFile.CreateFromDirectory(tmpFolderPath, tmpZipFile);

                ModelMergeClient modelMergeClient = new ModelMergeClient(GetApiBaseUrl(), BuildClient());

                ModelMergePostModel postModel = new ModelMergePostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(tmpZipFile));
                postModel.AdditionsModelUrl = remoteModelUrl;
                ModelMergePostResponse response = await modelMergeClient.PostAsync(postModel);
                  
                System.IO.Directory.Delete(tmpFolderPath, true);
                System.IO.File.Delete(tmpZipFile);

                result = response.ResultModelUrl;
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<bool> AddValidationRequestAsync(string description, string modelFilePath)
        {
            bool result = false;

            try
            {
                string tmpZipFile = System.IO.Path.GetTempFileName();
                System.IO.File.Move(tmpZipFile, tmpZipFile + ".zip");
                tmpZipFile = tmpZipFile + ".zip";
                System.IO.File.Delete(tmpZipFile);

                string tmpFolderPath = string.Empty;
                tmpFolderPath = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory(tmpFolderPath);
                System.IO.File.Copy(modelFilePath, tmpFolderPath + @"\" + System.IO.Path.GetFileName(modelFilePath));
                System.IO.Compression.ZipFile.CreateFromDirectory(tmpFolderPath, tmpZipFile);
                 
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());

                ValidationRequestPostModel postModel = new ValidationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(tmpZipFile));
                postModel.Description = description;
                ValidationRequestPostResponse response = await client.PostAsync(postModel);

                System.IO.Directory.Delete(tmpFolderPath, true);
                System.IO.File.Delete(tmpZipFile);

                result = true;
            }
            catch (System.Exception ex)
            {

            }

            return result;
        }

        public async static Task<bool> AddChangeRptRequestAsync(string description, string modelFilePath, string nextFilePath)
        {
            bool result = false;

            try
            {
                string tmpZipFile = System.IO.Path.GetTempFileName();
                System.IO.File.Move(tmpZipFile, tmpZipFile + ".zip");
                tmpZipFile = tmpZipFile + ".zip";
                System.IO.File.Delete(tmpZipFile);

                string tmpFolderPath = string.Empty;
                tmpFolderPath = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory(tmpFolderPath);
                System.IO.File.Copy(modelFilePath, tmpFolderPath + @"\" + System.IO.Path.GetFileName(modelFilePath));
                System.IO.Compression.ZipFile.CreateFromDirectory(tmpFolderPath, tmpZipFile);

                ChangeRptRequestClient client = new ChangeRptRequestClient(GetApiBaseUrl(), BuildClient());

                ChangeRptRequestPostModel postModel = new ChangeRptRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(tmpZipFile));
                postModel.NextModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(nextFilePath));
                postModel.Description = description;
                ChangeRptRequestPostResponse response = await client.PostAsync(postModel);

                System.IO.Directory.Delete(tmpFolderPath, true);
                System.IO.File.Delete(tmpZipFile);

                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<bool> AddFabricationRequestAsync(string description, string modelFilePath)
        {
            bool result = false;

            try
            {
                string tmpZipFile = System.IO.Path.GetTempFileName();
                System.IO.File.Move(tmpZipFile, tmpZipFile + ".zip");
                tmpZipFile = tmpZipFile + ".zip";
                System.IO.File.Delete(tmpZipFile);

                string tmpFolderPath = string.Empty;
                tmpFolderPath = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory(tmpFolderPath);
                System.IO.File.Copy(modelFilePath, tmpFolderPath + @"\" + System.IO.Path.GetFileName(modelFilePath));
                System.IO.Compression.ZipFile.CreateFromDirectory(tmpFolderPath, tmpZipFile);

                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());

                FabricationRequestPostModel postModel = new FabricationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(tmpZipFile));
                postModel.Description = description;
                FabricationRequestPostResponse response = await client.PostAsync(postModel);

                System.IO.Directory.Delete(tmpFolderPath, true);
                System.IO.File.Delete(tmpZipFile);

                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<string> AddModelChatQueryAsync(string queryText, Guid projectCode)
        {
            string result = string.Empty;

            try
            {

                ModelChatClient client = new ModelChatClient(GetApiBaseUrl(), BuildClient());

                ModelChatPostModel postModel = new ModelChatPostModel();
                postModel.ProjectCode = projectCode;
                postModel.QueryText = queryText;
                ModelChatPostResponse response = await client.PostAsync(postModel);
                 
                if(response.Success)
                {
                    result = response.ResponseText;
                }
                else
                {
                    result = response.Message;
                }
            }
            catch (System.Exception)
            { 
            }

            return result;
        }

        public async static Task<bool> CancelPrepRequestAsync(Guid prepRequestCode)
        {
            bool result = false;

            try
            { 
                PrepRequestClient client = new PrepRequestClient(GetApiBaseUrl(), BuildClient());

                PrepRequestDeleteResponse response = await client.DeleteAsync(prepRequestCode);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public async static Task<bool> CancelValidationRequestAsync(Guid validationRequestCode)
        {
            bool result = false;

            try
            { 
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());

                ValidationRequestDeleteResponse response = await client.DeleteAsync(validationRequestCode);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public async static Task<bool> CancelChangeRptRequestAsync(Guid ChangeRptRequestCode)
        {
            bool result = false;

            try
            {
                ChangeRptRequestClient client = new ChangeRptRequestClient(GetApiBaseUrl(), BuildClient());

                ChangeRptRequestDeleteResponse response = await client.DeleteAsync(ChangeRptRequestCode);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public async static Task<bool> CancelFabricationRequestAsync(Guid fabricationRequestCode)
        {
            bool result = false; 

            try
            { 
                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());

                FabricationRequestDeleteResponse response = await client.DeleteAsync(fabricationRequestCode);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }
         

    }
}
