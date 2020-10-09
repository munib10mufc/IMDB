using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;
using System.Data.SqlClient;

namespace imdb
{
    public partial class InTheatre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid(); // fill the grid every time page loads
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            ItemGrid2.DataSource = objMyDal.intheater();
            ItemGrid2.DataBind();
        }

        protected void showdetailintheater(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            ItemGrid2.Visible = true;
            theater.Visible = true;
        }
    }
}
