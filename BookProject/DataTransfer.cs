using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

public class DataTransfer
{

	public static DataTable ConvertCSVtoDataTable(string strFilePath)
	{
		Console.Write(strFilePath);
		DataTable dt = new DataTable();
		using (var sr = new System.IO.StreamReader(strFilePath))
		{

			string[] headers = sr.ReadLine().Split(',');

			foreach (string header in headers)
			{
				dt.Columns.Add(header);
			}
			while (!sr.EndOfStream)
			{
				string[] rows = sr.ReadLine().Split(',');
				DataRow dr = dt.NewRow();
				for (int i = 0; i < headers.Length; i++)
				{
					dr[i] = rows[i];
				}
				dt.Rows.Add(dr);
				
			}

		}

		return dt;
	}

	public static string file = @"C:\Users\rmysg\source\repos\BookProject\BookProject\bookDataset.csv";

	static void Main(string[] args)
	{
		DataTable dt = new DataTable();
		using (var sr = new System.IO.StreamReader(file))
		{

			string[] headers = sr.ReadLine().Split(',');

			foreach (string header in headers)
			{
				dt.Columns.Add(header);
			}
			while (!sr.EndOfStream)
			{
				string[] rows = sr.ReadLine().Split(',');
				DataRow dr = dt.NewRow();
				for (int i = 0; i < headers.Length; i++)
				{
					dr[i] = rows[i];
				}
				dt.Rows.Add(dr);

			}

		}

		//creating object of class Program
		Console.WriteLine("askdfdsf");
		Console.WriteLine("qwrewqrewr");
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			try
			{
				SqlConnection conn = new SqlConnection(@"Server=RUMEYSA; Database=bookProject; Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
				conn.Open();
				string insert_query = "insert into Books (Title,Author,Publisher,Description,PublishTime, Price) values (@Title ,@Author ,@Author,@Description, @PublishTime ,@Price)";
				SqlCommand cmd = new SqlCommand(insert_query, conn);
				cmd.Parameters.AddWithValue("@Title", dt.Rows[i]["title"].ToString());
				cmd.Parameters.AddWithValue("@Author", dt.Rows[i]["author"].ToString());
				cmd.Parameters.AddWithValue("@Publisher", dt.Rows[i]["publisher"].ToString());
				cmd.Parameters.AddWithValue("@Description","test");
				cmd.Parameters.AddWithValue("@PublishTime", "2010-01-01 12:00");
				cmd.Parameters.AddWithValue("@Price", dt.Rows[i]["price"]);

				cmd.ExecuteNonQuery();
				Console.WriteLine("Registration Is Successfully");
				conn.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERORR:" + ex.ToString());

			}
		}
	}

}
	

	//private static void WriteToDb(DataTable dt)
	//{
	//	string connectionString =
	//		"Data Source=localhost;" +
	//		"Initial Catalog=Northwind;" +
	//		"Integrated Security=SSPI;";

	//	using (SqlConnection con = new SqlConnection(connectionString))
	//	{
	//		using (SqlCommand cmd = new SqlCommand("spInsertTest", con))
	//		{
	//			cmd.CommandType = CommandType.StoredProcedure;

	//			cmd.Parameters.Add("@policyID", SqlDbType.Int).Value = 12;
	//			cmd.Parameters.Add("@statecode", SqlDbType.VarChar).Value = "blagh2";
	//			cmd.Parameters.Add("@county", SqlDbType.VarChar).Value = "blagh3";

	//			con.Open();
	//			cmd.ExecuteNonQuery();
	//		}
	//	}

	//}


