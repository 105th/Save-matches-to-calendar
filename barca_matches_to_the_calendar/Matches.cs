using System.Collections.Generic;


namespace barca_matches_to_the_calendar
{
	public class Matches
	{
		/// <summary>
		/// Название ФК.
		/// </summary>
		/// <value>Название ФК.</value>
		public string NameFC
		{
			get;
			set;
		}

		/// <summary>
		/// Лист матчей команды
		/// </summary>
		/// <value>Лист матчей</value>
		public List<SingleMatch> ListMatches
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="barca_matches_to_the_calendar.Matches"/> class.
		/// </summary>
		public Matches()
		{
			ListMatches = new List<SingleMatch>();
			NameFC = null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="barca_matches_to_the_calendar.Matches"/> class.
		/// </summary>
		/// <param name="nameFC">Название ФК.</param>
		public Matches(string nameFC)
		{
			ListMatches = new List<SingleMatch>();
			NameFC = nameFC;
		}

		public override string ToString()
		{
			return string.Format("Матчи ФК  \"{0}\", количество {1}", NameFC, ListMatches);
		}
	}
}

