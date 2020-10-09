using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webfastandfurious6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            fast6film.DataSource = objMyDal.getfast6();
            fast6film.DataBind();
            fast6data.DataSource = objMyDal.getfast6data();
            fast6data.DataBind();
        }
    }
}