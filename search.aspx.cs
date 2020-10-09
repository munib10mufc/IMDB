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
    public partial class search : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            searchbox1.Visible = false;
            searchbox1text.Visible = false;
            searchbox2.Visible = false;
            searchbox2text.Visible = false;
            searchbox3.Visible = false;
            searchbox3text.Visible = false;
            searchbox4.Visible = false;
            searchbox4text.Visible = false;
            searchbox5.Visible=false;
            searchbox5text.Visible=false;
            LoadGrid1();
            LoadGrid2();
            LoadGrid3();
            LoadGrid4(); // fill the grid every time page loads
            LoadGrid5();


        }

        public void LoadGrid1()
        {
            myDAL objMyDal = new myDAL();
            searchbox1.DataSource = objMyDal.searchbyactor(getactorf.Text, getactorl.Text);
            searchbox1.DataBind();
        }

        protected void searchbyactor(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            searchbox1.Visible = true;
            searchbox1text.Visible = true;
        }


        public void LoadGrid2()
        {
            myDAL objMyDal = new myDAL();
            searchbox2.DataSource = objMyDal.searchbymoviename(getmovie.Text);
            searchbox2.DataBind();
        }

        protected void searchbymoviedata(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            searchbox2.Visible = true;
            searchbox2text.Visible = true;
        }

        public void LoadGrid3()
        {
            myDAL objMyDal = new myDAL();
            searchbox3.DataSource = objMyDal.searchdirectordetail(getdirectorf.Text, getdirectorl.Text);
            searchbox3.DataBind();

        }

        protected void searchbydirectorname(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            searchbox3.Visible = true;
            searchbox3text.Visible = true;
        }

        public void LoadGrid4()
        {
            myDAL objMyDal = new myDAL();
            searchbox4.DataSource = objMyDal.commonsearch(getactor1f.Text, getactor1l.Text, getactor2f.Text, getactor2l.Text);
            searchbox4.DataBind();
        }

        protected void showcmgrid(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            searchbox4.Visible = true;
            searchbox4text.Visible = true;
        }


        public void LoadGrid5()
        {
            myDAL objMyDal = new myDAL();
            searchbox5.DataSource = objMyDal.searchactordetail(actordetailf.Text, actordetaill.Text);
            searchbox5.DataBind();
        }

        protected void actordetail2(object sender, EventArgs e)
        {
            ViewState["Show"] = true;
            searchbox5.Visible = true;
            searchbox5text.Visible = true;
        }

        //public void LoadGrid2()
        //{
        //    myDAL objMyDal = new myDAL();
        //    searchbox2.DataSource = objMyDal.searchbymoviename(getmovie.Text);
        //    searchbox2.DataBind();

        //}


        //protected void box2grid(object sender, EventArgs e)
        //{
        //    ViewState["Show"] = true;
        //    searchbox2.Visible = true;
        //    searchbox2text.Visible = true;
        //}



    }
}