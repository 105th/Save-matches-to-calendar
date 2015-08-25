using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using System.Security.Cryptography;

namespace barca_matches_to_the_calendar
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// Адрес сайта, откуда будем парсить данные.
			string WebAddress = @"http://www.sports.ru/barcelona/calendar/";

			// Создаём экземляры классов веб-страницы и веб-документа
			HtmlWeb WebGet = new HtmlWeb();
			// Загружаем html-документ с указанного сайта.
			HtmlDocument htmlDoc = WebGet.Load(WebAddress);

			// Сюда будем сохранять матчи
			Matches MatchesFC = new Matches();

			// Парсим название клуба (удаляя символ возрата каретки)
			MatchesFC.NameFC = htmlDoc.DocumentNode.
				SelectSingleNode(".//*[@class='titleH1']").
				FirstChild.InnerText.Replace("\r\n", "");
			
			
			// Находим в этом документе таблицу с датами матчей с помощью XPath-выражений.
			HtmlNode Table = htmlDoc.DocumentNode.SelectSingleNode(".//*[@class='stat-table']/tbody");
			// Из полученной таблицы выделяем все элементы-строки с тегом "tr".
			IEnumerable<HtmlNode> rows = Table.Descendants().Where(x => x.Name == "tr");

			foreach (var row in rows)
			{
				// Создаём коллекцию из ячеек каждой строки.
				HtmlNodeCollection cells = row.ChildNodes;
				// Создаём экземпляр класса SingleMatch, чтобы затем добавить его в лист.
				SingleMatch match = new SingleMatch();

				// Парсим дату, предварительно убирая из строки символ черточки "|",
				// иначе наш метод TryParse не сможет правильно обработать.
				DateTime time;
				DateTime.TryParse(cells[1].InnerText.Replace("|", " "), out time);
				match.StartTime = time;

				// Остальные поля просто заполняем, зная нужный нам индекс.
				match.Tournament = cells[3].InnerText;
				// В ячейке "Соперник" нужно удалить символ неразрывного пробела ("&nbsp")
				match.Rival = cells[5].InnerText.Replace("&nbsp;", "");
				match.Place = cells[6].InnerText;

				// Добавляем одиночный матч в лист матчей.
				MatchesFC.ListMatches.Add(match);
			}

			// Создаём календарь, в который будем сохранять матчи.
			iCalendar CalForMatches = new iCalendar
			{
				Method = "PUBLISH",
				Version = "2.0"
			};
			// Эти настройки нужны для календаря Mac, чтобы он был неотличим от 
			// оригинального календаря (т.е. созданного внутри Mac Calendar)
			CalForMatches.AddProperty("CALSCALE", "GREGORIAN");
			CalForMatches.AddProperty("X-WR-CALNAME", "Mатчи ФК " + MatchesFC.NameFC);
			CalForMatches.AddProperty("X-WR-TIMEZONE", "Europe/Moscow");
			CalForMatches.AddLocalTimeZone();

			// Сохраняем полученный результат.
			foreach (SingleMatch match in MatchesFC.ListMatches)
			{
				Event newMatch = CalForMatches.Create<Event>();

				newMatch.DTStart = new iCalDateTime(match.StartTime);
				newMatch.Duration = new TimeSpan(2, 30, 0);
				newMatch.Summary = string.Format("{0} : {1}", MatchesFC.NameFC, match.Rival);
				newMatch.Description = string.Format("{0}. {1} : {2}, {3}",
					match.Tournament, MatchesFC.NameFC, match.Rival, match.Place);
				
				// Добавим напоминание к матчам, чтобы не забыть о них
				Alarm alarm = new Alarm();
				alarm.Trigger = new Trigger(TimeSpan.FromMinutes(-10));
				alarm.Description = "Напоминание о событии";
				alarm.AddProperty("ACTION", "DISPLAY");
				newMatch.Alarms.Add(alarm);
			}

			// Сериализуем наш календарь.
			iCalendarSerializer serializer = new iCalendarSerializer();
			serializer.Serialize(CalForMatches, MatchesFC.NameFC + ".ics");
			Console.WriteLine("Календарь матчей сохранён успешно" + Environment.NewLine);

			return;
		}
	}
}
