using System.Collections.Generic;
using System.IO;
using System.Linq;
using Helpers;
using UnityEngine;

namespace Controllers
{
	/// <summary>
	/// Класс отвечающий за сохранение массива в формат Json и его загрузку
	/// </summary>
	public static class SaveController
	{
		private static readonly string SavePath = $"{Application.dataPath}/Saves/";

		public static void Init()
		{
			if (!Directory.Exists(SavePath))
				Directory.CreateDirectory(SavePath);
		}

		/// <summary>
		/// Сохраняет файл в формате Json 
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		/// <param name="lst">Массив для сохраниения</param>
		public static void Save(string fileName, LeaderBoardValues[] lst)
		{
			File.WriteAllText($"{SavePath}{fileName}.json", JsonHelper.ToJson(lst, true));
		}
		/// <summary>
		/// Загружает файл
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		/// <returns>Отсортированный массив с LeaderBoardValues</returns>
		public static IEnumerable<LeaderBoardValues> Load(string fileName)
		{
			if (File.Exists($"{SavePath}{fileName}.json"))
			{
				return JsonHelper.FromJson<LeaderBoardValues>(File.ReadAllText($"{SavePath}{fileName}.json")).OrderByDescending(o => o.PlayerScore).ToList();
			}
			return null;
		}
	}
}

