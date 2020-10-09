using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webfast5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            fast5film.DataSource = objMyDal.getfast5();
            fast5film.DataBind();
            fast5data.DataSource = objMyDal.getfast5data();
            fast5data.DataBind();
        }
    }
}