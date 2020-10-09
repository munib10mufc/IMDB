using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;
using System.Data.SqlClient;
namespace imdb
{
    public partial class AllMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemGrid.Visible = false;
            ItemGrid4.Visible = false;
            allmovies.Visible = false;
            oscar.Visible = false;
            LoadGrid(); // fill the grid every time page loads
            LoadOscar();
        }

        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            ItemGrid.DataSource = objMyDal.SelectFilm();//seting data source for this Grid
            ItemGrid.DataBind(); //bind the data source to this grid
        }
        protected void selectfilms(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            ItemGrid.Visible = true;
            allmovies.Visible = true;
        }

        public void LoadOscar()
        {
            myDAL objMyDal = new myDAL();
            ItemGrid4.DataSource = objMyDal.oscarwinning();//seting data source for this Grid
            ItemGrid4.DataBind(); //bind the data source to this grid
        }
        protected void selectoscarwinning(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            ItemGrid4.Visible = true;
            oscar.Visible = true;
        }


    }
}