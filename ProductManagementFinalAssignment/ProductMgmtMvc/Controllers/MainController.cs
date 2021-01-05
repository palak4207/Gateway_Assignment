using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using ProductMgmtMvc.Models;
using Newtonsoft.Json;
using System.IO;
using PagedList;

namespace ProductMgmtMvc.Controllers
{
    public class MainController : Controller
    {

        // GET: Main 
        // List of Products and Searching ,Sorting and Paging
        [OutputCache(Location =System.Web.UI.OutputCacheLocation.None ,NoStore =true)]
        public ActionResult Index(string sortOrder, string currentFilter,string searchString,int? page)
        {
            var token = Convert.ToString(Session["token"]);
            if(Session["token"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/api/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var postTask = client.GetAsync("product/GetData");
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                
                var responseData = result.Content.ReadAsStringAsync().Result;
                 var jsondata = JsonConvert.DeserializeObject<IEnumerable<ProductDetails>>(responseData); 
                ViewBag.CurrentSort = sortOrder;

                if (searchString != null)
                {
                    page = 1;
                }

                else
                {
                    searchString = currentFilter;
                }
                ViewBag.CurrentFilter = searchString;
                if(!String.IsNullOrEmpty(searchString))
                {
                    jsondata = jsondata.Where(s => s.product_name.ToLower().Contains(searchString.ToLower()) || s.category_name.ToLower().Contains(searchString.ToLower()));
                }
                     switch(sortOrder)
                       {
                    case "name_desc":
                        jsondata = jsondata.OrderBy(s => s.product_name);
                        break;
                    case "category_desc":
                        jsondata = jsondata.OrderBy(s => s.category_name);
                        break;

                    default:
                        jsondata = jsondata.OrderBy(s => s.product_name);
                        break;
                }
                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(jsondata.ToPagedList(pageNumber,pageSize));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Main/Create
        
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Create()
        {

            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else { 
            return View();
            }
        }

        // POST: Main/Create
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Create(ProductDetails productDetails)
        {

            try
            {

                var token = Convert.ToString(Session["token"]);
                if (Session["token"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                //Used MultipartFormDataContent to Post Multipart Request
                HttpClient client = new HttpClient();
                  client.BaseAddress = new Uri("http://localhost:60760/api/");
               var multipart = new MultipartFormDataContent();
                string ext;
               if(productDetails.largeimg != null)
                {
                    ext = Path.GetExtension(productDetails.largeimg.FileName);
                    if (ext.ToLower().Equals(".jpg") || ext.ToLower().Equals(".png") || ext.ToLower().Equals(".jpeg"))
                    {

                        byte[] Bytes1 = new byte[productDetails.largeimg.InputStream.Length + 1];
                        productDetails.largeimg.InputStream.Read(Bytes1, 0, Bytes1.Length);
                        var fileContent2 = new ByteArrayContent(Bytes1);
                        fileContent2.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = productDetails.largeimg.FileName };
                        multipart.Add(fileContent2);
                    }
                    else
                    {
                        TempData["Message"] = "Invalid Image type";
                        return View();
                    }
                }
                string ext2 = Path.GetExtension(productDetails.smallimg.FileName);
                if (ext2.ToLower().Equals(".jpg") || ext2.ToLower().Equals(".png") || ext2.ToLower().Equals(".jpeg"))
                {
                    byte[] Bytes = new byte[productDetails.smallimg.InputStream.Length + 1];
                    productDetails.smallimg.InputStream.Read(Bytes, 0, Bytes.Length);
                    var fileContent = new ByteArrayContent(Bytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = productDetails.smallimg.FileName };
                    multipart.Add(fileContent);
                }
                else
                {

                    TempData["Message"] = "Invalid Image type";
                    return View();
                }

                multipart.Add(new StringContent(productDetails.category_name), "category_name");
                multipart.Add(new StringContent(productDetails.product_name), "product_name");
                multipart.Add(new StringContent(productDetails.long_des), "long_des");
                multipart.Add(new StringContent(productDetails.short_des), "short_des");
                multipart.Add(new StringContent(productDetails.price.ToString()), "price");
                multipart.Add(new StringContent(productDetails.quantity.ToString()), "quantity");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var postTask = client.PostAsync("product/MediaUpload", multipart).Result ;
                if(postTask.IsSuccessStatusCode)
                {
                   
                    TempData["Message"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else {

                    TempData["Message"] = "Invalid Request";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Edit(int id)
        {
            var token = Convert.ToString(Session["token"]);
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/api/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var postTask = client.GetAsync("product/GetData/"+id);
            var result = postTask.Result;
            Console.WriteLine(id);
            if (result.IsSuccessStatusCode)
            {
                var responseData = result.Content.ReadAsStringAsync().Result;
                var jsondata = JsonConvert.DeserializeObject<ProductDetails>(responseData);
                return View(jsondata);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // Edit Product Post Request
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult EditDetails(ProductDetails productDetails)
        {

            ProductModel productModel = new ProductModel();
            try
            {
                // TODO: Add update logic here
                var token = Convert.ToString(Session["token"]);
                if (Session["token"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60760/api/");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                if (productDetails.largeimg != null)
                {
                    string ext = Path.GetExtension(productDetails.largeimg.FileName);
                    if(ext.ToLower().Equals(".jpg") || ext.ToLower().Equals(".png") || ext.ToLower().Equals(".jpeg") )
                    {

                        productModel.large_img = LargeImage(productDetails);
                    }
                    else
                    {
                        TempData["Message"] = "Invalid Image type";
                        return RedirectToAction("Edit","Main",new { id=productDetails.Id});
                     }
                }
                if (productDetails.smallimg != null)
                    {
                    string ext = Path.GetExtension(productDetails.largeimg.FileName);
                    if (ext.ToLower().Equals(".jpg") || ext.ToLower().Equals(".png") || ext.ToLower().Equals(".jpeg"))
                    {

                        productModel.small_img = SmallImage(productDetails);
                    }
                    else
                    {
                        TempData["Message"] = "Invalid Image type";
                        return RedirectToAction("Edit", "Main", new { id = productDetails.Id });
                    }
                }


                    productModel.Id = productDetails.Id;
                    productModel.product_name = productDetails.product_name;
                    productModel.category_name = productDetails.category_name;
                    productModel.price = productDetails.price;
                    productModel.quantity = productDetails.quantity;
                    productModel.short_des = productDetails.short_des;
                    productModel.long_des = productDetails.long_des;

                    var postTaskproduct = client.PostAsJsonAsync<ProductModel>("product/UpdateData/" + productModel.Id, productModel).Result;
                    if (postTaskproduct.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Data Updated Successfully";
                    return RedirectToAction("Index");
                    }

                    else
                {
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Delete(int id)
        {

            var token = Convert.ToString(Session["token"]);
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/api/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var postTask = client.GetAsync("product/GetData/" + id);
            var result = postTask.Result;
            Console.WriteLine(id);
            if (result.IsSuccessStatusCode)
            {
                var responseData = result.Content.ReadAsStringAsync().Result;
                var jsondata = JsonConvert.DeserializeObject<ProductDetails>(responseData);
                //  ProductDetails productDetails1 = jsondata[0];
                //Console.WriteLine(productDetails1);
                Console.WriteLine(jsondata);
                return View(jsondata);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


                }

        // POST: Main/Delete/5
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var token = Convert.ToString(Session["token"]);
                if (Session["token"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60760/api/");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var postTask = client.DeleteAsync("product/DeleteData/" + id);
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Data Deleted Successfully";
                    return RedirectToAction("Index");
                }

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult MultipleDelete(IEnumerable<int> product_ids)
        {
            try
            {
                var token = Convert.ToString(Session["token"]);
                if (Session["token"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60760/api/");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var postTask = client.PostAsJsonAsync<IEnumerable<int>>("product/MultipleDelete", product_ids);

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["Message"] = " Successfully Deleted Selected Items";
                    return RedirectToAction("Index");
                }

                // TODO: Add delete logic here
                if(product_ids == null) { 
                TempData["Message"] = "Invaid Input";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string SmallImage(ProductDetails productDetails)
        {
            var token = Convert.ToString(Session["token"]);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/api/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var multipartsmall = new MultipartFormDataContent();
            byte[] Bytes = new byte[productDetails.smallimg.InputStream.Length + 1];
            productDetails.smallimg.InputStream.Read(Bytes, 0, Bytes.Length);
            var fileContent = new ByteArrayContent(Bytes);
            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = productDetails.smallimg.FileName };
            multipartsmall.Add(fileContent);
            var postTaskres = client.PostAsync("product/SmallImageUpload", multipartsmall).Result;
            if (postTaskres.IsSuccessStatusCode)
            {
                var responseData = postTaskres.Content.ReadAsAsync<ProductDetails>().Result;
                return responseData.small_img;
            }
            return null;
        }

        public string LargeImage(ProductDetails productDetails)
        {
            var token = Convert.ToString(Session["token"]);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/api/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var multipart = new MultipartFormDataContent();
            byte[] Bytes1 = new byte[productDetails.largeimg.InputStream.Length + 1];
            productDetails.largeimg.InputStream.Read(Bytes1, 0, Bytes1.Length);
            var fileContent2 = new ByteArrayContent(Bytes1);
            fileContent2.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = productDetails.largeimg.FileName };
            multipart.Add(fileContent2);
            var postTask = client.PostAsync("product/LargeImageUpload", multipart).Result;
            if (postTask.IsSuccessStatusCode)
            {
                var responseData = postTask.Content.ReadAsAsync<ProductDetails>().Result;
                return responseData.large_img;
            }
            return null;
        }

        public ActionResult Logout()
        {
            Session.Remove("token");
            return RedirectToAction("Index", "Home");

        }
    }

}
