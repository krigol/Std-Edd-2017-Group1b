using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccess.Repositories
{
    public class CommentRepository
    {
        private string dbConnectionString;

        public CommentRepository(string connectionString)
        {
            dbConnectionString = connectionString;
        }

        public List<Comment> GetAll(int assignmentId)
        {
            IDbConnection connection = new SqlConnection(dbConnectionString);

            connection.Open();

            List<Comment> comments = new List<Comment>();

            try
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
@"
SELECT * 
FROM Comments
WHERE AssignmentId = @AssignmentId
";
                var assignmentIdParam = command.CreateParameter();
                assignmentIdParam.ParameterName = "@AssignmentId";
                assignmentIdParam.Value = assignmentId;
                command.Parameters.Add(assignmentIdParam);

                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.Id = (int)reader["Id"];
                        comment.Content = (string)reader["Content"];
                        comment.AssignmentId = (int)reader["AssignmentId"];

                        comments.Add(comment);
                    }
                }
            }
            finally
            {

                connection.Close();
            }

            return comments;
        }

        public void Insert(Comment entity)
        {
            IDbConnection connection = new SqlConnection(dbConnectionString);

            try 
	        {
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
@"
INSERT INTO Comments(AssignmentId, Content)
VALUES (@AssignmentId,@Content)
";
                IDataParameter assignmentIdParam = command.CreateParameter();
                assignmentIdParam.ParameterName = "@AssignmentId";
                assignmentIdParam.Value = entity.AssignmentId;
                command.Parameters.Add(assignmentIdParam);

                var contentParameter = command.CreateParameter();
                contentParameter.ParameterName = "@Content";
                contentParameter.Value = entity.Content;
                command.Parameters.Add(contentParameter);

                command.ExecuteNonQuery();
	        }
	        finally
	        {
                connection.Close();
	        }               
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(dbConnectionString);
            connection.Open();

            try 
            {
                var command = connection.CreateCommand();
                command.CommandText =
@"
DELETE 
FROM Comments
WHERE Id=@Id
";
                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@Id";
                idParameter.Value = id;
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(Comment entity)
        {
            var connection = new SqlConnection(dbConnectionString);

            connection.Open();

            try
            {
                var command = connection.CreateCommand();

                command.CommandText =
@"
UPDATE Comments
SET Content = @Content,
WHERE Id = @Id
";
                var contentParam = command.CreateParameter();
                contentParam.ParameterName = "@Content";
                contentParam.Value = entity.Content;

                var idParam = command.CreateParameter();
                idParam.ParameterName = "@Id";
                idParam.Value = entity.Id;
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public Comment GetById(int id)
        {
            var connection = new SqlConnection(dbConnectionString);

            connection.Open();
            Comment comment = new Comment();

            try
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText =
@"
SELECT * 
FROM Comments
WHERE Id = @Id
";
                var idParam = command.CreateParameter();
                idParam.ParameterName = "@Id";
                idParam.Value = id;
                command.Parameters.Add(idParam);

                IDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    reader.Read();

                    comment.Id = (int)reader["Id"];
                    comment.Content = (string)reader["Content"];
                    comment.AssignmentId = (int)reader["AssignmentId"];

                }
            }
            finally
            {
                connection.Close();
            }

            return comment;
        }
    }
}