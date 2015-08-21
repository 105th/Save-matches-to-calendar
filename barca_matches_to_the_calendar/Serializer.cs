using System;
using System.IO;
using System.Xml.Serialization;


namespace barca_matches_to_the_calendar
{
	public static class Serializer
	{
		/// <summary>
		/// Сохраняем одиночный матч по указанному пути 
		/// (по желанию отсеивая прошедшие матчи).
		/// </summary>
		/// <param name="path">Путь, по которому сохраняем.</param>
		/// <param name="match">Матч.</param>
		/// <param name="savePastMatches">Если значение <c>true</c>, тогда сохраняем прошедшие матчи,
		///  если значение <c>false</c>, тогда НЕ сохраняем прошедшие матчи.</param>
		public static void Serialize(string path, SingleMatch match, bool savePastMatches)
		{
			// Проверяем матч на наличие чего-либо.
			if (match == null)
				throw new ArgumentNullException("Матч пуст!");

			// Проверяем, прошел ли матч или нет.
			if (!savePastMatches && DateTime.Compare(match.StartTime, DateTime.Now) < 0)
				return;

			// Создаем объект типа сериализатор.
			XmlSerializer serializer = new XmlSerializer(typeof(SingleMatch));
			// Открываем файл на чтение (если нет, то создаем).
			using (FileStream fs = new FileStream(path, FileMode.Append))
			{
				serializer.Serialize(fs, match);
			}
		}
	}
}

