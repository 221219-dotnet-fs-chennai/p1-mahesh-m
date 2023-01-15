﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datafile
{
    public class SqlRepo : IRepo
    {
        private readonly string connectionString = "Server=OCTOTHORPE;Database=TrainerDetails;Trusted_Connection=True;";

        public TrainerDetails Insert(TrainerDetails trainer)
        { using SqlConnection conn = new SqlConnection(connectionString);
            String[] arr = trainer.Email.Split("@");
            string userId = arr[0];
            string city = "Chennai";
            string query1 = @"insert into Trainers (TrainerId,firstname,lastname,phoneNo,email,password,city) values(@userid,@fname,@lname,@phoneNo,@email,@password,@city)";
            conn.Open();
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@fname", trainer.FName);
            command.Parameters.AddWithValue("@lname", trainer.LName);
            command.Parameters.AddWithValue("@phoneNo",trainer.PhoneNo);
            command.Parameters.AddWithValue("@email", trainer.Email);
            command.Parameters.AddWithValue("@password", PasswordHasher(trainer.Password));
            command.Parameters.AddWithValue("@city", city);
            int rows=command.ExecuteNonQuery();


            string query2 = @"insert into skills (TrainerId,skill_1,skill_2,skill_3,skill_4) values(@userId,@skill_1,@skill_2,@skill_3,@skill_4)";
            SqlCommand command1= new SqlCommand(query2, conn);

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

            string query6 = @"insert into companies(trainerid,lastcompanyName,totalexp) values (@userId,@lastcompanyname,@totalexp)";
            SqlCommand command5= new SqlCommand(query6, conn);
            command5.Parameters.AddWithValue("@userId", userId);
            command5.Parameters.AddWithValue("@lastcompanyname", trainer.LastCompany);
            command5.Parameters.AddWithValue("@totalexp", trainer.TotalExp);
            command5.ExecuteNonQuery();




            Console.Write("Signup Completed Successfully!");
            Console.WriteLine("Redirecting to Home Page........");
            Console.WriteLine();
            return trainer;
        }

        public string PasswordHasher(string password)
        {
            int decipher = 9;
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
    }
}
