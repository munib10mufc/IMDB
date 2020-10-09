<%@ Page Title="" Language="C#" MasterPageFile="~/master1.Master" AutoEventWireup="true" CodeBehind="UpComingMovies.aspx.cs" Inherits="imdb.UpComingMovies" %>
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
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>All Upcoming Movies</title>
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-func.js"></script>
</head>
<body>
    <!-- Shell -->
    <div id="shell">
        <!-- Main -->
        <div id="main">
            <!-- Content -->
            <div id="content">
                <!-- Box -->
                <div class="box">
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Guardians Of Galaxy</span></span><img src="images/guardiansofglaxy.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">1</span>
                        </div>
                        <br /><a href="Webguardiansofgalaxy.aspx">
                        Guardians Of Galaxy</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Fast 7</span></span><img src="images/fast7.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">3</span>
                        </div>
                        <br /><a href="Webfastandfurious7.aspx">
                        Fast & Furious 7</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Edge Of Tomorrow</span></span><img src="images/edgeoftomorrow.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">6</span>
                        </div>
                        <br /><a href="Webedgeoftomorrow.aspx">
                        Edge Of Tomorrow</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Tammy</span></span><img src="images/tammy.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">16</span>
                        </div>
                        <br /><a href="Webtammy.aspx">
                        Tammy</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Earth To Echo</span></span><img src="images/earth.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">6</span>
                        </div>
                        <br /><a href="Webearthtoecho.aspx">
                        Earth To Echo</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Into The Storm</span></span><img src="images/intothestorm.jpg"
                                alt="movie" />
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">10</span>
                        </div>
                        <br /><a href="Webintothestorm.aspx">
                        Into The Storm</a>
                    </div>
                    <!-- end Movie -->
                    <br />
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <span class="play"><span class="name">Sex Tape</span></span><img src="images/sextape.jpg"
                                alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">22</span>
                        </div>
                        <br /><a href="Websextape.aspx">
                        Sex Tape</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <a href="#"><span class="play"><span class="name">Search Party</span></span><img
                                src="images/searchparty.jpg" alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">19</span>
                        </div>
                        <br /><a href="Websearchparty.aspx">
                        Search Party</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <a href="#"><span class="play"><span class="name">The Equalizer</span></span><img
                                src="images/theequalizer.jpg" alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">5</span>
                        </div>
                        <br /><a href="Webtheequalizer.aspx">
                        The Equalizer</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <a href="#"><span class="play"><span class="name">Hercules</span></span><img src="images/hercules.jpg"
                                alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">12</span>
                        </div>
                        <br /><a href="Webhercules.aspx">
                        Hercules</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie last">
                        <div class="movie-image">
                            <a href="#"><span class="play"><span class="name">Gone Girl</span></span><img src="images/gonegirl.jpg"
                                alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">23</span>
                        </div>
                        <br /><a href="Webgonegirl.aspx">
                        Gone Girl</a>
                    </div>
                    <!-- end Movie -->
                    <!-- Movie -->
                    <div class="movie">
                        <div class="movie-image">
                            <a href="#"><span class="play"><span class="name">Dawn of the Planet of the Apes</span></span><img
                                src="images/dawnofplanet.jpg" alt="movie" /></a>
                        </div>
                        <div class="rating">
                            <p>
                                RATING</p>
                            <div class="stars">
                                <div class="stars-in">
                                </div>
                            </div>
                            <span class="comments">3</span>
                        </div>
                        <br /><a href="Webdawnofplanetofapes.aspx">
                        Dawn of the Planet of the Apes</a>
                    </div>
                    <!-- end Movie -->
                    <div class="cl">
                        &nbsp;</div>
                </div>
                <!-- end Box -->
            </div>
             <div>
                    <form id="upcomingmovies" runat="server">
                    <asp:Button ID="upcomingmovieshow" runat="server" class="chaipi"  OnClick="showupcomingmovies" Text="show data"
                        Height="50px" Width="100px" Font-Size="Medium" ForeColor="Red" Font-Underline="true" />
                        <br /><br />
                        <asp:Label ID="coming" Visible="false" runat="server" Font-Size="Medium" Text="All Upcoming Movies Are:" ForeColor="LightSkyBlue"></asp:Label>
                   <br /><br />
                    <asp:GridView CssClass="mGrid" ID="ItemGrid3" runat="server" Visible="false" CellPadding="15" CellSpacing="15">
                    </asp:GridView>
                    </form>
                </div>
        </div>
    <!-- end Shell -->
</body>
</html>

</asp:Content>
