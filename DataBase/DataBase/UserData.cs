/*
 * Name: UserData
 * By: Kovacs Gyorgy
 * Date: 2016.04.10 ->
 * 
 * This class will allow, or rather make easier communication with the
 * databaseHandler and the forms. One doesn't have to remember to call
 * the handler 20 times per add or read.
 * 
 * 2016.04.16 - Modification to database!!!
 * Added extra field to users table, column nr 11, ActiveTask.
 */

using System;
using System.Data;

namespace DataBase
{
	// This part contains all the methods of the class
	public partial class UserData : DataBaseDataType
	{

		/* Make sure everything is initialized as we want it.
		 * If you have a better idea of doing it pls talk to Gyuri.
		 *  @param secretatyId - Takes the id of the secretary that creates it.
		 */
		public UserData () : this (0)
		{
			// Nothing to see here
		}
		public UserData (int secretaryId)
		{

			FirstName = DBDefaults.DefaultText;
			LastName = DBDefaults.DefaultText;
			DisplayName = DBDefaults.DefaultText;
			AvatarURL = DBDefaults.DefaultText;
			Email = DBDefaults.DefaultText;
			Password = DBDefaults.DefaultText;
			PhoneNumber = DBDefaults.DefaultText;
			JoinDate = DBDefaults.DefaultDate;
			AddedById = secretaryId;
			ActiveProject = DBDefaults.DefaultId;
			ActiveTask = DBDefaults.DefaultId;
			WorkStatus = DBDefaults.DefaultText;
			PersonalNotes = DBDefaults.DefaultText;
			DateLeft = DBDefaults.DefaultDate;
			ReasonForLeaving = DBDefaults.DefaultText;
			RejoinDesirability = DBDefaults.DefaultText;
			Observations = DBDefaults.DefaultText;
		} // End of Constructor

		public string ToQueryString() 
		{
			// TODO implement method
			return "Not yet implemented";
		}

		//TODO Check if not null... Maybie with a function?
		public void FillFromDataRow (DataRow row) 
		{
			_id = int.Parse(row.ItemArray.GetValue (0).ToString ());
			FirstName = row.ItemArray.GetValue (1).ToString ();
			LastName = row.ItemArray.GetValue (2).ToString ();
			DisplayName = row.ItemArray.GetValue (3).ToString ();
			AvatarURL = row.ItemArray.GetValue (4).ToString ();
			Email = row.ItemArray.GetValue (5).ToString ();
			Password = row.ItemArray.GetValue (6).ToString ();
			PhoneNumber = row.ItemArray.GetValue (7).ToString ();
			JoinDate = DateTime.Parse(row.ItemArray.GetValue (8).ToString ());
			AddedById = int.Parse(row.ItemArray.GetValue (9).ToString ());
			ActiveProject = int.Parse(row.ItemArray.GetValue (10).ToString ());
			ActiveTask = int.Parse(row.ItemArray.GetValue (11).ToString ());
			WorkStatus = row.ItemArray.GetValue (12).ToString ();
			PersonalNotes = row.ItemArray.GetValue (13).ToString ();

			try{
				DateLeft = DateTime.Parse (row.ItemArray.GetValue (14).ToString ());
			}
			catch (Exception e) {
				Console.WriteLine (e.ToString ());
				DateLeft = DBDefaults.DefaultDate;
			}
			
			ReasonForLeaving = row.ItemArray.GetValue (15).ToString ();
			RejoinDesirability = row.ItemArray.GetValue (16).ToString ();
			Observations = row.ItemArray.GetValue (17).ToString ();
		} // End of FillFromDataRow()
	}

	// This class contains all the attributes of the class, and 
	// setter and getter methods.
	public partial class UserData 
	{
		private int _id; // Id
		public int ID {
			get {return _id;}
		}

		private string _firstName; // FirstName
		public string FirstName {
			set {_firstName = value;}
			get {return _firstName;}
		}

		private string _lastName; // LastName
		public string LastName {
			set {_lastName = value;}
			get {return _lastName;}
		}

		private string _displayName; // DisplayName
		public string DisplayName {
			set {_displayName = value;}
			get {return _displayName;}
		}

		private string _avatarURL; // AvatarLink
		public string AvatarURL {
			set {_avatarURL = value;}
			get {return _displayName;}
		}

		private string _email; // Email
		public string Email {
			set {_email = value;}
			get {return _email;}
		}

		private string _password; // Password
		public string Password {
			set {_password = value;}
			get {return _password;}
		}

		private string _phoneNumber; // Phone Number
		public string PhoneNumber {
			set {_phoneNumber = value;}
			get {return _phoneNumber;}
		}

		private DateTime _joinDate; // JoinDate
		public DateTime JoinDate {
			set {_joinDate = value;}
			get {return _joinDate;}
		}

		private int _addedBy; // AddedBy
		public int AddedById {
			set {_addedBy = value;}
			get {return _addedBy;}
		}

		private int _activeProject; // ActiveProject
		public int ActiveProject {
			set {_activeProject = value;}
			get {return _activeProject;}
		}

		private int _activeTask; // ActiveTask
		public int ActiveTask {
			set {_activeTask = value;}
			get {return _activeTask;}
		}

		private string _workStatus; // WorkStatus
		public string WorkStatus {
			set {_workStatus = value;}
			get {return _workStatus;}
		}

		private string _personalNotes; // Personal Notes
		public string PersonalNotes {
			set {_personalNotes = value;}
			get {return _personalNotes;}
		}

		private DateTime _dateLeft; // LeaveDate
		public DateTime DateLeft {
			set {_dateLeft = value;}
			get {return _dateLeft;}
		}

		private string _reasonForLeaving; // ReasonForLeaving
		public string ReasonForLeaving {
			set {_reasonForLeaving = value;}
			get {return _reasonForLeaving;}
		}

		private string _rejoinDesirability; // RejoinDesirability
		public string RejoinDesirability {
			set {_rejoinDesirability = value;}
			get {return _rejoinDesirability;}
		}

		private string _observations; // Observations
		public string Observations {
			set {_observations = value;}
			get {return _phoneNumber;}
		}
	}

}

