using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//File Manager's base functions are available in the below namespace
using Syncfusion.EJ2.FileManager.Base;
//File Manager's operations are available in the below namespace
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Demo.Shared.DataAccess;
using Demo.Data;

namespace Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class MailController : Controller
    {
        public PhysicalFileProvider operation;
        UserDataAccessLayer db = new UserDataAccessLayer();
        public string basePath;
        string root = "wwwroot\\Files";

        [Obsolete]
        public MailController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
        }

        // Processing the File Manager operations
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            var rootPath = this.root + "\\" + GetName();
            this.operation.RootFolder(this.basePath + "\\" + rootPath);
            switch (args.Action)
            {
                // Add your custom action here
                case "read":
                    // Path - Current path; ShowHiddenItems - Boolean value to show/hide hidden items
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    // Path - Current path where of the folder to be deleted; Names - Name of the files to be deleted
                    return this.operation.ToCamelCase(this.operation.Delete(args.Path, args.Names));
                case "copy":
                    //  Path - Path from where the file was copied; TargetPath - Path where the file/folder is to be copied; RenameFiles - Files with same name in the copied location that is confirmed for renaming; TargetData - Data of the copied file
                    return this.operation.ToCamelCase(this.operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "move":
                    // Path - Path from where the file was cut; TargetPath - Path where the file/folder is to be moved; RenameFiles - Files with same name in the moved location that is confirmed for renaming; TargetData - Data of the moved file
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "details":
                    // Path - Current path where details of file/folder is requested; Name - Names of the requested folders
                    return this.operation.ToCamelCase(this.operation.Details(args.Path, args.Names));
                case "create":
                    // Path - Current path where the folder is to be created; Name - Name of the new folder
                    return this.operation.ToCamelCase(this.operation.Create(args.Path, args.Name));
                case "search":
                    // Path - Current path where the search is performed; SearchString - String typed in the searchbox; CaseSensitive - Boolean value which specifies whether the search must be casesensitive
                    return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    // Path - Current path of the renamed file; Name - Old file name; NewName - New file name
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
            }
            return null;
        }
        // uploads the file(s) into a specified path
        [Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            var rootPath = this.root + "\\" + GetName();
            this.operation.RootFolder(this.basePath + "\\" + rootPath);
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }
            return Content("");
        }

        // downloads the selected file(s) and folder(s)
        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {
            var rootPath = this.root + "\\" + GetName();
            this.operation.RootFolder(this.basePath + "\\" + rootPath);
            FileManagerDirectoryContent args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            return operation.Download(args.Path, args.Names, args.Data);
        }

        // gets the image(s) from the given path
        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            var rootPath = this.root + "\\" + GetName();
            this.operation.RootFolder(this.basePath + "\\" + rootPath);
            return this.operation.GetImage(args.Path, args.Id, false, null, null);
        }

        // Get user ID from data source
        [HttpGet("{id}")]
        public object GetIndex()
        {
            // Get the DataSource from Database
            var data = db.GetUser().ToList();
            int UserId;
            var count = data.Count;
            if (count > 0)
            {
                UserId = (data[data.Count - 1].UserId);
            }
            else
            {
                UserId = 1;
            }
            return UserId;
        }

        // Get user name from data source
        public object GetName()
        {
            // Get the DataSource from Database
            var data = db.GetUser().ToList();
            string name;
            var count = data.Count;
            if (count > 0)
            {
                name = (data[data.Count - 1].Name);
            }
            else
            {
                name = "User 1";
            }
            return name;
        }

        // Update user details into data source
        [Route("SetUser")]
        public object SetUser([FromBody] User args)
        {
            UserDetails CurrentUser = new UserDetails();
            CurrentUser.Id = 1;
            CurrentUser.UserId = args.UserId;
            CurrentUser.Name = args.Name;
            db.UpdateUser(CurrentUser);
            return null;
        }
    }
}
