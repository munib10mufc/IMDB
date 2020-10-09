using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class TopRated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid(); // fill the grid every time page loads
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            gridtop10.DataSource = objMyDal.top10();
            gridtop10.DataBind();
        }

        protected void toprated(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            gridtop10.Visible = true;
            top10.Visible = true;
        }
    }
}