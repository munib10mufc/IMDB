using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class UpComingMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemGrid3.Visible = false;
            coming.Visible = false;
            LoadGrid(); // fill the grid every time page loads

        }

        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            ItemGrid3.DataSource = objMyDal.upcomingmovies();//seting data source for this Grid
            ItemGrid3.DataBind(); //bind the data source to this grid
        }

        protected void showupcomingmovies(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            ItemGrid3.Visible = true;
            coming.Visible = true;
        }
    }
}