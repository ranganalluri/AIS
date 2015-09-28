using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test.Caching
{
    public partial class Page : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
          //  var t = Class1.TestDealy().ContinueWith(s=> Debug.Write(s.Result));

            
            Class1.TestDealy();
            Response.Redirect("Page2.aspx", false);

        }

        
    }




}