using System;
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
            command.Parameters.AddWithValue("@password", trainer.Password);
            command.Parameters.AddWithValue("@city", city);
            int rows=command.ExecuteNonQuery();
            Console.Write(rows + " " + "affected");
            return trainer;
        }
    }
}
