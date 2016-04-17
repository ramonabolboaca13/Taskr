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

namespace DataBase
{
	// This part contains all the methods of the class
	public partial class ProjectSuggestionData
	{

		private string emptyMarker = "Blank";
		private DateTime emptyDate = new DateTime (1970, 1, 1);
		private int emptyId = 0;

		/* Make sure everything is initialized as we want it.
		 * If you have a better idea of doing it pls talk to Gyuri.
		 *  @param creatorId - Takes the id of the secretary that creates it.
		 */
		public ProjectSuggestionData () : this(0)
		{
			// Nothing to do here
		}

		public ProjectSuggestionData (int creatorId)
		{

			Title = emptyMarker;
			ShortDescription = emptyMarker;
			DetailedDescription = emptyMarker;
			CreatedBy = creatorId;
			DateCreated = emptyDate;
			InvestmentRequired = emptyMarker;
			EstimatedReturn = emptyMarker;
			Priority = emptyMarker;
			Notes = emptyMarker;
		}
	}

	// This class contains all the attributes of the class, and 
	// setter and getter methods.
	public partial class ProjectSuggestionData
	{
		private int _id;// Id
		public int ID {
			get{return _id;}
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

		private DateTime _dateCreated; // DateCreated
		public DateTime DateCreated {
			set {_dateCreated = value;}
			get {return _dateCreated;}
		}

		private string _investmentRequired; // InvestmentRequired
		public string InvestmentRequired {
			set {_investmentRequired = value;}
			get {return _investmentRequired;}
		}

		private string _estimatedReturn; // EstimatedReturn
		public string EstimatedReturn {
			set {_estimatedReturn = value;}
			get {return _estimatedReturn;}
		}

		private string _priority; // Priority
		public string Priority {
			set {_priority = value;}
			get {return _priority;}
		}

		private string _notes; // Notes
		public string Notes {
			set {_notes = value;}
			get {return _notes;}
		}
	}
}

