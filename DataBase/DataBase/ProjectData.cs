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
	public partial class ProjectData
	{

		private string emptyMarker = "Blank";
		private DateTime emptyDate = new DateTime (1970, 1, 1);
		private int emptyId = 0;

		/* Make sure everything is initialized as we want it.
		 * If you have a better idea of doing it pls talk to Gyuri.
		 *  @param creatorId - Takes the id of the secretary that creates it.
		 */
		public ProjectData () : this(0)
		{
			// Nothing to do here
		}

		public ProjectData (int creatorId)
		{

			Title = emptyMarker;
			ShortDescription = emptyMarker;
			DetailedDescription = emptyMarker;
			CreatedBy = creatorId;
			ProjectLead = creatorId;
			DateCreated = emptyDate;
			LogURL = emptyMarker;
			Notes = emptyMarker;
			AvailibleFunds = emptyMarker;
			CurrentYield = emptyMarker;
			DateTerminated = emptyDate;
			TerminationReason = emptyMarker;
			TerminatedBy = emptyId;
			CollectedFunds = emptyMarker;
			ConsumedFunds = emptyMarker;
		} // End of Constructor

		public string ToQueryString () 
		{
			string returnString = "(";

			returnString += "'" + Title + "', "; 								// 1
			returnString += "'" + ShortDescription + "', ";						// 2
			returnString += "'" + DetailedDescription + "', ";					// 3
			returnString += "'" + CreatedBy + "', ";							// 4
			returnString += "'" + ProjectLead + "', ";							// 5
			returnString += "'" + DateCreated.ToShortDateString() + "', ";		// 6
			returnString += "'" + LogURL + "', ";								// 7
			returnString += "'" + Notes + "', ";								// 8
			returnString += "'" + AvailibleFunds + "', ";						// 9
			returnString += "'" + CurrentYield + "', ";			    			//10
			returnString += "'" + DateTerminated.ToShortDateString() + "', ";	//11
			returnString += "'" + TerminationReason + "', ";					//12
			returnString += "'" + TerminatedBy + "', ";							//13
			returnString += "'" + CollectedFunds + "', ";						//14
			returnString += "'" + ConsumedFunds + "'";							//15

			return returnString += ")";
		} // End of ToQueryString()

		public void FillFromDataRow (DataRow row)
		{
			_id = int.Parse(row.ItemArray.GetValue (0).ToString ());
			Title = row.ItemArray.GetValue (1).ToString ();
			ShortDescription = row.ItemArray.GetValue (2).ToString ();
			DetailedDescription = row.ItemArray.GetValue (3).ToString ();
			CreatedBy = int.Parse(row.ItemArray.GetValue (4).ToString ());
			ProjectLead = int.Parse(row.ItemArray.GetValue (5).ToString ());
			DateCreated = DateTime.Parse(row.ItemArray.GetValue (6).ToString ());
			LogURL = row.ItemArray.GetValue (7).ToString ();
			Notes = row.ItemArray.GetValue (8).ToString ();
			AvailibleFunds = row.ItemArray.GetValue (9).ToString ();
			CurrentYield = row.ItemArray.GetValue (10).ToString ();
			DateTerminated = DateTime.Parse(row.ItemArray.GetValue (11).ToString ());
			TerminationReason = row.ItemArray.GetValue (12).ToString ();
			TerminatedBy = int.Parse(row.ItemArray.GetValue (13).ToString ());
			CollectedFunds = row.ItemArray.GetValue (14).ToString ();
			ConsumedFunds = row.ItemArray.GetValue (15).ToString ();
		} // End of FillFromDataRow()
	} // End of Partial Class



	// This class contains all the attributes of the class, and 
	// setter and getter methods.
	public partial class ProjectData
	{
		private int _id; // Id
		public int ID {
			get {return _id;}
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

		private int _createdBy; // CreatedBy
		public int CreatedBy {
			set {_createdBy = value;}
			get {return _createdBy;}
		}

		private int _projectLead; // ProjectLead
		public int ProjectLead {
			set {_projectLead = value;}
			get {return _projectLead;}
		}

		private DateTime _dateCreated; // DateCreated
		public DateTime DateCreated {
			set {_dateCreated = value;}
			get {return _dateCreated;}
		}

		private string _log; // ModificationLogLink
		public string LogURL {
			set {_log = value;}
			get {return _log;}
		}

		private string _notes; // Notes
		public string Notes {
			set {_notes = value;}
			get {return _notes;}
		}

		private string _availibleFunds; // AvailibleFunds
		public string AvailibleFunds {
			set {_availibleFunds = value;}
			get {return _availibleFunds;}
		}

		private string _currentYield; // CurrentYield
		public string CurrentYield {
			set {_currentYield = value;}
			get {return _currentYield;}
		}

		private DateTime _dateTerminated; // DateTerminated
		public DateTime DateTerminated {
			set {_dateTerminated = value;}
			get {return _dateTerminated;}
		}

		private string _terminationReason; // TerminationReason
		public string TerminationReason {
			set {_terminationReason = value;}
			get {return _terminationReason;}
		}

		private int _terminatedBy; // TerminatedBy
		public int TerminatedBy {
			set {_terminatedBy = value;}
			get {return _terminatedBy;}
		}

		private string _collectedFunds; // CollectedFunds
		public string CollectedFunds {
			set {_collectedFunds = value;}
			get {return _collectedFunds;}
		}

		private string _consumedFunds; // ConsumedFunds
		public string ConsumedFunds {
			set {_consumedFunds = value;}
			get {return _consumedFunds;}
		}
	}
}

