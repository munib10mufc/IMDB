using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using imdb.DAL;

namespace imdb
{
    public partial class Webdawnofplanetofapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            dawnfilm.DataSource = objMyDal.getdawn();
            dawnfilm.DataBind();
            dawndata.DataSource = objMyDal.getdawndata();
            dawndata.DataBind();
        }
    }
}

//<div>
//        <form id="form1" runat="server">
//        <div>
//            <div class="movie-image">
//                <img src="images/dawnofplanet.jpg" alt="movie" />
//                <span><span class="name">
//                    <h1>
//                        Dawn of The Planets of The Apes</h1>
//                </span></span>
//            </div>
//            <div>
//                <div>
//                    <br />
//                    <br />
//                    <asp:Label ID="dawntext" runat="server" Font-Size="Medium" Text="   Movie Details Are:"
//                        ForeColor="LightSkyBlue"></asp:Label>
                    
//                    <asp:GridView ID="dawnfilm" RowStyle-BorderColor="LightSkyBlue" BorderColor="IndianRed"
//                        BackColor="darkslategray" Font-Bold="true" runat="server" CellPadding="15" CellSpacing="15">
//                    </asp:GridView>
//                    <br /><br />
//                    <asp:Label ID="dawntext2" runat="server" Font-Size="Medium" Text="   Actors Details Are:"
//                        ForeColor="LightSkyBlue"></asp:Label>
//                    <asp:GridView ID="dawndata" RowStyle-BorderColor="LightSkyBlue" BorderColor="IndianRed"
//                        BackColor="darkslategray" Font-Bold="true" runat="server" CellPadding="15" CellSpacing="15">
//                    </asp:GridView>
//                </div>
//            </div>
//        </div>
//        </form>
//    </div>