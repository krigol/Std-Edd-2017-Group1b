using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssignmentManager.Repositories
{
    public class AssignmentRepository
    {
        private string dbConnectionString;

        public AssignmentRepository(string connectionString)
        {
            dbConnectionString = connectionString;
        }

        public List<Assignment> GetAll()
        {
            IDbConnection connection = new SqlConnection(dbConnectionString);

            connection.Open();

            List<Assignment> assignments = new List<Assignment>();

            try
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = 
@"
SELECT * 
FROM Assignments
";
                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Assignment assignment = new Assignment();
                        assignment.Id = (int)reader["Id"];
                        assignment.Title = (string)reader["Title"];
                        assignment.Description = reader["Description"].ToString();
                        assignment.IsDone = (bool)reader["IsDone"];

                        assignments.Add(assignment);
                    }   
                }
            }
            finally
            {

                connection.Close();
            }

            return assignments;
        }

        public void Insert(Assignment entity)
        {
            IDbConnection connection = new SqlConnection(dbConnectionString);

            using (connection)
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
@"
INSERT INTO Assignments(Title, Description, IsDone)
VALUES (@Title,@Description,@IsDone)
";
                IDataParameter titleParameter = command.CreateParameter();
                titleParameter.ParameterName = "@Title";
                titleParameter.Value = entity.Title;
                command.Parameters.Add(titleParameter);

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@Description";
                descriptionParameter.Value = entity.Description;
                command.Parameters.Add(descriptionParameter);

                var isDoneParameter = command.CreateParameter();
                isDoneParameter.ParameterName = "@IsDone";
                isDoneParameter.Value = entity.IsDone;
                command.Parameters.Add(isDoneParameter);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(dbConnectionString);

            using (connection)
            {
                var command = connection.CreateCommand();
                command.CommandText = 
@"
DELETE 
FROM Assignments
WHERE Id=@Id
";
                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@Id";
                idParameter.Value = id;
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
    }
}