using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _01.CarSearchForm.Models;
using System.Text;

namespace _01.CarSearchForm
{
    public partial class CarSearch : System.Web.UI.Page
    {
        private Producer[] producers;
        private Extra[] extras;
        private string[] engines;

        protected void Page_Init(object sender, EventArgs e)
        {
            producers = new Producer[]{ 
                    new Producer() { Name = "BMW", Models = new string[]{ "525", "630", "725", "Z3", "Z4" }},
                    new Producer() { Name = "VW", Models = new string[]{ "Polo", "Golf", "Passat", "Lupo", "Touran" }},
                    new Producer() { Name = "Opel", Models = new string[]{ "Corsa", "Tigra", "Insignia", "Zafira", "Astra" }},
                    new Producer() { Name = "Audi", Models = new string[]{ "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" }},
                    new Producer() { Name = "Mercedes", Models = new string[]{ "A200", "C220", "C280", "E250", "S280" }}
                };

            extras = new Extra[]
                {
                    new Extra() { Name = "Alarm" },
                    new Extra() { Name = "Air-condition" },
                    new Extra() { Name = "Central locking" },
                    new Extra() { Name = "4X4" },
                    new Extra() { Name = "ABS" },
                    new Extra() { Name = "ESP" },
                    new Extra() { Name = "Anti-fog lights" },
                    new Extra() { Name = "Electric windows" },
                    new Extra() { Name = "DVD" },
                    new Extra() { Name = "Parktronic" },
                    new Extra() { Name = "GPS" }
                };

            engines = new string[]{ "gasoline", "diesel", "electric", "hybrid" };

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.ProducerDropDown.DataSource = producers;
                this.ProducerDropDown.DataTextField = "Name";
                var models = producers.FirstOrDefault().Models;
                this.ModelDropDown.DataSource = models;
                this.ExtrasCheckBoxList.DataSource = extras;
                this.ExtrasCheckBoxList.DataTextField = "Name";
                this.EnginRadioButtonList.DataSource = engines;
                Page.DataBind();
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var html = new StringBuilder();
            html.Append("<h3>Search data: </h3><p>");
            html.AppendFormat("<b>Producer: </b> {0}<br/>", this.ProducerDropDown.SelectedValue);
            html.AppendFormat("<b>Model: </b> {0}<br/>", this.ModelDropDown.SelectedValue);
            html.AppendFormat("<b>Extras: </b> {0}<br/>", string.Join(", ", this.ExtrasCheckBoxList.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text)));
            html.AppendFormat("<b>Engine: </b> {0}<br/>", this.EnginRadioButtonList.SelectedItem.Text);
            html.Append("</p>");
            this.Result.Text = html.ToString();
        }

        protected void ProducerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var producerName = this.ProducerDropDown.SelectedItem.Text;
            var models = producers.FirstOrDefault(p => p.Name == producerName).Models;
            this.ModelDropDown.DataSource = models;
            Page.DataBind();
        }
    }
}