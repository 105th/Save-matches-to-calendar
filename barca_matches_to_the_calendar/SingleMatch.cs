using System;

namespace barca_matches_to_the_calendar
{
	/// <summary>
	/// Класс одного матча.
	/// </summary>
	public class SingleMatch
	{

		/// <summary>
		/// Дата времени начала матча.
		/// </summary>
		/// <value>Время начала матча типа <see cref="DateTime"/>.</value>
		public DateTime StartTime
		{
			get;
			set;
		}

		/// <summary>
		/// Название турнира.
		/// </summary>
		/// <value>Название турнира.</value>
		public string Tournament
		{
			get;
			set;
		}

		/// <summary>
		/// Наименование ФК-соперника.
		/// </summary>
		/// <value>Наименование ФК - соперника.</value>
		public string Rival
		{
			get;
			set;
		}

		/// <summary>
		/// Место матча (в гостях/дома).
		/// </summary>
		/// <value>Место ("В гостях"/"Дома").</value>
		public string Place
		{
			get;
			set;
		}

		/// <summary>
		/// Создает объект класса SingleMatch
		///  <see cref="barca_matches_to_the_calendar.SingleMatch"/> class.
		/// </summary>
		public SingleMatch()
		{
			StartTime = new DateTime();
			Tournament = null;
			Rival = null;
			Place = null;
		}


		/// <summary>
		/// Создаёт объект класса SingleMatch
		/// <see cref="barca_matches_to_the_calendar.SingleMatch"/> class.
		/// </summary>
		/// <param name="startTime">Время начала матча.</param>
		/// <param name="tournament">Турнир.</param>
		/// <param name="rival">Соперник.</param>
		/// <param name="place">Место (в гостях/дома).</param>
		public SingleMatch(DateTime startTime,
		                   string tournament,
		                   string rival,
		                   string place)
		{
			// Проверяем параметр "Турнир".
			if (string.IsNullOrWhiteSpace(tournament))
				throw new ArgumentException("Параметр Турнира не может быть пустым");

			// Проверяем параметр "Соперник".
			if (string.IsNullOrWhiteSpace(rival))
				throw new ArgumentException("Параметр Соперник не может быть пустым");

			// Проверяем параметр "Место".
			if (string.IsNullOrWhiteSpace(place))
				throw new ArgumentException("Параметр Место не может быть пустым");

			StartTime = startTime;
			Tournament = tournament;
			Rival = rival;
			Place = place;
		}


		/// <summary>
		/// Возращает a <see cref="System.String"/>, которая является текстовым
		/// представлением  <see cref="barca_matches_to_the_calendar.SingleMatch"/>.
		/// </summary>
		/// <returns>
		/// Возращает a <see cref="System.String"/>, которая является текстовым
		/// представлением  <see cref="barca_matches_to_the_calendar.SingleMatch"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Время начала матча={0}, турнир={1}, соперник={2}, место={3}",
				StartTime, Tournament, Rival, Place);
		}
	}
}

