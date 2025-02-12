using MaxDataAccess;
using MaxDataAccess.Entites;
using MaxModels;
using MaxRealStateApp.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;

namespace MaxRealStateApp.Controllers
{
    public class ClientSide : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppSettings appSettings;

        public ClientSide(IUnitOfWork unitOfWork, IAppSettings appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Residential()
        {
            MainModel d1 = new MainModel();
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            try
            {
                var d2 = unitOfWork.properties.getList(p => p.IsActive == true && p.PropertyType == "Residential");
                if(d2 is not null)
                {
                    foreach(var item in d2)
                    {
                        
                        PropertyModel d3 = new PropertyModel();
                        if (item.AgentId > 0)
                        {
                            var agent = unitOfWork.agents.FindFirstOrDefault(a => a.IsActive == true && a.Id == item.AgentId);
                            if(agent is not null)
                            {
                                d3.AgentName = agent.Name;
                            }
                        }
                        d3.Id = item.Id;
                        d3.PropertyName = item.PropertyName;
                        d3.Purpose = item.PropertyType;
                        d3.SqFt = item.SqFt;
                        d3.Country = item.Country;
                        d3.City = item.City;
                        d3.Price = item.Price;
                        d3.Address = item.Address;
                        d3.ResidentType = item.ResidentType;
                      
                        d3.Pic1 = item.Pic1;
                        d3.Pic2 = item.Pic2;
                        d3.Pic3 = item.Pic3;
                        d3.Description = item.Description;
                        d3.TotalBedroom = item.TotalBedroom;
                        d3.TotalBath = item.TotalBath;
                        d3.Purpose = item.Purpose;
                        d3.OwnerName = item.OwnerName;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.OwnerAddress = item.OwnerAddress;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.AgentId = d3.AgentId;
                        d1.property.Add(d3);
                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }

        public IActionResult Commercial()
        {
            MainModel d1 = new MainModel();
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            try
            {
                var d2 = unitOfWork.properties.getList(p => p.IsActive == true && p.PropertyType == "Commercial");
                if (d2 is not null)
                {
                    foreach (var item in d2)
                    {

                        PropertyModel d3 = new PropertyModel();
                        if (item.AgentId > 0)
                        {
                            var agent = unitOfWork.agents.FindFirstOrDefault(a => a.IsActive == true && a.Id == item.AgentId);
                            if (agent is not null)
                            {
                                d3.AgentName = agent.Name;
                            }
                        }
                        d3.Id = item.Id;
                        d3.PropertyName = item.PropertyName;
                        d3.Purpose = item.PropertyType;
                        d3.SqFt = item.SqFt;
                        d3.Country = item.Country;
                        d3.City = item.City;
                        d3.Price = item.Price;
                        d3.Address = item.Address;
                        d3.CommercialType = item.CommercialType;
                        d3.Pic1 = item.Pic1;
                        d3.Pic2 = item.Pic2;
                        d3.Pic3 = item.Pic3;
                        d3.Description = item.Description;
                        d3.TotalBedroom = item.TotalBedroom;
                        d3.TotalBath = item.TotalBath;
                        d3.Purpose = item.Purpose;
                        d3.OwnerName = item.OwnerName;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.OwnerAddress = item.OwnerAddress;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.AgentId = d3.AgentId;
                        d1.property.Add(d3);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }
        public IActionResult AppSaleRent()
        {
            MainModel d1 = new MainModel();
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            try
            {
                var d2 = unitOfWork.properties.getList(p => p.IsActive == true && (p.ResidentType == "Appartment" || p.CommercialType == "Appartment"));
                if (d2 is not null)
                {
                    foreach (var item in d2)
                    {

                        PropertyModel d3 = new PropertyModel();
                        if (item.AgentId > 0)
                        {
                            var agent = unitOfWork.agents.FindFirstOrDefault(a => a.IsActive == true && a.Id == item.AgentId);
                            if (agent is not null)
                            {
                                d3.AgentName = agent.Name;
                            }
                        }
                        d3.Id = item.Id;
                        d3.PropertyName = item.PropertyName;
                        d3.Purpose = item.PropertyType;
                        d3.SqFt = item.SqFt;
                        d3.Country = item.Country;
                        d3.City = item.City;
                        d3.Price = item.Price;
                        d3.Address = item.Address;

                        d3.Pic1 = item.Pic1;
                        d3.Pic2 = item.Pic2;
                        d3.Pic3 = item.Pic3;
                        d3.Description = item.Description;
                        d3.TotalBedroom = item.TotalBedroom;
                        d3.TotalBath = item.TotalBath;
                        d3.Purpose = item.Purpose;
                        d3.OwnerName = item.OwnerName;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.OwnerAddress = item.OwnerAddress;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.AgentId = d3.AgentId;
                        d1.property.Add(d3);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }
        public IActionResult VillaSaleRent()
        {
            MainModel d1 = new MainModel();
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            try
            {
                var d2 = unitOfWork.properties.getList(p => p.IsActive == true && p.ResidentType == "Villa");
                if (d2 is not null)
                {
                    foreach (var item in d2)
                    {

                        PropertyModel d3 = new PropertyModel();
                        if (item.AgentId > 0)
                        {
                            var agent = unitOfWork.agents.FindFirstOrDefault(a => a.IsActive == true && a.Id == item.AgentId);
                            if (agent is not null)
                            {
                                d3.AgentName = agent.Name;
                            }
                        }
                        d3.Id = item.Id;
                        d3.PropertyName = item.PropertyName;
                        d3.Purpose = item.PropertyType;
                        d3.SqFt = item.SqFt;
                        d3.Country = item.Country;
                        d3.City = item.City;
                        d3.Price = item.Price;
                        d3.Address = item.Address;

                        d3.Pic1 = item.Pic1;
                        d3.Pic2 = item.Pic2;
                        d3.Pic3 = item.Pic3;
                        d3.Description = item.Description;
                        d3.TotalBedroom = item.TotalBedroom;
                        d3.TotalBath = item.TotalBath;
                        d3.Purpose = item.Purpose;
                        d3.OwnerName = item.OwnerName;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.OwnerAddress = item.OwnerAddress;
                        d3.OwnerPhoneNumber = item.OwnerPhoneNumber;
                        d3.AgentId = d3.AgentId;
                        d1.property.Add(d3);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }
        public IActionResult PropertyM()
        {
            return View();
        }
        public IActionResult Blog()
        {
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            List<BlogModel> d1 = new List<BlogModel>();
            try
            {
                var d2 = unitOfWork.blogs.getList(b => b.IsActive == true);
                if(d2 is not null)
                {
                    foreach(var item in d2)
                    {
                        BlogModel d3 = new BlogModel();
                        d3.Id = item.Id;
                        d3.Title = item.Title;
                        d3.CreatedUser = item.CreatedUser;
                        d3.Description = ExtractDescription(item.Description, 200);
                        d3.CreatedDate = item.CreatedDate;
                        d3.PictureOne = item.PictureOne;
                        d3.PictureTwo = item.PictureTwo;
                        d1.Add(d3);
                    }
                }
            }catch(Exception ex)
            {

            }
            return View(d1);
        }
        public IActionResult BlogPage(int Id)
        {
            ViewBag.ApiBaseUrl = appSettings.GetConfiguration().maxOwnlink;
            BlogModel d1 = new BlogModel();
            try
            {
                var d2 = unitOfWork.blogs.FindFirstOrDefault(b => b.Id == Id);
                if (d2 is not null)
                {

                    d1.Id = d2.Id;
                    d1.Title = d2.Title;
                    d1.CreatedUser = d2.CreatedUser;
                    d1.Description = d2.Description;
                    d1.CreatedDate = d2.CreatedDate;
                    d1.PictureOne = d2.PictureOne;
                    d1.PictureTwo = d2.PictureTwo;
                      
                    
                }
            }
            catch (Exception ex)
            {

            }
            return View(d1);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult ListProperty()
        {
            return View();
        }


        public IActionResult ContactUsAdd(ContactModel model)
        {
            try
            {
                ContactU d1 = new ContactU();
                d1.Name = model.Name;
                d1.Email = model.Email;
                d1.Subject = model.Subject;
                d1.Message = model.Message;
                d1.CreatedDate = DateTime.Now;
                d1.IsActive = true;
                unitOfWork.contactUs.Add(d1);
                unitOfWork.Save();
                TempData["AlertMessage"] = "Thank You!";
                TempData["AlertType"] = "success";
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("ContactUs");
        }

        public IActionResult UserQueryAdd(userQueryModel model)
        {
            try
            {
                UserQuery d1 = new UserQuery();
                d1.Name = model.Name;
                d1.Email = model.Email;
                d1.Mobile = model.Mobile;
                d1.Purpose = model.Purpose;
                d1.Property = model.Property;
                d1.CreatedDate = DateTime.Now;
                d1.IsActive = true;
                unitOfWork.userQuery.Add(d1);
                unitOfWork.Save();
                TempData["AlertMessage"] = "Thank You!";
                TempData["AlertType"] = "success";
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("ListProperty");
        }

        public static string ExtractDescription(string html, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;

            // Extract content of the <p> tags
            var regex = new Regex(@"<p>(.*?)<\/p>", RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);

            // Combine all <p> tag contents
            string description = string.Join(" ", matches.Select(m => m.Groups[1].Value));

            // Truncate the result to the specified length
            if (description.Length > maxLength)
            {
                description = description.Substring(0, maxLength).Trim() + "[…]";
            }

            return description;
        }



    }

}
