using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webgravity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            gravityfilm.DataSource = objMyDal.getgravity();
            gravityfilm.DataBind();
            gravitydata.DataSource = objMyDal.getgravitydata();
            gravitydata.DataBind();
        }
    }
}