using MaxDataAccess;
using MaxDataAccess.Entites;
using MaxModels;
using MaxRealStateApp.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MaxRealStateApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppSettings appSettings;

        public AdminController(IUnitOfWork unitOfWork, IAppSettings appSettings)
        {
            this.appSettings = appSettings;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Agents()
        {
            List<AgentModel> d1 = new List<AgentModel>();
            try
            {
                ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
                var Adata = unitOfWork.agents.getList(a => a.IsActive == true).ToList();
                if (Adata is not null)
                {

                    foreach (var item in Adata)
                    {
                        AgentModel d2 = new AgentModel();
                        d2.Id = item.Id;
                        d2.Name = item.Name;
                        d2.Email = item.Email;
                        d2.Phone = item.Phone;
                        d2.Address = item.Address;
                        d2.Profile = item.Profile;
                        d2.Department = item.Department;
                        d2.CreatedDate = item.CreatedDate;

                        d1.Add(d2);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }

        public IActionResult Properties()
        {
            MainModel d1 = new MainModel();
            try
            {
                ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
                var agentData = unitOfWork.agents.getList(a => a.IsActive == true).ToList();
                if (agentData is not null)
                {
                    foreach (var item in agentData)
                    {
                        AgentModel d3 = new AgentModel();
                        d3.Id = item.Id;
                        d3.Name = item.Name;
                        d1.Agents.Add(d3);
                    }
                }
                var Adata = unitOfWork.properties.getList(a => a.IsActive == true).ToList();

                if (Adata is not null)
                {

                    foreach (var item in Adata)
                    {
                        PropertyModel d2 = new PropertyModel();
                        d2.Id = item.Id;
                        d2.PropertyName = item.PropertyName;
                        d2.PropertyType = item.PropertyType;
                        d2.CommercialType = item.CommercialType;
                        d2.ResidentType = item.ResidentType;
                        d2.Purpose = item.Purpose;
                        //d2.SqFt = item.SqFt;
                        d2.TotalBedroom = item.TotalBedroom;
                        d2.TotalBath = item.TotalBath;
                        d2.Pic1 = item.Pic1;
                        d2.Pic2 = item.Pic2;
                        d2.Pic3 = item.Pic3;
                        d2.Price = item.Price;
                        d2.Country = item.Country;
                        d2.City = item.City;
                        d2.Area = item.Area;
                        d2.Area = item.Area;
                        d2.OwnerName = item.OwnerName;
                        d2.OwnerAddress = item.OwnerAddress;
                        d2.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d2.AgentId = item.AgentId;
                        d2.Description = item.Description;
                        d2.CreatedDate = DateTime.Now;

                        d1.property.Add(d2);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }

        public IActionResult Blogs()
        {
            List<BlogModel> d1 = new List<BlogModel>();
            try
            {
                ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
                var Adata = unitOfWork.blogs.getList(a => a.IsActive == true).ToList();
                if (Adata is not null)
                {

                    foreach (var item in Adata)
                    {
                        BlogModel d2 = new BlogModel();
                        d2.Id = item.Id;
                        d2.Title = item.Title;
                        d2.CreatedUser = item.CreatedUser;
                        d2.PictureOne = item.PictureOne;
                        d2.PictureTwo = item.PictureTwo;
                        d2.CreatedDate = item.CreatedDate;
                        d2.Description = item.Description;

                        d1.Add(d2);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }

        public IActionResult AddAgent(AgentModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var d2 = unitOfWork.agents.FindFirstOrDefault(a => a.Id == model.Id);
                    if (d2 != null)
                    {
                        d2.Name = model.Name;
                        d2.Email = model.Email;
                        d2.Phone = model.Phone;
                        d2.Address = model.Address;
                        d2.Department = model.Department;
                        if (model.Profile is not null)
                        {
                            d2.Profile = model.Profile;
                        }
                        unitOfWork.agents.Update(d2);
                        unitOfWork.Save();
                        TempData["AlertMessage"] = "Information has been update successfully!";
                        TempData["AlertType"] = "success";
                    }
                }
                else
                {
                    Agent d1 = new Agent();
                    d1.Name = model.Name;
                    d1.Email = model.Email;
                    d1.Phone = model.Phone;
                    d1.Address = model.Address;
                    d1.Department = model.Department;
                    d1.Profile = model.Profile;
                    d1.IsActive = true;
                    d1.CreatedDate = DateTime.Now;
                    unitOfWork.agents.Add(d1);
                    unitOfWork.Save();
                    TempData["AlertMessage"] = "Information has been saved successfully!";
                    TempData["AlertType"] = "success";
                }
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.Message;
                TempData["AlertType"] = "error";
            }
            return RedirectToAction("Agents");
        }

        public IActionResult terminateAgent(int Id)
        {
            try
            {
                var d1 = unitOfWork.agents.FindFirstOrDefault(a => a.Id == Id);
                if (d1 is not null)
                {
                    d1.IsActive = false;
                    unitOfWork.agents.Update(d1);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Agents");
        }

        public IActionResult AddProperty(PropertyModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var d2 = unitOfWork.properties.FindFirstOrDefault(p => p.Id == model.Id);
                    if (d2 is not null)
                    {
                        d2.PropertyName = model.PropertyName;
                        d2.PropertyType = model.PropertyType;
                        d2.CommercialType = model.CommercialType;
                        d2.ResidentType = model.ResidentType;
                        d2.Purpose = model.Purpose;
                        d2.SqFt = model.SqFt;
                        d2.Description = model.Description;
                        d2.TotalBedroom = model.TotalBedroom;
                        d2.TotalBath = model.TotalBath;
                        if (model.Pic1 is not null)
                        {
                            d2.Pic1 = model.Pic1;
                        }
                        if (model.Pic2 is not null)
                        {
                            d2.Pic2 = model.Pic2;
                        }
                        if (model.Pic3 is not null)
                        {
                            d2.Pic3 = model.Pic3;
                        }
                        d2.Price = model.Price;
                        d2.Country = model.Country;
                        d2.City = model.City;
                        d2.Area = model.Area;
                        d2.Area = model.Area;
                        d2.OwnerName = model.OwnerName;
                        d2.OwnerAddress = model.OwnerAddress;
                        d2.OwnerPhoneNumber = model.OwnerPhoneNumber;
                        d2.AgentId = model.AgentId;

                        unitOfWork.properties.Update(d2);
                        unitOfWork.Save();
                        TempData["AlertMessage"] = "Information has been update successfully!";
                        TempData["AlertType"] = "success";
                    }
                }
                else
                {
                    Property d1 = new Property();
                    d1.PropertyName = model.PropertyName;
                    d1.PropertyType = model.PropertyType;
                    d1.CommercialType = model.CommercialType;
                    d1.ResidentType = model.ResidentType;
                    d1.Purpose = model.Purpose;
                    d1.SqFt = model.SqFt;
                    d1.TotalBedroom = model.TotalBedroom;
                    d1.TotalBath = model.TotalBath;
                    d1.Pic1 = model.Pic1;
                    d1.Pic2 = model.Pic2;
                    d1.Pic3 = model.Pic3;
                    d1.Price = model.Price;
                    d1.Country = model.Country;
                    d1.City = model.City;
                    d1.Area = model.Area;
                    d1.Area = model.Area;
                    d1.OwnerName = model.OwnerName;
                    d1.OwnerAddress = model.OwnerAddress;
                    d1.OwnerPhoneNumber = model.OwnerPhoneNumber;
                    d1.AgentId = model.AgentId;
                    d1.Description = model.Description;
                    d1.CreatedDate = DateTime.Now;
                    d1.IsActive = true;

                    unitOfWork.properties.Add(d1);
                    unitOfWork.Save();
                    TempData["AlertMessage"] = "Information has been saved successfully!";
                    TempData["AlertType"] = "success";
                }
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.Message;
                TempData["AlertType"] = "error";
            }
            return RedirectToAction("Properties");
        }

        public IActionResult terminatePropert(int Id)
        {
            try
            {
                var d1 = unitOfWork.properties.FindFirstOrDefault(a => a.Id == Id);
                if (d1 is not null)
                {
                    d1.IsActive = false;
                    unitOfWork.properties.Update(d1);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Properties");
        }

        public IActionResult AddBlog(BlogModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var d2 = unitOfWork.blogs.FindFirstOrDefault(b => b.Id == model.Id);
                    if (d2 is not null)
                    {
                        d2.Title = model.Title;
                        d2.CreatedUser = model.CreatedUser;
                        if (model.PictureOne is not null)
                        {
                            d2.PictureOne = model.PictureOne;
                        }
                        if (model.PictureTwo is not null)
                        {
                            d2.PictureTwo = model.PictureTwo;
                        }
                        d2.Description = model.Description;
                        unitOfWork.blogs.Update(d2);
                        unitOfWork.Save();
                        TempData["AlertMessage"] = "Information has been update successfully!";
                        TempData["AlertType"] = "success";
                    }
                }
                else
                {
                    Blog d1 = new Blog();
                    d1.Title = model.Title;
                    d1.CreatedUser = model.CreatedUser;
                    d1.PictureOne = model.PictureOne;
                    d1.PictureTwo = model.PictureTwo;
                    d1.Description = model.Description;
                    d1.CreatedDate = DateTime.Now;
                    d1.IsActive = true;

                    unitOfWork.blogs.Add(d1);
                    unitOfWork.Save();
                    TempData["AlertMessage"] = "Information has been saved successfully!";
                    TempData["AlertType"] = "success";
                }

            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.Message;
                TempData["AlertType"] = "error";
            }
            return RedirectToAction("Blogs");
        }
        public IActionResult terminateBlog(int Id)
        {
            try
            {
                var d1 = unitOfWork.blogs.FindFirstOrDefault(b => b.Id == Id);
                if (d1 is not null)
                {
                    d1.IsActive = false;
                    unitOfWork.blogs.Update(d1);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Blogs");
        }


        public IActionResult ContactUsList()
        {
            List<ContactModel> d1 = new List<ContactModel>();
            try
            {
                var d2 = unitOfWork.contactUs.getList(c => c.IsActive == true);
                if(d2 is not null)
                {
                    foreach(var item in d2)
                    {
                        ContactModel d3 = new ContactModel();
                        d3.Id = item.Id;
                        d3.Name = item.Name;
                        d3.Email = item.Email;
                        d3.Subject = item.Subject;
                        d3.Message = item.Message;
                        d3.CreatedDate = item.CreatedDate;
                        d1.Add(d3);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }

        public IActionResult UserQuery()
        {
            List<userQueryModel> d1 = new List<userQueryModel>();
            try
            {
                var d2 = unitOfWork.userQuery.getList(u => u.IsActive == true).ToList();
                if(d2 is not null)
                {
                    foreach(var item in d2)
                    {
                        userQueryModel d3 = new userQueryModel();
                        d3.Id = item.Id;
                        d3.Name = item.Name;
                        d3.Email = item.Email;
                        d3.Mobile = item.Mobile;
                        d3.Purpose = item.Purpose;
                        d3.Property = item.Property;
                        d3.CreatedDate = item.CreatedDate;
                        d1.Add(d3);
                    }
                }
            }catch(Exception ex)
            {

            }
            return View(d1);
        }
    }
}
