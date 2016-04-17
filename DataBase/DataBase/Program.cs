using System;
using System.Collections.Generic;
using DataBase;

namespace DataBase
{
	// This class will be used for testing
	class MainClass
	{

		public DataBaseHandler db = new DataBaseHandler();

		public static void Main (string[] args)
		{
			//UserData user = new UserData (1);
			//MainClass tester = new MainClass();
			//tester.Login();

			MainClass main = new MainClass ();
			main.run ();

			Console.ReadKey ();
		}

		public void run () {
			Console.WriteLine ("This is a test of Taskr.\n\n");
			Console.WriteLine ("Login\n\n");
			Console.Write ("UserName: ");
			string username = "mircea";//Console.ReadLine ();
			Console.Write ("Password: ");
			string password = "passwordmircea1";//Console.ReadLine ();

			UserData user = db.VerifyLogin (username, password);
			if (user == null) {
				Console.WriteLine ("Did not find user, exiting...");
				return;
			}

			Console.WriteLine ("\n\nSuccessful login.");
			printUserDetails (user);

		}
			

		// User details can be used to fill in any data you want from the form
		public void printUserDetails (UserData user) {
			Console.WriteLine ("\nPrinting user details...");
			Console.WriteLine ("FirstName: " + user.FirstName);
			Console.WriteLine ("LastName: " + user.LastName);
			Console.WriteLine ("DisplayName: " + user.DisplayName);
			Console.WriteLine ("AvatarURL: " + user.AvatarURL);
			Console.WriteLine ("Email: " + user.Email);
			Console.WriteLine ("Password: " + user.Password);
			Console.WriteLine ("PhoneNumber: " + user.PhoneNumber);
			Console.WriteLine ("JoinDate: " + user.JoinDate.ToString ());
			Console.WriteLine ("AddedById: " + user.AddedById);
			Console.WriteLine ("ActiveProject: " + user.ActiveProject);
			Console.WriteLine ("ActiveTask: " + user.ActiveTask);
			Console.WriteLine ("WorkStatus: " + user.WorkStatus);
			Console.WriteLine ("PersonalNotes: " + user.PersonalNotes);
			Console.WriteLine ("DateLeft: " + user.DateLeft.ToString ());
			Console.WriteLine ("ReasonForLeaving: " + user.ReasonForLeaving);
			Console.WriteLine ("RejoinDesirability: " + user.RejoinDesirability);
			Console.WriteLine ("Observations: " + user.Observations);
		}
	}
}
