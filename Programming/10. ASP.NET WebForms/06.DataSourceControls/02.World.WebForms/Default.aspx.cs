using _01.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.World.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ListViewTowns_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;
            this.ListViewTowns.DataBind();
        }

        protected void ButtonInsertFormTown_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            (this.ListViewTowns.FindControl("ListViewTowns_IdTextBox") as TextBox).Text = this.GridViewCountries.SelectedDataKey.Value.ToString();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSaveCountry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCountryName.Text) &&
                !string.IsNullOrEmpty(this.txtCountryLanguage.Text) &&
                this.flagPicture.HasFile &&
                this.ListBoxContinents.SelectedIndex >= 0)
            {
                Byte[] imgByte = null;
                HttpPostedFile File = this.flagPicture.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                var db = new WorldEntities();
                var newCountry = new Country();
                newCountry.Name = Server.HtmlEncode(this.txtCountryName.Text);
                newCountry.Population = int.Parse(this.txtCountryPopulation.Text);
                newCountry.Language = Server.HtmlEncode(this.txtCountryLanguage.Text);
                newCountry.ContinentId = int.Parse(this.ListBoxContinents.SelectedValue);
                newCountry.Flag = imgByte;
                db.Countries.Add(newCountry);
                db.SaveChanges();
                this.GridViewCountries.DataBind();
            }
        }

        protected void btnChangeFlag_Click(object sender, EventArgs e)
        {
            var db = new WorldEntities();
            Country selected = new Country();
            if(this.GridViewCountries.SelectedIndex >= 0)
            {
                selected = db.Countries.Find(int.Parse(this.GridViewCountries.SelectedValue.ToString()));
            }

            if (this.changeFlagPicture.HasFile)
            {
                Byte[] imgByte = null;
                HttpPostedFile File = this.changeFlagPicture.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                selected.Flag = imgByte;
                db.SaveChanges();
            }

            this.GridViewCountries.DataBind();
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new WorldEntities();
            var name = db.Countries.Find(int.Parse(this.GridViewCountries.SelectedValue.ToString())).Name;
            this.ChangeFlagCountryName.Text = name;
        }

    }
}