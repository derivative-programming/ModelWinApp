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

        public static string _ApiKey = string.Empty;

        private static string GetApiBaseUrl()
        {
            return "https://localhost:44348";
        }
         

        private static System.Net.Http.HttpClient BuildClient()
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ares-Api-Key", _ApiKey);
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
                }

                result = true;
            }
            catch(System.Exception)
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
                    null,1,100,"RequestUTCDateTime",false,string.Empty);
                 
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
                    null, 1, 100, "RequestUTCDateTime", true, string.Empty);

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
                    null, 1, 100, "RequestUTCDateTime", true, string.Empty);

            }
            catch (System.Exception)
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


                result = await client.GetOneAsync(prepRequestCode);

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


                result = await client.GetOneAsync(validationRequestCode);

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


                result = await client.GetOneAsync(fabricationRequestCode);

            }
            catch (System.Exception)
            {

            }

            return result;
        }


        public async static Task<bool> AddPrepRequestAsync(string modelFilePath)
        {
            bool result = false;

            try
            { 
                PrepRequestClient prepRequestClient = new PrepRequestClient(GetApiBaseUrl(), BuildClient());

                PrepRequestPostModel postModel = new PrepRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                postModel.Description = ""; 
                PrepRequestPostResponse response = await prepRequestClient.PostAsync(postModel);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<bool> AddValidationRequestAsync(string modelFilePath)
        {
            bool result = false;

            try
            { 
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());

                ValidationRequestPostModel postModel = new ValidationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                ValidationRequestPostResponse response = await client.PostAsync(postModel);
                result = true;
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public async static Task<bool> AddFabricationRequestAsync(string modelFilePath)
        {
            bool result = false;

            try
            { 
                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());

                FabricationRequestPostModel postModel = new FabricationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                FabricationRequestPostResponse response = await client.PostAsync(postModel);
                result = true;
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


        public async static Task<bool> DownloadPrepRequestReportAsync(Guid prepRequestCode)
        {
            bool result = false;

            return result;
        }
        public async static Task<bool> DownloadValidationRequestReportAsync(Guid validationRequestCode)
        {
            bool result = false;

            return result;
        }
        public async static Task<bool> DownloadFabricationRequestReportAsync(Guid fabricationRequestCode)
        {
            bool result = false;

            return result;
        }

        public async static Task<bool> DownloadPrepRequestInitialModelAndLoadAsync(Guid prepRequestCode)
        {
            bool result = false;

            return result;
        }
        public async static Task<bool> DownloadValidationRequestInitialModelAndLoadAsync(Guid validationRequestCode)
        {
            bool result = false;

            return result;
        }
        public async static Task<bool> DownloadFabricationRequestInitialModelAndLoadAsync(Guid fabricationRequestCode)
        {
            bool result = false;

            return result;
        }

        public async static Task<bool> DownloadPrepRequestResultModelAndLoadAsync(Guid prepRequestCode)
        {
            bool result = false;

            return result;
        } 
        public async static Task<bool> DownloadFabricationRequestResultModelAndLoadAsync(Guid fabricationRequestCode)
        {
            bool result = false;

            return result;
        }

    }
}
