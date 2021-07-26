using System;

namespace Abstracts
{
	/// <summary>
	/// Интерфейс для контроллера выстрелов
	/// </summary>
	public interface IGunBulletsController
	{

		/// <summary>
		/// Максимальное количество пуль у персонажа
		/// </summary>
		int MaxBullets { get; set; }

		/// <summary>
		/// Фактическое количество пуль в обойме
		/// </summary>
		int CurrentBulletsInClip { get; set; }

		/// <summary>
		/// Событие на изменение количества пуль в обойме
		/// </summary>
		Action<int> onBulletsChanged { get; set; }

		/// <summary>
		/// Событие на изменение количества пуль в обойме и у персонажа
		/// </summary>
		Action<string> onBulletsRefreshed { get; set; }
	}
}
