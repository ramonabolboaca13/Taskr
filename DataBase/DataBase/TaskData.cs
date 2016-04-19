/*
 * Name: UserData
 * By: Kovacs Gyorgy
 * Date: 2016.04.10 -> 
 * 
 * This class will allow, or rather make easier communication with the
 * databaseHandler and the forms. One doesn't have to remember to call
 * the handler 20 times per add or read.
 */
using System;
using System.Data;

namespace DataBase
{
	// This part contains all the methods of the class
	public partial class TaskData : DataBaseDataType
	{

		/* Make sure everything is initialized as we want it.
		 * If you have a better idea of doing it pls talk to Gyuri.
		 *  @param creatorId - Takes the id of the secretary that creates it.
		 */
		public TaskData () : this(0)
		{
			// Nothing to do here
		}

		public TaskData (int creatorId)
		{
			ParentId = DBDefaults.DefaultId;
			Title = DBDefaults.DefaultText;
			ShortDescription = DBDefaults.DefaultText;
			DetailedDescription = DBDefaults.DefaultText;
			ParentProject = DBDefaults.DefaultId;
			DateCreated = DBDefaults.DefaultDate;
			CreatedBy = creatorId;
			DateCompleted = DBDefaults.DefaultDate;
			CompletedBy = DBDefaults.DefaultId;
			DeadLine = DBDefaults.DefaultDate;
			Status = DBDefaults.DefaultText;
		}

		public string ToQueryString () 
		{
			string returnString = "(";

			returnString += "'" + ParentId.ToString() + "', "; 					// 1
			returnString += "'" + Title + "', ";				  				// 2
			returnString += "'" + ShortDescription + "', ";						// 3
			returnString += "'" + DetailedDescription + "', ";					// 4
			returnString += "'" + ParentProject.ToString() + "', ";				// 5
			returnString += "'" + DateCreated.ToShortDateString() + "', ";		// 6
			returnString += "'" + CreatedBy.ToString() + "', ";					// 7
			returnString += "'" + DateCompleted.ToShortDateString() + "', ";	// 8
			returnString += "'" + CompletedBy.ToString() + "', ";				// 9
			returnString += "'" + DeadLine.ToShortDateString() + "', ";			//10
			returnString += "'" + Status + "'";									//11

			return returnString += ")";
		} // End of ToQueryString()

		public void FillFromDataRow (DataRow row)
		{
			
		} // FillFromDataRow ()
	}

	// This class contains all the attributes of the class, and 
	// setter and getter methods.
	public partial class TaskData
	{
		private int _id; // Id
		public int ID {
			get {return _id;}
		}

		private int _parentId; // ParentId
		public int ParentId {
			set {_parentId = value;}
			get {return _parentId;}
		}

		private string _title; // Title
		public string Title {
			set {_title = value;}
			get {return _title;}
		}

		private string _shortDescription; // ShortDescription
		public string ShortDescription {
			set {_shortDescription = value;}
			get {return _shortDescription;}
		}

		private string _detailedDescription; // DetailedDescription
		public string DetailedDescription {
			set {_detailedDescription = value;}
			get {return _detailedDescription;}
		}

		private int _parentProject; // ParentProject
		public int ParentProject {
			set {_parentProject = value;}
			get {return _parentProject;}
		}

		private DateTime _dateCreated; // DateCreated
		public DateTime DateCreated {
			set {_dateCreated = value;}
			get {return _dateCreated;}
		}

		private int _createdBy; // CreatedBy
		public int CreatedBy {
			set {_createdBy = value;}
			get {return _createdBy;}
		}

		private DateTime _dateCompleted; // DateCompleted
		public DateTime DateCompleted {
			set {_dateCompleted = value;}
			get {return _dateCompleted;}
		}

		private int _completedBy; // CompletedBy
		public int CompletedBy {
			set {_completedBy = value;}
			get {return _completedBy;}
		}

		private DateTime _deadLine; // DeadLine
		public DateTime DeadLine {
			set {_deadLine = value;}
			get {return _deadLine;}
		}

		private string _status; // Status
		public string Status {
			set {_status = value;}
			get {return _status;}
		}
	}
}

