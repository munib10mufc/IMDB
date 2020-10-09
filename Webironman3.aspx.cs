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
    public partial class Webironman3 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            ironman3film.DataSource = objMyDal.getironman3();
            ironman3film.DataBind();
            ironman3data.DataSource = objMyDal.getironman3data();
            ironman3data.DataBind();
        }
    }
}