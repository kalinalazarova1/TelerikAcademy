using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.PhotoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[6];

            imgSlide[1] = new AjaxControlToolkit.Slide("images/bermudas.png", "bermudas", "Bermudas");
            imgSlide[2] = new AjaxControlToolkit.Slide("images/canada.png", "canada", "Canada");
            imgSlide[0] = new AjaxControlToolkit.Slide("images/groenlandia.png", "groenlandia", "Groenlandia");
            imgSlide[3] = new AjaxControlToolkit.Slide("images/mexico.png", "mexico", "Mexico");
            imgSlide[4] = new AjaxControlToolkit.Slide("images/sn_pedro_miquelon.png", "sn_pedro_miquelon", "St.Pedro Miquelon");
            imgSlide[5] = new AjaxControlToolkit.Slide("images/usa.png", "usa", "USA");

            return (imgSlide);
        }
    }
}