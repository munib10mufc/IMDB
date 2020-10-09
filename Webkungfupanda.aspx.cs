using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webkungfupanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            kungfufilm.DataSource = objMyDal.getKungFuPanda();
            kungfufilm.DataBind();
            kungfudata.DataSource = objMyDal.getKungFuPandadata();
            kungfudata.DataBind();
        }
    }
}