using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class borntoday : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            borntodaygrid.Visible = false;
            borntodaytext.Visible = false;
            LoadGrid();
        }

        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            borntodaygrid.DataSource = objMyDal.showborntoday1();//seting data source for this Grid
            borntodaygrid.DataBind(); //bind the data source to this grid
        }
        protected void showborntoday(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            borntodaygrid.Visible = true;
            borntodaytext.Visible = true;
        }
    }
}