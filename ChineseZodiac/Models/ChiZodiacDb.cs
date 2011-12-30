using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Mono.Data.Sqlite;

namespace ChineseZodiac
{
	/// <summary>
	/// This is the public face of the SQLite3 database
	/// </summary>
	public class ChiZodiacDb
	{			
		#region Private vars
		string dbUrl;
		SqliteConnection conn;
		ChiZodiacData dataCon;
		#endregion
				
		#region Convenient properties to list stuff
		public List<string> Names {
			get { 
				var ns = from d in dataCon.Animals select d.Name;
				return ns.ToList ();
			}
		}
		
		public List<CZAnimal> Animals {
			get {
				return dataCon.Animals.ToList ();
			}
		}
		#endregion
		
		/// <summary>
		/// Add the specified animal.
		/// </summary>
		/// <param name='animal'>
		/// Animal.
		/// </param>
		public void Add (CZAnimal animal)
		{
			/// n.b. look out for quotes causing errors
			
			var s = new SqliteCommand ();
			
			/// to prevent an injection attack, we parameterize with @name/etc
			s.CommandText = "INSERT INTO animals (name, position, year) VALUES (@name, @position, @year)";			
			s.Parameters.AddWithValue ("@name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase (animal.Name));
			s.Parameters.AddWithValue ("@position", animal.Position);
			s.Parameters.AddWithValue ("@year", animal.Year);
						
			s.Connection = conn;			
			// connect
			conn.Open ();
			
			// execute the command
			s.ExecuteNonQuery ();
			
			// tidy up
			s.Dispose ();
			conn.Close ();
		}
		
		public void Delete (CZAnimal animal)
		{
			var s = new SqliteCommand ();
			s.CommandText = "DELETE FROM animals WHERE name = @name AND position = @position AND year = @year";
			s.Parameters.AddWithValue ("@name", animal.Name);
			s.Parameters.AddWithValue ("@position", animal.Position);
			s.Parameters.AddWithValue ("@year", animal.Year);
			
			s.Connection = conn;
			conn.Open ();
			s.ExecuteNonQuery ();
			s.Dispose ();
			conn.Close ();			
		}
		
		#region Constructor
		public ChiZodiacDb (string fileName)
		{
			// only works with absolute paths
			this.dbUrl = Path.GetFullPath (fileName);
			// make a connection
			this.conn = new SqliteConnection ("DbLinqProvider=Sqlite; Data Source=" + dbUrl);
			// get the data context
			this.dataCon = new ChiZodiacData (conn);
		}
		#endregion
	}
	
	
	#region Long comment on SQLite
	/* 
	 * To create a database, run this in bash: sqlite3 my_database_file.db
	 * This creates the file and starts the SQLite REPL (interpreter).
	 * You must add a table: CREATE TABLE animals (name varchar(10), int position, int year);
	 * Then insert some animals: INSERT INTO animals (name, position, year) VALUES ('Rat', 1, 1923);
	 * Just terminate sqlite3 to finish (Ctrl+D).
	 *
	 * The two classes below are basically SQL-to-Linq glue. They can be automatically generated with sqlmetal:
 	 * sqlmetal /namespace:ChineseZodiac /provider:Sqlite "/conn:Data Source=chinesezodiac.db" /code:Automatic.cs
	 */
	#endregion
	
	/// <summary>
	/// 'Strongly-typed' data context for the database
	/// </summary>
	public class ChiZodiacData : DataContext
	{
		public ChiZodiacData (SqliteConnection conn) : base (conn)
		{
		}

		public Table<CZAnimal> Animals {
			get { return this.GetTable<CZAnimal> (); }
		}
	}
	
	/// <summary>
	/// Animal object, with properties mapped to database fields
	/// </summary>
	[Table(Name="main.animals")]
	public class CZAnimal
	{
		[Column(Storage="Name", Name="name", DbType="varchar(10)", AutoSync=AutoSync.Never)]
		public string Name { get; set; }
		
		[Column(Storage="Position", Name="position", DbType="int", AutoSync=AutoSync.Never)]
		public int Position { get; set; }
		
		[Column(Storage="Year", Name="year", DbType="int", AutoSync=AutoSync.Never)]
		public int Year { get; set; }
	}
	
	
}

