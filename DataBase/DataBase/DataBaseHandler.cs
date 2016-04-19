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
				string query = "SELECT * FROM projects WHERE TerminatedBy = " + DBDefaults.DefaultId + ";";

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
		 * @return bool - succes
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

		/*
		 * @param project - the project that will be refreshed
		 * @return bool - succes
		 * Also! the project data is changed
		 */ 
		public bool RefreshProject (ProjectData project)
		{
			try {
				OpenConnection ();
				string query = "SELECT * FROM projects WHERE Id = " + project.ID + ";";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "projects");
				CloseConnection ();

				if (ds.Tables ["projects"].Rows.Count == 0) {
					return false;
				}

				foreach (DataRow row in ds.Tables["projects"].Rows) {
					project.FillFromDataRow (row);
				}

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of RefreshProject()

		/*
		 * @param user - user that is to be modified
		 * You could aslo do this manually, but eh. Database can handle it
		 * Nice and short
		 */ 
		public bool DropTask (UserData user)
		{
			try {
				user.ActiveTask = DBDefaults.DefaultId;
				return this.UpdateUser (user); // TODO check if this thing works
			}
			catch (Exception e)
			{
				Console.WriteLine (e.ToString ());
				return false;
			}

		} // End of DropTask

		/*
		 * @param user - the user that wants to adopt the projectsuggestion
		 * @param projectSuggestion - the one that will be adopted? adoptend? ...
		 * @return ProjecData - after creating the project and database and whatevs
		 */ 
		public ProjectData AdoptProjectSuggestion (UserData user, ProjectSuggestionData projectSuggestion)
		{
			try {
				// Check if user has active task
				this.RefreshUser (user);
				if (user.ActiveProject != DBDefaults.DefaultId) {
					return null;
				}

				// Fetch the data from the projectSuggestion and put it into the new project
				ProjectData newProject = new ProjectData (user.ID);
				newProject.Title = projectSuggestion.Title;
				newProject.ShortDescription = projectSuggestion.ShortDescription;
				newProject.DetailedDescription = projectSuggestion.DetailedDescription;
				newProject.CreatedBy = projectSuggestion.CreatedBy;
				newProject.ProjectLead = user.ID;
				newProject.DateCreated = DateTime.Now;
				newProject.Notes = projectSuggestion.Notes;
				this.InsertNewProject (newProject);

				// HACK I know, I know, It was the deadline's fault!
				List<ProjectData> listOfAllProjects = this.GetActiveProjectsList();
				foreach (ProjectData p in listOfAllProjects) {
					if (p.ProjectLead == newProject.ProjectLead) {
						newProject = new ProjectData(p); // Rebuild with variables from p (for ID reasons)
						break;
					}
				}

				// Add active task to user
				user.ActiveProject = newProject.ID;
				this.UpdateUser (user);

				// Delete SuggestedProject
				this.RemoveProjectSuggestion (projectSuggestion);
				projectSuggestion = null;

				return newProject;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return null;
			}
		} // End of AdoptProjectSuggestions ()


		/*
		 * This function may be unnecessary. Who will even check this code?
		 * @param task - that task that will be deleted
		 */ 
		public bool RemoveTask (TaskData task)
		{
			try {
				OpenConnection ();
				string query = "DELETE FROM task WHERE  Id = " + task.ID + ";";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of RemoveTask

		/*
		 * @param pj - that projectSuggestion that will be deleted
		 */ 
		public bool RemoveProjectSuggestion (ProjectSuggestionData pj)
		{
			try {
				OpenConnection ();
				string query = "DELETE FROM projectSuggestions WHERE  Id = " + pj.ID + ";";
				MySqlCommand command = new MySqlCommand (query, connection);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection ();
				return true;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of RemoveTask

		/*  WARNING LAMBDAS AHEAD!! HIDE YOUR CHILDREN!
		 * @param user - 
		 */ 
		public bool AcceptUserProjectRequest (UserData user, ProjectData project)
		{
			try {
				// Check if user requested joining the project
				// I used a lambda statement because I wanted to use the same variable names
				// think of them as functions inside of functions
				 {
					OpenConnection ();
					string query = "SELECT * FROM projectrequests WHERE user_id = " 
						+ user.ID + " AND project_id = " + project.ID + ";";
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
					DataSet ds = new DataSet ();
					dataAdapter.Fill (ds, "projectrequests");
					CloseConnection ();
						
					if (ds.Tables ["projectrequests"].Rows.Count == 0) {
						return false;
					}
				};
				// Delete join request
				{
					OpenConnection ();
					string query = "DELETE FROM projectrequests WHERE user_id = " 
						+ user.ID + " AND project_id = " + project.ID + ";";
					MySqlCommand command = new MySqlCommand (query, connection);

					command.ExecuteNonQuery();
					command.Dispose();
					CloseConnection ();
				};
				// Change activeproject
				user.ActiveProject = project.ID;
				this.UpdateUser (user);

				return true;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of AcceptUserProjectRequest ()

		/*
		 * @param task - the task that is to be assigned
		 * @param uesr - the user, the task that is to be assigned, is assigned to
		 * @return bool - succes
		 */ 
		public bool GrantTask (TaskData task, UserData user)
		{
			try {
				OpenConnection ();
				string query = "SELECT * FROM users WHERE ActiveTask = " + task.ID + ";";
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, connection);
				DataSet ds = new DataSet ();
				dataAdapter.Fill (ds, "users");
				CloseConnection ();

				if (ds.Tables ["users"].Rows.Count != 0) {
					return false;
				}

				if (user.ActiveTask != DBDefaults.DefaultId) return false;
				else {
					user.ActiveTask = task.ID;
					this.UpdateUser (user);
					return true;
				}
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		} // End of GrantTask ()

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

