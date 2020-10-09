using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setStatus(object sender, EventArgs e)
        {
            myDAL obj = new myDAL();
            int rest = obj.SearchLogin(txtUsername.Text, txtPassword.Text);
            if (rest > 0)
            {
                st.InnerHtml = " correctUsername/Password";
                Response.Redirect("Home.aspx");
               

            }

            else
            {
                st.InnerHtml = "Wrong Username/Password";
            }


        }
    }
}