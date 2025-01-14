using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.IO.Pipes;
using MaxModels;

namespace MaxRealStateApp.Utilites
{
    public class FileManager : IFileManager
    {

        public async Task<string> UploadFile(MultipartReader reader, MultipartSection? section)
        {
            string FileName = string.Empty;

            Guid guid = Guid.NewGuid();
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );

                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                    (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                    !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
                    {
                        var wwwrootPath = Path.Combine(Environment.CurrentDirectory, "wwwroot");

                        string filePath = Path.Combine(wwwrootPath, "UploadedFiles");
                        byte[] fileArray;
                        using (var memoryStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(memoryStream);
                            fileArray = memoryStream.ToArray();
                        }
                        FileName = guid + contentDisposition.FileName.Value;
                        using (var fileStream = System.IO.File.Create(Path.Combine(filePath, guid + contentDisposition.FileName.Value)))
                        {
                            await fileStream.WriteAsync(fileArray);
                        }
                    }
                }
                section = await reader.ReadNextSectionAsync();
            }
            return FileName;
        }
        public async Task<string> UploadFileApi(MultipartReader reader, MultipartSection? section,string ApiPath)
        {
            // Declare the FileName variable before the loop to store the final file name.
            string FileName = string.Empty;

            Guid guid = Guid.NewGuid();
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );

                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                    (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                    !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
                    {
                        // Read the content of the section body into a byte array.
                        byte[] data;
                        using (var memoryStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(memoryStream);
                            data = memoryStream.ToArray();
                        }


                        var client = new HttpClient();

                        // Create a new ByteArrayContent instance with the byte array and content type.
                        var fileContent = new ByteArrayContent(data);
                    //    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(section.ContentType);

                        // Create a new MultipartFormDataContent instance and add the file content to it.
                        var content = new MultipartFormDataContent();
                        content.Add(fileContent, "file", contentDisposition.FileName.Value);

                        // Send the request to the new endpoint and handle the response.
                        using (var response = await client.PostAsync( ApiPath + "api/externalUploads", content))
                        {
                            response.EnsureSuccessStatusCode();
                            var res = await response.Content.ReadAsStringAsync();
                            FileName= JsonConvert.DeserializeObject<string>(res);
                        }
                    }
                }

                // Read the next section.
                section = await reader.ReadNextSectionAsync();
            }

            // Return the final file name.
            return FileName;
        }

    }
}
