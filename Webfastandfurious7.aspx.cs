using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webfastandfurious7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            fast7film.DataSource = objMyDal.getfast7();
            fast7film.DataBind();
            fast7data.DataSource = objMyDal.getfast7data();
            fast7data.DataBind();
        }
    }
}