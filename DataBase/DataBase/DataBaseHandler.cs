using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml;

namespace DataBase
{
	public partial class DataBaseHandler
	{
		/*	@param userName - from login
		 *  @param password - from login
		 *  @return UserData - the data of the user with succesful login or null
		 */ 
		public UserData VerifyLogin (String userName, String password) 
		{
			OpenConnection ();
			string query = "SELECT * FROM users WHERE DisplayName LIKE '" +  userName
			                + "' AND PasswordHash LIKE '" + password + "';";
			
			MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
			DataSet ds = new DataSet ();
			dataAdapter.Fill (ds, "users");
			CloseConnection ();

			if (ds.Tables ["users"].Rows.Count == 0) {
				return null;
			}

			UserData user = new UserData ();
			// foreach is not really necessary, because the querry can only return 1 row
			// but I decided to keep it anyway, might make it a bit readable.
			foreach (DataRow row in ds.Tables["users"].Rows) {
				user.FillFromDataRow (row);
			}

			return user;
		} // End of VerifyLogin()


		/*	@return List<ProjectData> - returns all the availiable projects
		 */ 
		public List<ProjectData> GetActiveProjectsList ()
		{
			try {
				List<ProjectData> returnList = new List<ProjectData> ();

				OpenConnection ();
				string query = "SELECT * FROM projects;";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "projects");
				CloseConnection ();

				if (ds.Tables ["projects"].Rows.Count == 0) {
					return null;
				}

				foreach (DataRow row in ds.Tables["projects"].Rows) {
					ProjectData project = new ProjectData();
					project.FillFromDataRow (row);
					returnList.Add(project);
				}

				return returnList;
			}
			catch(Exception e) {
				Console.WriteLine (e.ToString());
				return null;
			}
		} // End of GetActiveProjectsList()

		//TODO Maybie I should check if there already exists a project with the same name?
		/*
		 * @param newProject - inserts into the database all the properties from newProject
		 * @return bool - true if succes, false if failure
		 */ 
		public bool InsertNewProject (ProjectData newProject) 
		{
			try {
				OpenConnection ();
				string query = "INSERT INTO projects (Title, ShortDescription, DetailedDescription, "
					+ "CreatedBy, ProjectLead, DateCreated, ModificationLogLink, Notes, AvailableFunds, "
					+ "CurrentYield, DateTerminated, TerminationReason, TerminatedBy, CollectedFunds, "
					+ "ConsumedFunds) VALUES " + newProject.ToQueryString() + ";";
				MySqlCommand command = new MySqlCommand (query, connection);
	
				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of InsertNewProject()

		//TODO Maybie I should check if there already exists a project with the same name?
		/*
		 * @param newTask - inserts into the database all the properties from newTask
		 * @return bool - true if succes, false if failure
		 */ 
		public bool InsertNewTask (TaskData newTask)
		{
			try {
				OpenConnection ();
				string query = "INSERT INTO tasks (ParentId, Title, ShortDescription, "
					+ "DetailedDescription, ParentProject, DateCreated, CreatedBy, "
					+ "DateCompleted, CompletedBy, DeadLine, Status) "
					+ "VALUES " + newTask.ToQueryString() + ";";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of InsertNewTask()

		/*
		 * @param user - the user that maked the requests
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */ 
		public bool ProjectJoinRequest (UserData user, ProjectData project)
		{
			try {
				OpenConnection ();
				string query = "INSERT INTO projectrequests (user_id, project_id) "
					+ "VALUES  ('" + user.ID.ToString() + "', '" + project.ID.ToString() + "');";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of ProjectJoinRequests()

		/*
		 * @param user - the user that maked the requests
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */ 
		public bool TaskRequest (UserData user, TaskData task)
		{
			try {
				OpenConnection ();
				string query = "INSERT INTO taskrequests (user_id, task_id) "
					+ "VALUES  ('" + user.ID.ToString() + "', '" + task.ID.ToString() + "');";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of TaskRequest()

		/* Can Update only:
		 * Title, ShortDescription, DetailedDescription, Notes, AvailableFunds
		 * @param project - update project from table
		 * @return bool - true if succes, false if failure
		 */ 
		public bool UpdateProject (ProjectData project)
		{
			try {
				OpenConnection ();
				string query = "UPDATE projects SET Title = @Title, ShortDescription = @ShortDescription, "
					+ "DetailedDescription = @DetailedDescription, Notes = @Notes, AvailableFunds = @AvailableFunds, "
					+ "CurrentYield = @CurrentYield, "
					+ " WHERE Id = @project_id;";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.Parameters.AddWithValue("@Title", project.Title);
				command.Parameters.AddWithValue("@ShortDescription", project.ShortDescription);
				command.Parameters.AddWithValue("@DetailedDescription", project.DetailedDescription);
				command.Parameters.AddWithValue("@Notes", project.Notes);
				command.Parameters.AddWithValue("@AvailableFunds", project.AvailibleFunds);
				command.Parameters.AddWithValue("@CurrentYield", project.CurrentYield);
				command.Parameters.AddWithValue("@user_id", project.ID);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of UpdateProject()

		/* Can Update only:
		 * DisplayName, AvatarLink, Email, PasswordHash, PhoneNumber, WorkStatus, PersonalNotes, ActiveProject, ActiveTask
		 * @param user - update user from table
		 * @return bool - true if succes, false if failure
		 */ 
		public bool UpdateUser (UserData user)
		{
			try {
				OpenConnection ();
				string query = "UPDATE users SET DisplayName = @DisplayName, AvatarLink = @AvatarLink, "
					+ "Email = @Email, PasswordHash = @PasswordHash, PhoneNumber = @PhoneNumber, "
					+ "ActiveProject = @ActiveProject, ActiveTask = @ActiveTask,"
					+ "WorkStatus = @WorkStatus, PersonalNotes = @PersonalNotes WHERE Id = @user_id;";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.Parameters.AddWithValue("@DisplayName", user.DisplayName);
				command.Parameters.AddWithValue("@AvatarLink", user.AvatarURL);
				command.Parameters.AddWithValue("@Email", user.Email);
				command.Parameters.AddWithValue("@PasswordHash", user.Password);
				command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
				command.Parameters.AddWithValue("@ActiveProject", user.ActiveProject);
				command.Parameters.AddWithValue("@ActiveTask", user.ActiveTask);
				command.Parameters.AddWithValue("@WorkStatus", user.WorkStatus);
				command.Parameters.AddWithValue("@PersonalNotes", user.PersonalNotes);
				command.Parameters.AddWithValue("@user_id", user.ID);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
				return false;
			}
		} // End of UpdateUser

		/*
		 * @param project - get all the users requesting for project
		 * @return List<UserData> - all the users
		 */ 
		public List<UserData> GetAllUsersRequestingForProject (ProjectData project)
		{
			try {
				OpenConnection ();
				string query = "SELECT * FROM users, projectrequests "
			    	           + "WHERE users.Id = projectrequests.user_id AND projectrequests.project_Id = " + project.ID + ";";
					
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "users");
				CloseConnection ();
					
				if (ds.Tables ["users"].Rows.Count == 0) {
					return null;
				}
					
				List<UserData> userList = new List<UserData> ();
				foreach (DataRow row in ds.Tables["users"].Rows) {
					UserData user = new UserData ();
					user.FillFromDataRow (row);
					userList.Add (user);
				}

				return userList;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString());
				return null;
			}
		} // End of GetAllUserRequestingForProject()

		/*
		 * @param user - the user that will be refreshed
		 * @return bool - all the users
		 * Also! the user data is changed
		 */ 
		public bool RefreshUser (UserData user)
		{
			try {
				OpenConnection ();
				string query = "SELECT * FROM users WHERE Id = " + user.ID + ";";
					
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "users");
				CloseConnection ();
					
				if (ds.Tables ["users"].Rows.Count == 0) {
					return false;
				}
					
				foreach (DataRow row in ds.Tables["users"].Rows) {
					user.FillFromDataRow (row);
				}
					
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of RefreshUser()

		public bool DropTask (UserData user)
		{
			try {
				OpenConnection ();
				string query = "SELECT * FROM users WHERE Id = " + user.ID + ";";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "users");
				CloseConnection ();

				if (ds.Tables ["users"].Rows.Count == 0) {
					return false;
				}

				foreach (DataRow row in ds.Tables["users"].Rows) {
					user.FillFromDataRow (row);
				}

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of DropTask

		//public ProjectData AdoptProjectSuggestion (UserData user, ProjectSuggestionData projectSuggestion)
		//public bool AcceptUserProjectRequest (UserData user, ProjectData project)
		//public bool GrantTask (TaskData task, UserData user)
		//public bool RemoveTask (TaskData task)
		//public bool UpdateProjectList (List<ProjectData> projectList)
	} // End of Partial Class

	public partial class DataBaseHandler
	{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		// Create connectionstring and connection
		public DataBaseHandler ()
		{
			server = "localhost";
			database = "test";
			uid = "root";
			password = "root";

			string connectionString = 
				"SERVER=" + server + ";"
				+ "DATABASE= " + database + ";"
				+ "UID=" + uid + ";"
				+ "PASSWORD=" + password + ";";

			connection = new MySqlConnection (connectionString);
		} // End of Constructor

		// TODO should change console messages to MessageBox
		private bool OpenConnection ()
		{
			try {
				connection.Open ();
				return true;
			} catch (MySqlException ex) {
				switch (ex.Number) {
				case 0:
					Console.WriteLine ("Cannot connect to server.  Contact administrator");
					break;

				case 1045:
					Console.WriteLine ("Invalid username/password, please try again");
					break;
				}
				return false;
			}
		} // End of OpenConnection()

		// TODO should change console messages to MessageBox
		private bool CloseConnection ()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		} // End of CloseConnection
	} // End of Partial Class
}

