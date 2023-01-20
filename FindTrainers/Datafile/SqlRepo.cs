﻿using System;
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
            string query1 = @"insert into Trainers (TrainerId,firstname,lastname,phoneNo,email,password,city) values(@userid,@fname,@lname,@phoneNo,@email,@password,@city)";
            conn.Open();
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@fname", trainer.FName);
            command.Parameters.AddWithValue("@lname", trainer.LName);
            command.Parameters.AddWithValue("@phoneNo",trainer.PhoneNo);
            command.Parameters.AddWithValue("@email", trainer.Email);
            command.Parameters.AddWithValue("@password", PasswordHasher(trainer.Password));
            command.Parameters.AddWithValue("@city", trainer.City);
            command.ExecuteNonQuery();



            string query2 = @"insert into skills (TrainerId,skill_1,skill_2,skill_3,skill_4) values(@userId,@skill_1,@skill_2,@skill_3,@skill_4)";
            SqlCommand command1 = new SqlCommand(query2, conn);

            command1.Parameters.AddWithValue("@userId", userId);
            command1.Parameters.AddWithValue("@skill_1", trainer.Skill1);
            command1.Parameters.AddWithValue("@skill_2", trainer.Skill2);
            command1.Parameters.AddWithValue("@skill_3", trainer.Skill3);
            command1.Parameters.AddWithValue("@skill_4", trainer.Skill4);
            command1.ExecuteNonQuery();


            string query3 = @"insert into college_ug (TrainerId,CollegeName,yearpassed,degree,branch) values(@userId,@collegename,@yearpassed,@degree,@branch)";
            SqlCommand command2 = new SqlCommand(query3, conn);
            command2.Parameters.AddWithValue("@userId", userId);
            command2.Parameters.AddWithValue("@collegename", trainer.UGCName);
            command2.Parameters.AddWithValue("@yearpassed", trainer.UGPYear);
            command2.Parameters.AddWithValue("@degree", trainer.UGDept);
            command2.Parameters.AddWithValue("@branch", trainer.UGDept);
            command2.ExecuteNonQuery();


            string query4 = @"insert into HighSec (trainerid,SchoolName,yearpassed,course) values(@userId,@schoolname,@yearpassed,@course)";
            SqlCommand command3 = new SqlCommand(query4, conn);
            command3.Parameters.AddWithValue("@userId", userId);
            command3.Parameters.AddWithValue("@schoolname", trainer.HSCName);
            command3.Parameters.AddWithValue("@yearpassed", trainer.HSCPYear);
            command3.Parameters.AddWithValue("@course", trainer.HSCStream);
            command3.ExecuteNonQuery();



            string query5 = @"insert into HighSchool (trainerid,SchoolName,yearpassed) values(@userid,@schoolname,@yearpassed)";
            SqlCommand command4 = new SqlCommand(query5, conn);
            command4.Parameters.AddWithValue("@userId", userId);
            command4.Parameters.AddWithValue("@schoolname", trainer.HSName);
            command4.Parameters.AddWithValue("@yearpassed", trainer.HSPYear);
            command4.ExecuteNonQuery();

            Dictionary<String, String> cm = trainer.GetCompany();

            foreach (var e in cm)
            {
                string query6 = @"insert into companies(trainerid,lastcompanyName,totalexp) values (@userId,@lastcompanyname,@totalexp)";
                SqlCommand command5 = new SqlCommand(query6, conn);
                command5.Parameters.AddWithValue("@userId", userId);
                command5.Parameters.AddWithValue("@lastcompanyname", e.Key);
                command5.Parameters.AddWithValue("@totalexp", e.Value);
                command5.ExecuteNonQuery();

            }
      
            Console.WriteLine("Signup Completed Successfully!");
            Console.WriteLine("Redirecting to Profile Page........");
            Console.WriteLine();
            return trainer;
        }

      public bool Login(string email)
        { 

          
            string query1 = $@"select email from trainers where email='{email}';";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1,con);
             SqlDataReader reader=command1.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                Console.WriteLine("Enter password");
                string? password = Console.ReadLine();
                string query2 = $@"select email from trainers where password='{PasswordHasher(password)}';";
                SqlCommand command2 = new SqlCommand(query2, con);
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
          
            string query1 = $@"select firstname,lastname,phoneno,city from trainers where trainerid='{userId}'";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1,con);
            SqlDataReader reader1= command1.ExecuteReader();
            while (reader1.Read())
            {
                trainer.FName = reader1.GetString(0);
                trainer.LName = reader1.GetString(1);
                trainer.Email = email;
                trainer.PhoneNo= reader1.GetString(2);
                trainer.City= reader1.GetString(3);
                
            }
            reader1.Close();

            string query2 = $@"select skill_1,skill_2,skill_3,skill_4 from skills where trainerid='{userId}'";

            SqlCommand command2 = new SqlCommand(query2, con);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                trainer.Skill1 = reader2.GetString(0);
                trainer.Skill2 = reader2.GetString(1);
                trainer.Skill3 = reader2.GetString(2);
                trainer.Skill4 = reader2.GetString(3);
                
            }
            reader2.Close();

            string query3 = $@"select collegename,yearpassed,degree,branch from college_ug where trainerid='{userId}'";
            SqlCommand command3 = new SqlCommand(query3, con);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                trainer.UGCName = reader3.GetString(0);
                trainer.UGPYear = reader3.GetString(1);
                trainer.UGDegree = reader3.GetString(2);
                trainer.UGDept = reader3.GetString(3);
                
            }
            reader3.Close();

            string query4 = $@"select schoolname,yearpassed,course from HighSec where trainerid='{userId}'";
            SqlCommand command4 = new SqlCommand(query4, con);
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                trainer.HSCName = reader4.GetString(0);
                trainer.HSCPYear = reader4.GetString(1);
                trainer.HSCStream = reader4.GetString(2);
                
            }
            reader4.Close();

            string query5 = $@"select schoolname,yearpassed from HighSchool where trainerid='{userId}'";
            SqlCommand command5 = new SqlCommand(query5, con);
            SqlDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                trainer.HSName = reader5.GetString(0);
                trainer.HSPYear = reader5.GetString(1);
                
            }
            reader5.Close();

            string query6 = $@"select LastcompanyName,totalexp from companies where trainerid='{userId}'";
            SqlCommand command6 = new SqlCommand(query6, con);
            SqlDataReader reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                //trainer.LastCompany = reader6.GetString(0);
                //trainer.TotalExp = reader6.GetInt32(1);
                int xp = reader6.GetInt32(1);
         
                trainer.SetCompany(reader6.GetString(0),xp.ToString());
                
            }
            reader6.Close();


            return trainer;

        }

        public TrainerDetails GetTrainer(string email)
        {  TrainerDetails trainer= new TrainerDetails();
            string query1 = $@"select email from trainers where email='{email}';";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1, con);
            SqlDataReader reader = command1.ExecuteReader();
            return  trainer;

        }



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

            string query1 = $@"update {tableName} set {columnName}='{newValue}' where trainerid='{trainerId}'";

            

           
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1,con);
            command1.ExecuteNonQuery();
            Console.WriteLine("Value update successfully!");
            Console.ReadLine();

        }


        public void DeleteValues(string columnName, string tableName, string trainerId)
        { string query1= $@"update {tableName} set {columnName}='' where trainerid='{trainerId}'";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query1, con);
            command1.ExecuteNonQuery();
            Console.WriteLine("Value Deleted successfully!");
            Console.ReadLine();
        }

        public void DeleteAccount(string trainerId)
        {
            string query1 = $@"delete from trainers where trainerid='{trainerId}'";
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
            string query1 = $@"select firstname,lastname,phoneNo,email,skill_1,city from trainers t inner join skills s on t.TrainerId=s.TrainerId ";
          
            SqlCommand command1 = new SqlCommand(query1, con);
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


            string query1 = @"insert into companies(trainerid,lastcompanyName,totalexp) values (@userId,@lastcompanyname,@totalexp)";
            SqlCommand command1 = new SqlCommand(query1, con);
            command1.Parameters.AddWithValue("@userId", userId);
            command1.Parameters.AddWithValue("@lastcompanyname", newC);
            command1.Parameters.AddWithValue("@totalexp", newExp);
            command1.ExecuteNonQuery();
            Console.WriteLine("Updated Successfully");
            Console.ReadLine();
        }

        public void DeleteCompanies(string userId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();




            string query = @$"delete from companies where trainerid='{userId}'";
            SqlCommand command1 = new SqlCommand(query, con);
            command1.ExecuteNonQuery();
            Console.WriteLine("Deleted successfully");


        }

        public bool IsExist(string value,string column)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query1 = @$"select email from trainers where {column}='{value}'";
            SqlCommand cmd =new SqlCommand(query1,con);
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
            string query1 = @$"update trainers set password='{PasswordHasher(pass)}' where email='{email}'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Password Changed Successfully");
            

        }

        //public void DeleteSingleCompany(string cnmae,string userid)
        //{
        //    using SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();
        //    string query1 = @$"delete from companies where lastcompanyname='{cnmae}' and trainerid='{userid}'";
        //    SqlCommand cmd = new SqlCommand(query1, con);
        //    cmd.ExecuteNonQuery();

        //}

       
    }
}
