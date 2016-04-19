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
	public partial class ProjectSuggestionData : DataBaseDataType
	{

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

			Title = DBDefaults.DefaultText;
			ShortDescription = DBDefaults.DefaultText;
			DetailedDescription = DBDefaults.DefaultText;
			CreatedBy = creatorId;
			DateCreated = DBDefaults.DefaultDate;
			InvestmentRequired = DBDefaults.DefaultText;
			EstimatedReturn = DBDefaults.DefaultText;
			Priority = DBDefaults.DefaultText;
			Notes = DBDefaults.DefaultText;
		} // End of Constructor

		public string ToQueryString ()
		{
			return "Not Implemented";
		} // End of ToQueryString ()

		public void FillFromDataRow (DataRow row)
		{
			// TODO implement this method
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

