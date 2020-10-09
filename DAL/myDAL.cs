using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace imdb.DAL
{
    public class myDAL
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        public int user_login(string username, string password)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            int Results = 0;

            try
            {
                SqlCommand cmdselect = new SqlCommand("login", con);

                cmdselect.CommandType = CommandType.StoredProcedure;
                //cmdselect.CommandText = "[imdb].[users]";

                cmdselect.Parameters.Add("@inputusername", SqlDbType.VarChar, 30);
                cmdselect.Parameters["@inputusername"].Value = username;

                cmdselect.Parameters.Add("@inputpassword", SqlDbType.VarChar, 30);
                cmdselect.Parameters["@inputpassword"].Value = password;

                cmdselect.Parameters.Add("@outputresult ", SqlDbType.Int);

                cmdselect.Parameters["@outputresult "].Direction = ParameterDirection.Output;

                //con.Open();

                cmdselect.ExecuteNonQuery();

                Results = Convert.ToInt32(cmdselect.Parameters["@outputresult"].Value);

                con.Close();
            }

            catch (SqlException ex)
            {
                //lblMessage.Text = ex.Message;
                Console.WriteLine("SQL ERROR" + ex.Message.ToString());
            }
            finally
            {
                con.Close();

            }
            return Results;
        }
        public int SearchLogin(String user, String pass)
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("login", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@inputusername", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@inputpassword", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@outputresult", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@inputusername"].Value = user;
                cmd.Parameters["@inputpassword"].Value = pass;
                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@outputresult"].Value); //convert to output parameter to interger format
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }



        public DataSet SelectFilm() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(" SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (film join Director on Film.Director_ID=Director.Director_ID) join Genre on Film.Genre_ID=Genre.Genre_ID", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        public DataSet oscarwinning() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select * from Movies_who_won_Title", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }


        public DataSet intheater() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select * from intheatres", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }



        public DataSet showborntoday1() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT *  FROM imdb.Born_Today", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }




        public DataSet upcomingmovies() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select * from Upcoming_Movies", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }


        public DataSet top10() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select * from top10", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        public DataSet commonsearch(string ac1f, string ac1l, string ac2f, string ac2l) //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(" select imdb.film.titlename,imdb.film.description,imdb.film.runningtime,imdb.film.releasedate,imdb.Director.FirstName as Dir_fName,imdb.Director.LastName as Dir_LName,imdb.film.Language,imdb.film.Rating,imdb.Genre.GenreName from (((imdb.film join imdb.actedin	on imdb.film.film_id=imdb.actedin.film_id) join imdb.actor on imdb.actor.actor_id=imdb.actedin.actor_id)join imdb.Genre on Genre.Genre_ID=imdb.Film.Genre_ID) join imdb.Director on Director.Director_ID=Film.Director_ID where imdb.actor.firstname=@getactor1f and imdb.actor.lastname=@getactor1l	intersect	select imdb.film.titlename,imdb.film.description,imdb.film.runningtime,imdb.film.releasedate,imdb.Director.FirstName as Dir_fName,imdb.Director.LastName as Dir_LName,imdb.film.Language,imdb.film.Rating,imdb.Genre.GenreName 	from (((imdb.film join imdb.actedin 	on imdb.film.film_id=imdb.actedin.film_id) join imdb.actor on imdb.actor.actor_id=imdb.actedin.actor_id)join imdb.Genre on Genre.Genre_ID=imdb.Film.Genre_ID) join imdb.Director on Director.Director_ID=Film.Director_ID  where imdb.actor.firstname=@getactor2f and imdb.actor.lastname=@getactor2l 	", con);  //instantiate SQL command 
                cmd.Parameters.Add("getactor1f", SqlDbType.VarChar, 30).Value = ac1f;
                cmd.Parameters.Add("getactor1l", SqlDbType.VarChar, 30).Value = ac1l;
                cmd.Parameters.Add("getactor2f", SqlDbType.VarChar, 30).Value = ac2f;
                cmd.Parameters.Add("getactor2l", SqlDbType.VarChar, 30).Value = ac2l;

                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet searchbyactor(string ac1f, string ac1l) //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select TitleName,role from imdb.Film join imdb.ActedIn on imdb.Film.Film_ID=imdb.ActedIn.Film_ID  join imdb.Actor on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID where imdb.actor.firstname=@getactorf and imdb.actor.lastname=@getactorl ", con);  //instantiate SQL command 
                cmd.Parameters.Add("getactorf", SqlDbType.VarChar, 30).Value = ac1f;
                cmd.Parameters.Add("getactorl", SqlDbType.VarChar, 30).Value = ac1l;


                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }



        public DataSet searchbymoviename(string ac1f) //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Director.FirstName as director_firstname,imdb.Director.LastName as director_lastname,imdb.Actor.FirstName as actor_firstname,imdb.Actor.LastName as actor_lastname,role from imdb.Director join imdb.Film on imdb.Director.Director_ID=imdb.Film.Director_ID join imdb.ActedIn on imdb.ActedIn.Film_ID=imdb.Film.Film_ID join imdb.Actor on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID where TitleName=@moviename", con);  //instantiate SQL command 

                cmd.Parameters.Add("moviename", SqlDbType.VarChar, 30).Value = ac1f;

                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }

        private object GetDataTable(string p)
        {
            throw new NotImplementedException();
        }


        public DataSet searchdirectordetail(string ac1f, string ac1l) //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Film.TitleName, Description,RunningTime,ReleaseDate,Rating,Language,imdb.Genre.GenreName from (imdb.Film join imdb.Director on imdb.Film.Director_ID=imdb.Director.Director_ID) join imdb.Genre on imdb.Film.Genre_ID=imdb.Genre.Genre_ID where imdb.Director.FirstName=@getdirectorf and imdb.Director.LastName=@getdirectorl", con);  //instantiate SQL command 
                cmd.Parameters.Add("getdirectorf", SqlDbType.VarChar, 30).Value = ac1f;
                cmd.Parameters.Add("getdirectorl", SqlDbType.VarChar, 30).Value = ac1l;


                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }


        public DataSet searchactordetail(string ac1f, string ac1l) //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select FirstName,LastName,DateofBirth,City,Country,Gender from imdb.Actor where imdb.actor.firstname=@actordetailf and imdb.actor.lastname=@actordetaill", con);  //instantiate SQL command 
                cmd.Parameters.Add("actordetailf", SqlDbType.VarChar, 30).Value = ac1f;
                cmd.Parameters.Add("actordetaill", SqlDbType.VarChar, 30).Value = ac1l;


                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset
        }



        /////////////////////////////////////////^%&$&$^#$%$#$#@@#@$!#@$@!#!$!# pages

        //////page1 iron man 3

        public DataSet getironman3() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='iron man 3'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getironman3data() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='iron man 3' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }




        //////////////////////////
        //////page2 frozen

        public DataSet getfrozen() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='frozen'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getfrozendata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='frozen' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        //////////////////////////
        //////page3 gravity

        public DataSet getgravity() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='gravity'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getgravitydata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='gravity' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        //////////////////////////
        //////page4 man of steel

        public DataSet getmanofsteel() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='man of steel'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getmanofsteeldata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='man of steel' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        //////////////////////////
        //////page5 thor
        public DataSet getthor() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='thor'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getthordata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='thor' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        //////////////////////////
        //////page6 fast and furious 6
        public DataSet getfast6() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Fast & Furios 6'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getfast6data() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Fast & Furios 6' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        //////////////////////////
        //////page7 fast five
        public DataSet getfast5() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Fast Five'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getfast5data() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Fast Five' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        //////////////////////////
        //////page8 The other woman
        public DataSet gettheotherwoman() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='The Other Woman'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet gettheotherwomandata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='The Other Woman' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        //////////////////////////
        //////page9 Guardians of galaxy
        public DataSet getguardiansofgalaxy() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Guardians of Galaxy'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getguardiansofgalaxydata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Guardians of Galaxy' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        //////////////////////////
        //////page10 fast and furious 7
        public DataSet getfast7() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Fast & Furious 7'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getfast7data() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Fast & Furious 7' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        //////////////////////////
        //////page11 Earth to Echo
        public DataSet getearthtoecho() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='EArth to Echo'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getearthtoechodata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='EArth to Echo' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


        /////************************************ Hamza Files************************************************
        public DataSet getdawn() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='DawnofPlanetofApes'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        } //return the dataset

        public DataSet getdawndata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='DawnofPlanetofApes' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }



        //////////////////////////////////Tammy

        public DataSet gettammy() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Tammy'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet gettammydata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Tammy' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        ///////////////////////////////////////////////// Hercules

        public DataSet getHercules() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Hercules'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getHerculesdata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Hercules' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        //////////////////////////////////TheEqualizer
        public DataSet getTheEqualizer() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='The Equalizer'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getTheEqualizerdata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='The Equalizer' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        ///////////////////////////////////Edge of Tomorrow
        public DataSet getEdgeofTomorrow() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (film join Director on Film.Director_ID=Director.Director_ID) join Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Edge of Tomorrow'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getEdgeofTomorrowdata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Actor.FirstName,Actor.LastName,role from Actor join ActedIn on ActedIn.Actor_ID=Actor.Actor_ID join Film on ActedIn.Film_ID=Film.Film_ID where TitleName='Edge of Tomorrow' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        ///////////////////Search party
        public DataSet getSearchparty() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Search Party'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getSearchpartydata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Search Party' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        /////////////////////// into the storm
        public DataSet getIntotheStorm() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Into the Storm'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getIntotheStormdata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Into the Storm' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        /////////////////////Sex Tape
        public DataSet getSexTape() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Sex Tape'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getSexTapedata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Sex Tape' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        ///////////////////////gone girl

        public DataSet getGoneGirl() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Gone Girl'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getGoneGirldata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Gone Girl' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        /////////////////////////Fifty Shades of Grey
        public DataSet getFiftyShadesofGrey() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Fifty Shades of Grey'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getFiftyShadesofGreydata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Fifty Shades of Grey' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }
        /////////////////////////////Kung Fu Panda
        public DataSet getKungFuPanda() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT TitleName,RunningTime,Description,ReleaseDate,Rating,Director.FirstName As Dir_F_Name,Director.LastName As Dir_L_Name,Language,Genre.GenreName FROM (imdb.film join imdb.Director on Film.Director_ID=Director.Director_ID) join imdb.Genre on Film.Genre_ID=Genre.Genre_ID where Film.TitleName='Kung Fu Panda'", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }

        public DataSet getKungFuPandadata() //to get the values of all the items from table Items and return the Dataset
        {
            DataSet ds = new DataSet(); //declare and instantiate new dataset
            SqlConnection con = new SqlConnection(connString); //declare and instantiate new SQL connection
            con.Open(); // open sql Connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select imdb.Actor.FirstName,imdb.Actor.LastName,role from imdb.Actor join imdb.ActedIn on imdb.ActedIn.Actor_ID=imdb.Actor.Actor_ID join imdb.Film on imdb.ActedIn.Film_ID=imdb.Film.Film_ID where TitleName='Kung Fu Panda' ", con);  //instantiate SQL command 
                cmd.CommandType = CommandType.Text; //set type of sqL Command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); //Add the result  set  returned from SQLCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; //return the dataset

        }


    }
}