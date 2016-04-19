using System;
using System.Data;

namespace DataBase
{
	public interface DataBaseDataType
	{
		string ToQueryString ();
		void FillFromDataRow (DataRow row);
	}
}

