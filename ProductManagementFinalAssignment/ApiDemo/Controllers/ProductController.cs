using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using ApiDemo.Models;
using System.Web.Http.Cors;
namespace ApiDemo.Controllers
{
    [EnableCors(origins:"*" , headers: "*" ,methods:"*")]
    [Authorize]
    public class ProductController : ApiController
    {
        
        ProductDbApiEntities1 productdb = new ProductDbApiEntities1();
        

        // GET: api/Product/GetData
        //Api for Returning All Products
        [Route("api/product/GetData")]
        public IHttpActionResult GetData()
        {
            try
            {
                IList<productdetail> products = null;
                products = productdb.productdetails.ToList<productdetail>();
               return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Product/GetData/5
        //Api for Returning Single Product using Id 
        [HttpGet]
        [Route("api/product/GetData/{id}")]
        public IHttpActionResult GetData(int id)
        {

            var entity = productdb.productdetails.FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity) ;
        }

          //Api for Handling Multipart Request 
        [HttpPost]
        [Route("api/product/MediaUpload")]
        public async Task<HttpResponseMessage> MediaUpload()
        {
            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            //access files  
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

            string filename = String.Empty;
            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];


            var path = HttpRuntime.AppDomainAppPath;
            directoryName = System.IO.Path.Combine(path, "smallimg");
            filename = System.IO.Path.Combine(directoryName, thisFileName);

            //Deletion exists file  
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            string DocsPath = tempDocUrl + "/" + "smallimg" + "/";
            URL = DocsPath + thisFileName;


            try
            {

                productdetail productdetail = new productdetail();
                productdetail.product_name = formData["product_name"];
                productdetail.category_name = formData["category_name"];
                productdetail.price = System.Convert.ToDecimal(formData["price"]);
                productdetail.quantity = System.Convert.ToInt32(formData["quantity"]);
                productdetail.short_des = formData["short_des"];
                productdetail.long_des = formData["long_des"];
                productdetail.small_img = URL;
                if (files.Count >= 2) 
                {
                    //Upload Large Image if There is more than one file Available
                    HttpContent file2 = files[1];
                    var thisFileName2 = file2.Headers.ContentDisposition.FileName.Trim('\"');
                    string filename2 = String.Empty;
                    Stream input2 = await file2.ReadAsStreamAsync();
                    string URL2 = String.Empty;
                    directoryName = System.IO.Path.Combine(path, "largeimg");
                    filename2 = System.IO.Path.Combine(directoryName, thisFileName2);
                    if (File.Exists(filename2))
                    {
                        File.Delete(filename2);
                    }

                     DocsPath = tempDocUrl + "/" + "largeimg" + "/";
                    URL2 = DocsPath + thisFileName2;
                    productdetail.large_img = URL2;
                    using (Stream file = File.OpenWrite(filename2))
                    {
                        input.CopyTo(file);
                        //close file  
                        file.Close();
                    }
                    

                }
                else
                {
                    //assign null to large product if there is only small image
                    productdetail.large_img = null;
                }

                string productdata = formData["product_name"] + formData["category_name"] + formData["short_des"] + formData["long_des"];
                //Directory.CreateDirectory(@directoryName);  
                using (Stream file = File.OpenWrite(filename))
                {
                    input.CopyTo(file);
                    //close file  
                    file.Close();
                }
              

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("DocsUrl", URL);
                response.Headers.Add("data", productdata);
                productdb.productdetails.Add(productdetail);
                productdb.SaveChanges();
                return response;
               }

            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("exceptipon", ex.Message);
                return response;
            }

        }



        //Api for Uploading Large Image
        [HttpPost]
        [Route("api/product/LargeImageUpload")]
        public async Task<HttpResponseMessage> LargeImageUpload()
        {
            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            //access files  
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
            string filename = String.Empty;
            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];
            var path = HttpRuntime.AppDomainAppPath;
            directoryName = System.IO.Path.Combine(path, "largeimg");
            filename = System.IO.Path.Combine(directoryName, thisFileName);

            //Deletion exists file  
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            string DocsPath = tempDocUrl + "/" + "largeimg" + "/";
            URL = DocsPath + thisFileName;
            try
            {

                productdetail productdetail = new productdetail();
                productdetail.large_img = URL;
                using (Stream file = File.OpenWrite(filename))
                {
                    input.CopyTo(file);
                    //close file  
                    file.Close();
                }

                var response = Request.CreateResponse(HttpStatusCode.OK,productdetail);
                response.Headers.Add("DocsUrl", URL);
                return response;
                }

            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("exceptipon", ex.Message);
                return response;
            }

        }

        //Api for Uploading Small Image
        [HttpPost]
        [Route("api/product/SmallImageUpload")]
        public async Task<HttpResponseMessage> SmallImageUpload()
        {
            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            //access files  
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
            string filename = String.Empty;
            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];
            var path = HttpRuntime.AppDomainAppPath;
            directoryName = System.IO.Path.Combine(path, "smallimg");
            filename = System.IO.Path.Combine(directoryName, thisFileName);

            //Deletion exists file  
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            string DocsPath = tempDocUrl + "/" + "smallimg" + "/";
            URL = DocsPath + thisFileName;
            try
            {
                productdetail productdetail = new productdetail();
                productdetail.small_img = URL;
                using (Stream file = File.OpenWrite(filename))
                {
                    input.CopyTo(file);
                    //close file  
                    file.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.OK, productdetail);
                response.Headers.Add("DocsUrl", URL);
                return response;
                  }

            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("exceptipon", ex.Message);
                return response;
            }

        }

        //Api for Updating Existing Product
        [HttpPost]
        [Route("api/product/UpdateData/{id}")]
        public IHttpActionResult UpdateData(int id,productdetail productdetail)
        {
            var entity = productdb.productdetails.FirstOrDefault(e => e.Id == id);
           
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                entity.product_name = productdetail.product_name;
                entity.category_name = productdetail.category_name;
                entity.price = productdetail.price;
                entity.quantity = productdetail.quantity;
                entity.short_des = productdetail.short_des;
                entity.long_des = productdetail.long_des;
                //Check For Small Image
                if(productdetail.small_img != null) { 
                entity.small_img = productdetail.small_img;
                }
                //Check For Large Image
                if (productdetail.large_img != null)
                {
                    entity.large_img = productdetail.large_img;
                }

              productdb.SaveChanges();
                return Ok();

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("api/product/MultipleDelete")]
        public IHttpActionResult MultipleDelete([FromBody] IEnumerable<int> mulId)
        {
            try { 
           IEnumerable<productdetail> products=productdb.productdetails.Where(x => mulId.Contains(x.Id)).ToList();

                //Loop For Deleting All Requested Products
           foreach (var c in products)
                {
                 productdb.productdetails.Remove(c);
                }
                productdb.SaveChanges();
                 return Ok();
             }
             catch (Exception ex)
             {
                 return BadRequest();
             }
        }

        //Single Product Delete
        [HttpDelete]
        [Route("api/product/DeleteData/{Id}")]
        public IHttpActionResult DeleteData(int Id)
        {

            try
            {
                productdetail product = productdb.productdetails.FirstOrDefault(e => e.Id == Id);
                if(product == null)
                {
                    return NotFound();

                }
                    productdb.productdetails.Remove(product);
                productdb.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

    }

    }

