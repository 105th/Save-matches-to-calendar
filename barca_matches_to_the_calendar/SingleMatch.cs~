using System;
using System.Xml.Serialization;

namespace barca_matches_to_the_calendar
{
	/// <summary>
	/// Класс одного матча.
	/// </summary>
	[Serializable]
	public class SingleMatch
	{
		/// <summary>
		/// Дата и время начала матча.
		/// </summary>
		DateTime _startTime;

		/// <summary>
		/// Турнир.
		/// </summary>
		string _tournament;

		/// <summary>
		/// Название футбольного клуба.
		/// </summary>
		string _nameFC;

		/// <summary>
		/// Соперник.
		/// </summary>
		string _rival;

		/// <summary>
		/// Место (в гостях/дома)
		/// </summary>
		string _place;

		/// <summary>
		/// Создает объект класса SingleMatch
		///  <see cref="barca_matches_to_the_calendar.SingleMatch"/> class.
		/// </summary>
		public SingleMatch()
		{
			_tournament = null;
			_rival = null;
			_place = null;
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

			_startTime = startTime;
			_tournament = tournament;
			_rival = rival;
			_place = place;
		}

		/// <summary>
		/// Свойство для присваивания или выдачи время начала матча.
		/// </summary>
		/// <value>Время начала матча типа <see cref="DateTime"/>.</value>
		[XmlElement("Время начала матча")]
		public DateTime StartTime
		{
			get
			{
				return _startTime;
			}
			set
			{
				_startTime = value;
			}
		}

		/// <summary>
		/// Свойство для присваивания или выдачи названия турнира.
		/// </summary>
		/// <value>Название турнира.</value>
		[XmlElement("Турнир")]
		public string Tournament
		{
			get
			{
				return _tournament;
			}
			set
			{
				_tournament = value;
			}
		}

		/// <summary>
		/// Название футбольного клуба.
		/// </summary>
		/// <value>Название футбольного клуба.</value>
		[XmlElement("Название ФК")]
		public string NameFC
		{
			get
			{
				return _nameFC;
			}
			set
			{
				_nameFC = value;
			}
		}

		/// <summary>
		/// Свойство для присваивания или выдачи соперника.
		/// </summary>
		/// <value>Наименование ФК - соперника.</value>
		[XmlElement("Соперник")]
		public string Rival
		{
			get
			{
				return _rival;
			}
			set
			{
				_rival = value;
			}
		}

		/// <summary>
		/// Свойство для присваивания или выдачи места (в гостях/дома).
		/// </summary>
		/// <value>Место (в гостях/дома).</value>
		[XmlElement("Место")]
		public string Place
		{
			get
			{
				return _place;
			}
			set
			{
				_place = value;
			}
		}

		public override string ToString()
		{
			return string.Format("Время начала матча={0}, турнир={1}, соперник={2}, место={3}]",
				_startTime, _tournament, _rival, _place);
		}
	}
}

