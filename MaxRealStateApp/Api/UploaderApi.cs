using MaxRealStateApp.Configuration;
using MaxRealStateApp.Models;
using MaxRealStateApp.Utilites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace MaxRealStateApp.Api
{
    public class UploaderApi : ControllerBase
    {
        readonly IFileManager _fileUploadService;
        public ApiResponseModel apiResponse = new ApiResponseModel();
        private IWebHostEnvironment environment;
        private readonly IAppSettings appSettings;

        public UploaderApi(IFileManager streamFileUploadService, IWebHostEnvironment _environment, IConfiguration configuration, IAppSettings appSettings)
        {

            environment = _environment;

            _fileUploadService = streamFileUploadService;
            this.appSettings = appSettings;

        }

        [Route("api/UploadFile")]
        [HttpPost]
        public async Task<ApiResponseModel> SaveFileToPhysicalFolder()
        {
            var boundary = HeaderUtilities.RemoveQuotes(
                MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
            ).Value;
            var reader = new MultipartReader(boundary, Request.Body);
            var section = await reader.ReadNextSectionAsync();
            string response = string.Empty;
            try
            {
                var result = await _fileUploadService.UploadFile(reader, section);
                if (string.IsNullOrEmpty(result))
                {
                    apiResponse.status = false;
                    apiResponse.message = "Failed to upload image";
                }
                else
                {
                    apiResponse.status = true;
                    apiResponse.message = "File uploaded successfully!";
                    apiResponse.data = result;
                }
            }
            catch (Exception ex)
            {
                apiResponse.status = false;
                apiResponse.message = "Opps something went wrong!";
                ;
            }
            return apiResponse;

        }
        [Route("api/UploadFileToApi")]
        [HttpPost]
        public async Task<ApiResponseModel> UploadFileToApi()
        {
            var boundary = HeaderUtilities.RemoveQuotes(
                MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
            ).Value;
            var reader = new MultipartReader(boundary, Request.Body);
            var section = await reader.ReadNextSectionAsync();
            string response = string.Empty;
            try
            {
                var result = await _fileUploadService.UploadFileApi(reader, section, appSettings.GetConfiguration().MaxApiUrl);
                if (string.IsNullOrEmpty(result))
                {
                    apiResponse.status = false;
                    apiResponse.message = "Failed to upload image";
                }
                else
                {
                    apiResponse.status = true;
                    apiResponse.message = "File uploaded successfully!";
                    apiResponse.data = result;
                }
            }
            catch (Exception ex)
            {
                apiResponse.status = false;
                apiResponse.message = "Opps something went wrong!";
                ;
            }
            return apiResponse;

        }


    }
}
