using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webhercules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            herculesfilm.DataSource = objMyDal.getHercules();
            herculesfilm.DataBind();
            herculesdata.DataSource = objMyDal.getHerculesdata();
            herculesdata.DataBind();
        }
    }
}