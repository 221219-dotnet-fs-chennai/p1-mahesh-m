using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.Data.Common;

namespace Datafile
{
    public class SqlRepo : IRepo
    {
        private readonly string?  connectionString;
        private readonly int decipher;
        public SqlRepo() { }

        public SqlRepo(string constr, string deci)
        {
            this.connectionString = constr;
            this.decipher = Convert.ToInt32(deci);
        }

        

       

        public TrainerDetails Insert(TrainerDetails trainer)
        { using SqlConnection conn = new SqlConnection(connectionString);
            String[] arr = trainer.Email.Split("@");
            string userId = arr[0];
            //string city = "Chennai";
         
            conn.Open();
            string query1 = @$"exec sp_insert1 '{userId}','{trainer.FName}','{trainer.LName}','{trainer.Email}','{trainer.PhoneNo}','{trainer.City}','{PasswordHasher(trainer.Password)}','{trainer.Skill1}','{trainer.Skill2}','{trainer.Skill3}','{trainer.Skill4}',   
                                '{trainer.UGCName}','{trainer.UGPYear}','{trainer.UGDegree}','{trainer.UGDept}','{trainer.HSCName}','{trainer.HSCPYear}','{trainer.HSCStream}','{trainer.HSName}','{trainer.HSPYear}'";
            SqlCommand command1 = new SqlCommand(query1, conn);
            command1.ExecuteNonQuery();  
            

            Dictionary<String, String> cm = trainer.GetCompany();

            foreach (var e in cm)
            {
                string query2 = @$"exec sp_insertcompanies '{userId}', '{e.Key}','{e.Value}'";
                SqlCommand command2 = new SqlCommand(query2, conn);
               
                command2.ExecuteNonQuery();
            }
      
            Console.WriteLine("Signup Completed Successfully!");
            Console.WriteLine("Redirecting to Profile Page........");
            Console.WriteLine();
            return trainer;
        }

      public bool Login(string email)
        { 

          
            string query3 = $@"exec sp_login '{email}'";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query3,con);
             SqlDataReader reader=command1.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                Console.WriteLine("Enter password");
                string? password = Console.ReadLine();
                string query4 = $@"exec sp_loginpass '{PasswordHasher(password)}'";
                SqlCommand command2 = new SqlCommand(query4, con);
               using SqlDataReader reader1=command2.ExecuteReader();
                if (reader1.Read())
                {
                    Console.WriteLine("Login Success");
                  
                    return true;
;                }
                else
                {
                    Console.WriteLine("Wrong Password! Try again");
                    Console.ReadLine();
                    reader1.Close();
                    return false;
                }

            }
            else
            {
                Console.WriteLine("account not found! Please sign up first");
                Console.ReadLine();
                return false;
            }


            
        }

        public TrainerDetails GetATrainer(string email)
        { TrainerDetails trainer = new TrainerDetails();
            String[] arr = email.Split("@");
            string userId = arr[0];

            //string query8 = $@"select firstname,lastname,phoneno,city from trainers where trainerid='{userId}'";
            //using SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            //SqlCommand command1 = new SqlCommand(query8, con);
            //SqlDataReader reader1 = command1.ExecuteReader();
            //while (reader1.Read())
            //{
            //    trainer.FName = reader1.GetString(0);
            //    trainer.LName = reader1.GetString(1);
            //    trainer.Email = email;
            //    trainer.PhoneNo = reader1.GetString(2);
            //    trainer.City = reader1.GetString(3);

            //}
            //reader1.Close();

            //string query9 = $@"select skill_1,skill_2,skill_3,skill_4 from skills where trainerid='{userId}'";

            //SqlCommand command2 = new SqlCommand(query9, con);
            //SqlDataReader reader2 = command2.ExecuteReader();
            //while (reader2.Read())
            //{
            //    trainer.Skill1 = reader2.GetString(0);
            //    trainer.Skill2 = reader2.GetString(1);
            //    trainer.Skill3 = reader2.GetString(2);
            //    trainer.Skill4 = reader2.GetString(3);

            //}
            //reader2.Close();

            //string query10 = $@"select collegename,yearpassed,degree,branch from college_ug where trainerid='{userId}'";
            //SqlCommand command3 = new SqlCommand(query10, con);
            //SqlDataReader reader3 = command3.ExecuteReader();
            //while (reader3.Read())
            //{
            //    trainer.UGCName = reader3.GetString(0);
            //    trainer.UGPYear = reader3.GetString(1);
            //    trainer.UGDegree = reader3.GetString(2);
            //    trainer.UGDept = reader3.GetString(3);

            //}
            //reader3.Close();

            //string query11 = $@"select schoolname,yearpassed,course from HighSec where trainerid='{userId}'";
            //SqlCommand command4 = new SqlCommand(query11, con);
            //SqlDataReader reader4 = command4.ExecuteReader();
            //while (reader4.Read())
            //{
            //    trainer.HSCName = reader4.GetString(0);
            //    trainer.HSCPYear = reader4.GetString(1);
            //    trainer.HSCStream = reader4.GetString(2);

            //}
            //reader4.Close();

            //string query12 = $@"select schoolname,yearpassed from HighSchool where trainerid='{userId}'";
            //SqlCommand command5 = new SqlCommand(query12, con);
            //SqlDataReader reader5 = command5.ExecuteReader();
            //while (reader5.Read())
            //{
            //    trainer.HSName = reader5.GetString(0);
            //    trainer.HSPYear = reader5.GetString(1);

            //}
            //reader5.Close();

            //string query13 = $@"select LastcompanyName,totalexp from companies where trainerid='{userId}'";
            //SqlCommand command6 = new SqlCommand(query13, con);
            //SqlDataReader reader6 = command6.ExecuteReader();
            //while (reader6.Read())
            //{
            //    //trainer.LastCompany = reader6.GetString(0);
            //    //trainer.TotalExp = reader6.GetInt32(1);
            //    int xp = reader6.GetInt32(1);

            //    trainer.SetCompany(reader6.GetString(0), xp.ToString());

            //}
            //reader6.Close();

            string query = $@"exec getAtrainer '{userId}'";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                trainer.FName = reader.GetString(1);
                trainer.LName = reader.GetString(2);
                trainer.PhoneNo = reader.GetString(3);
                trainer.Email = reader.GetString(4);
                trainer.Password = reader.GetString(5);
                trainer.City = reader.GetString(6);
                trainer.Skill1 = reader.GetString(8);
                trainer.Skill2 = reader.GetString(9);
                trainer.Skill3 = reader.GetString(10);
                trainer.Skill4 = reader.GetString(11);
                trainer.HSName = reader.GetString(13);
                trainer.HSPYear = reader.GetString(14);
                trainer.HSCName = reader.GetString(16);
                trainer.HSCPYear = reader.GetString(17);
                trainer.HSCStream = reader.GetString(18);
                trainer.UGCName = reader.GetString(20);
                trainer.HSCPYear = reader.GetString(21);
                trainer.UGDegree = reader.GetString(22);
                trainer.UGDept = reader.GetString(23);

               
            }
            reader.Close();

            string query1 = $@"exec gettrainercompany '{userId}'";

            SqlCommand command1 = new SqlCommand(query1, con);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                int xp = reader1.GetInt32(2);
                trainer.SetCompany(reader1.GetString(1),xp.ToString());
            }



            return trainer;

        }

        //public TrainerDetails GetTrainer(string email)
        //{  TrainerDetails trainer= new TrainerDetails();
        //    string query14 = $@"select email from trainers where email='{email}';";
        //    using SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();
        //    SqlCommand command1 = new SqlCommand(query14, con);
        //    SqlDataReader reader = command1.ExecuteReader();
        //    return  trainer;

        //}



        public string PasswordHasher(string password)
        {
            string newPassword = "";
            char[] pass = password.ToCharArray();
            foreach(char a in pass)
            {
                int asci = (int)a;
                int newAsci = asci + decipher;
                newPassword = newPassword + "" + (char)newAsci;
            }

            return newPassword;

        }

        public void UpdateATrainer(string ? newValue, string columnName, string tableName,string trainerId)
        {

            //string query15 = $@"update {tableName} set {columnName}='{newValue}' where trainerid='{trainerId}'";




            //using SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            //SqlCommand command1 = new SqlCommand(query15,con);
            //command1.ExecuteNonQuery();
            string query="null";
            switch (tableName)
            {
                case "trainers":
                    query = $@"exec updateTrainers '{trainerId}','{columnName}','{newValue}' ";
                    break;
                case "college_ug":
                     query = $@"exec updatecollege '{trainerId}','{columnName}','{newValue}' ";
                    break;
                case "highschool":
                    query = $@"exec updatehs '{trainerId}','{columnName}','{newValue}' ";
                    break;
                case "highsec":
                    query = $@"exec updatehsc '{trainerId}','{columnName}','{newValue}' ";
                    break;
                case "Skills":
                    query = $@"exec updateskills '{trainerId}','{columnName}','{newValue}' ";
                    break;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    break;


            }
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
                SqlCommand command1 = new SqlCommand(query, con);
                if (newValue == "")
                {
                    Console.WriteLine("Value Deleted successfully!");
                }
                else {
                    Console.WriteLine("Value updated successfully!");
                }
                
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        //public void DeleteValues(string columnName, string tableName, string trainerId)
        //{ string query16= $@"update {tableName} set {columnName}='' where trainerid='{trainerId}'";
        //    using SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();
        //    SqlCommand command1 = new SqlCommand(query16, con);
        //    command1.ExecuteNonQuery();
        //    Console.WriteLine("Value Deleted successfully!");
        //    Console.ReadLine();
        //}

        public void DeleteAccount(string trainerId)
        {
            string query1 = $@"exec sp_deleteacc {trainerId}";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1, con);
            command1.ExecuteNonQuery();
            Console.WriteLine("Find Trainers Will miss you!!");
            Console.WriteLine("ACCOUNT DELETION COMPLETED SUCCESSFULLY");
            Console.WriteLine();
            Console.ReadLine();


        }

        public List<TrainerDetails> GetAll()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            List<TrainerDetails> listTrainer = new List<TrainerDetails>();
            string query17 = $@"select firstname,lastname,phoneNo,email,skill_1,city from trainers t inner join skills s on t.TrainerId=s.TrainerId ";
          
            SqlCommand command1 = new SqlCommand(query17, con);
            SqlDataReader reader1 = command1.ExecuteReader();

            string tr = "";
            while (reader1.Read())
            {
                listTrainer.Add(new TrainerDetails()
                {
                    FName = reader1.GetString(0),
                    LName = reader1.GetString(1),
                    PhoneNo = reader1.GetString(2),
                    Email = reader1.GetString(3),
                    Skill1 = reader1.GetString(4),
                    City= reader1.GetString(5),

                });

            }
            reader1.Close();    

            return listTrainer;
        }

        public void UpdateCompanies(string newC, string newExp,string userId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string query18 = @$"exec sp_updatecompanies '{userId}','{newC}','{newExp}'";
            SqlCommand command1 = new SqlCommand(query18, con);
            
            command1.ExecuteNonQuery();
            Console.WriteLine("Updated Successfully");
            Console.ReadLine();
        }

        public void DeleteCompanies(string userId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();




            string query19 = @$"delete from companies where trainerid='{userId}'";
            SqlCommand command1 = new SqlCommand(query19, con);
            command1.ExecuteNonQuery();
            Console.WriteLine("Deleted successfully");


        }

        public bool IsExist(string value,string column)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query20 = @$"select email from trainers where {column}='{value}'";
            SqlCommand cmd =new SqlCommand(query20,con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
            


           
        }

        public void NewPass(string pass,string email)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query21 = @$"update trainers set password='{PasswordHasher(pass)}' where email='{email}'";
            SqlCommand cmd = new SqlCommand(query21, con);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Password Changed Successfully");
            

        }

        public void DeleteSingleCompany(string cnmae, string userid)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query1 = @$"exec sp_deleteCompany '{userid}','{cnmae}'";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();

        }


    }
}
