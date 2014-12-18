﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.TotalVisitorsDb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new VisitorCountEntities();
            var visit = db.Visitors.FirstOrDefault();
            if(visit == null)
            {
                visit = new Visitor() { Count = 0, Id = 1 };
                db.Visitors.Add(visit);
                db.SaveChanges();
            }

            visit.Count = visit.Count + 1;
            db.SaveChanges();

            Response.Clear();

            this.GenerateImage(
                Response,
                "Total visitors: " + visit.Count,
                200,
                200,
                Color.White,
                FontFamily.GenericSansSerif,
                18,
                Brushes.Red,
                20,
                20,
                "image/jpeg",
                ImageFormat.Jpeg);
        }

        private void GenerateImage(
            HttpResponse response,
            string textToInsert,
            int width,
            int height,
            Color backgroundColor,
            FontFamily fontFamily,
            float emSize,
            Brush brush,
            float x,
            float y,
            string contentType,
            ImageFormat imageFormat)
        {
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);
                    graphics.DrawString(textToInsert, new Font(fontFamily, emSize), brush, x, y);
                    response.ContentType = contentType;
                    bitmap.Save(response.OutputStream, imageFormat);
                }
            }
        }
    }
}