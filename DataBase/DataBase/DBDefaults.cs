/*
 * Name: DBDefaults
 * By: Kovacs Gyorgy
 * Date: 2016.04.19
 * 
 * This class contains default field definitions that go into the database,
 * I made a separate enum, because I had these values declared in each *Data class,
 * and it seemed to be nicer to have them in one place, for easy editing later.
 * 
 */ 
using System;

namespace DataBase
{
	public class DBDefaults
	{
		public DBDefaults ()
		{
		}

		public static string DefaultText = "Blank";
		public static int DefaultId = 0;
		public static DateTime DefaultDate = new DateTime(1970, 1, 1);
	}
}

