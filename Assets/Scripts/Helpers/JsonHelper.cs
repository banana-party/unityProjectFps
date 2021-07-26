using System;
using UnityEngine;

namespace Helpers
{
	/// <summary>
	/// Класс-хелпер для парсинга массива в Json строку и обратно
	/// </summary>
	public static class JsonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
			return wrapper.Items;
		}

		public static string ToJson<T>(T[] array)
		{
			Wrapper<T> wrapper = new Wrapper<T> { Items = array };
			return JsonUtility.ToJson(wrapper);
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			Wrapper<T> wrapper = new Wrapper<T> { Items = array };
			return JsonUtility.ToJson(wrapper, prettyPrint);

		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}
	}
}
