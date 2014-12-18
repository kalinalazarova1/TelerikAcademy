using _01.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.World.WebForms
{
    /// <summary>
    /// Summary description for ImageHttpHandler
    /// </summary>
    public class ImageHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["Id"]))
            {
                int countryId = Convert.ToInt32(context.Request.QueryString["Id"]);
                if (countryId > 0)
                {
                    var result = RetrieveFlagImage(countryId);
                    if (result != null)
                    {
                        context.Response.BinaryWrite(result);
                        context.Response.ContentType = "image/png";
                        context.Response.End();
                    }
                }
            }
        }

        private Byte[] RetrieveFlagImage(int countryId)
        {
            var db = new WorldEntities();
            var country = db.Countries.Find(countryId);
            if (country != null)
            {
                return country.Flag;
            }
            return null;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}