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
            return "https://localhost:44348";
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


        public async static Task<bool> AddPrepRequestAsync(string description, string modelFilePath)
        {
            bool result = false;

            try
            { 
                PrepRequestClient prepRequestClient = new PrepRequestClient(GetApiBaseUrl(), BuildClient());

                PrepRequestPostModel postModel = new PrepRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                postModel.Description = description; 
                PrepRequestPostResponse response = await prepRequestClient.PostAsync(postModel);
                result = true;
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
                ValidationRequestClient client = new ValidationRequestClient(GetApiBaseUrl(), BuildClient());

                ValidationRequestPostModel postModel = new ValidationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                postModel.Description = description;
                ValidationRequestPostResponse response = await client.PostAsync(postModel);
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
                FabricationRequestClient client = new FabricationRequestClient(GetApiBaseUrl(), BuildClient());

                FabricationRequestPostModel postModel = new FabricationRequestPostModel();
                postModel.ModelFileData = Convert.ToBase64String(System.IO.File.ReadAllBytes(modelFilePath));
                postModel.Description = description;
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
         

    }
}
