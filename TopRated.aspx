<%@ Page Title="" Language="C#" MasterPageFile="~/master1.Master" AutoEventWireup="true"
    CodeBehind="TopRated.aspx.cs" Inherits="imdb.TopRated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <style type="text/css">
        
.gridview
{
    width: 100%;
    background-color: #fff;
    margin: 5px 0 10px 0;
    border: solid 1px #525252;
    border-collapse:collapse;
}
.gridview td
{
    padding: 2px;
    border: solid 1px #c1c1c1;
    color: #717171;
}
.gridview th
{
    padding: 4px 2px;
    color: #fff;
    background: #424242;
    border-left: solid 1px #525252;
    font-size: 0.9em;
}
.gridview .gridview_alter 
{
    background: #E7E7E7;
}
.gridview .gridview_pager 
{
    background: #424242;
}
.gridview .gridview_pager table 
{
    margin: 5px 0;
}
.gridview .gridview_pager td
{
    border-width: 0;
    padding: 0 6px;
    border-left: solid 1px #666;
    font-weight: bold;
    color: #fff;
    line-height: 12px;
 }  
.gridview .gridview_pager a 
{
    color: #666;
    text-decoration: none;
}
.gridview .gridview_pager a:hover 
{
    color: #000;
    text-decoration: none;
}
    .mGrid {   
        width: 100%;   
        background-color: #fff;   
        margin: 5px 0 10px 0;   
        border: solid 1px #525252;   
        border-collapse:collapse;   
    }  
    .mGrid td {   
        padding: 2px;   
        border: solid 1px #c1c1c1;   
        color: #717171;   
    }  
    .mGrid th {   
        padding: 4px 2px;   
        color: #fff;   
        background: #424242 url(grd_head.png) repeat-x top;   
        border-left: solid 1px #525252;   
        font-size: 0.9em;   
    }  
    .mGrid .alt { background: #fcfcfc url(grd_alt.png) repeat-x top; }  
    .mGrid .pgr { background: #424242 url(grd_pgr.png) repeat-x top; }  
    .mGrid .pgr table { margin: 5px 0; }  
    .mGrid .pgr td {   
        border-width: 0;   
        padding: 0 6px;   
        border-left: solid 1px #666;   
        font-weight: bold;   
        color: #fff;   
        line-height: 12px;   
     }     
    .mGrid .pgr a { color: #666; text-decoration: none; }  
    .mGrid .pgr a:hover { color: #000; text-decoration: none; }  
        label
        {
            display: block;
            padding-left: 500px;
            text-indent: 50px;
        }
        temp
        {
            padding-left: 160px;
        }
    </style>
    <head>
    </head>
    <body>
        <!-- Shell -->
        <div id="shell">
            <p style="text-align: center; font-family: arial; color: yellow; font-size: 30px;">
                Top 10 Movies Are</p>
            <!-- Main -->
            <div id="main">
                <!-- Content -->
                <div id="content">
                    <!-- Box -->
                    <div class="box">
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">Edge Of Tomorrow</span></span><img src="images/edgeoftomorrow.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 8.3
                                    </p>
                                </h4>
                                <span class="comments">6</span>
                            </div>
                            <br /><a href="Webedgeoftomorrow.aspx">
                            Edge Of Tomorrow</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie last">
                            <div class="movie-image">
                                <a href="#"><span class="play"><span class="name">Gone Girl</span></span><img src="images/gonegirl.jpg"
                                    alt="movie" /></a>
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 8.0
                                    </p>
                                </h4>
                                <span class="comments">23</span>
                            </div>
                            <br /><a href="Webgonegirl.aspx">
                            Gone Girl</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">Tammy</span></span><img src="images/tammy.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 7.5
                                    </p>
                                </h4>
                                <span class="comments">16</span>
                            </div>
                            <br /><a href="Webtammy.aspx">
                            Tammy</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <a href="#"><span class="play"><span class="name">Hercules</span></span><img src="images/hercules.jpg"
                                    alt="movie" /></a>
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 7.2
                                    </p>
                                </h4>
                                <span class="comments">12</span>
                            </div>
                            <br /><a href="Webhercules.aspx">
                            Hercules</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">Kung Fu Panda</span></span><img src="images/kungfu.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 7.0
                                    </p>
                                </h4>
                                <span class="comments">23</span>
                            </div>
                            <br /><a href="Webkungfupanda.aspx">
                            Kung Fu Panda</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">Earth To Echo</span></span><img src="images/earth.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h3>
                                    <p>
                                        RATING 6.6
                                    </p>
                                </h3>
                                <span class="comments">6</span>
                            </div>
                            <br /><a href="Webearthtoecho.aspx">
                            Earth To Echo</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">50 Shades of Grey</span></span><img src="images/50shades.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h3>
                                    <p>
                                        RATING 6.6
                                    </p>
                                </h3>
                                <span class="comments">3</span>
                            </div>
                            <br /><a href="Web50shades.aspx">
                            50 Shades Of Grey</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <span class="play"><span class="name">Fast &Furious 7</span></span><img src="images/fast7.jpg"
                                    alt="movie" />
                            </div>
                            <div class="rating">
                                <h3>
                                    <p>
                                        RATING 6.5
                                    </p>
                                </h3>
                                <span class="comments">3</span>
                            </div>
                            <br /><a href="Webfastandfurious7.aspx">
                            Fast & Furious 7</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <a href="#"><span class="play"><span class="name">The Equalizer</span></span><img
                                    src="images/theequalizer.jpg" alt="movie" /></a>
                            </div>
                            <div class="rating">
                                <h3>
                                    <p>
                                        RATING 6.4
                                    </p>
                                </h3>
                                <span class="comments">5</span>
                            </div>
                            <br /><a href="Webtheequalizer.aspx">
                            The Equalizer</a>
                        </div>
                        <!-- end Movie -->
                        <!-- Movie -->
                        <div class="movie">
                            <div class="movie-image">
                                <a href="#"><span class="play"><span class="name">Dawn of Planet Apes</span></span><img
                                    src="images/dawnofplanet.jpg" alt="movie" /></a>
                            </div>
                            <div class="rating">
                                <h4>
                                    <p>
                                        RATING 8.2
                                    </p>
                                </h4>
                                <span class="comments">3</span>
                            </div>
                            <br /><a href="Webdawnofplanetofapes.aspx">
                            Dawn of Planet Apes</a>
                        </div>
                        <!-- end Movie -->
                        <div class="cl">
                            &nbsp;</div>
                    </div>
                    <!-- end Box -->
                </div>
                <div>
                    <form id="moviesintheater" runat="server">
                    <asp:Button class="chaipi"  ID="toprated1" runat="server" Text="Show Top Rated" Height="50px" Width="150px"
                        Font-Size="Medium" ForeColor="Red" OnClick="toprated" Font-Underline="true" />
                    <br />
                    <br />
                    <asp:Label ID="top10" Visible="false" runat="server" Font-Size="Medium" Text="Top 10 Movies are:"
                        ForeColor="LightSkyBlue"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView  CssClass="mGrid"
                        Font-Bold="true" ID="gridtop10" runat="server" Visible="false" CellPadding="15"
                        CellSpacing="15">
                    </asp:GridView>
                    </form>
                </div>
            </div>
        </div>
        <!-- end Shell -->
    </body>
    </html>
</asp:Content>
