using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webthor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            thorfilm.DataSource = objMyDal.getthor();
            thorfilm.DataBind();
            thordata.DataSource = objMyDal.getthordata();
            thordata.DataBind();
        }
    }
}