using System.Collections.Generic;
using System.Linq;
using Controllers;
using TMPro;
using UnityEngine;

namespace UI
{
	/// <summary>
	/// Класс отвечаюший за подсчет целей в канвасе сверху 
	/// </summary>
	public class Scores : MonoBehaviour
	{
		private TextMeshProUGUI _counter;
		private int _count;
		private TimerController _timer;

		private void Awake()
		{
			_timer = FindObjectOfType<TimerController>();
			_timer.onTimerEnded += SaveScore;
		}

		void Start()
		{
			_count = 0;
			_counter = GetComponent<TextMeshProUGUI>();
			_counter.text = _count.ToString();
		}
		/// <summary>
		/// Метод, при вызове которого, количество очков увеличивается на заданное значение
		/// </summary>
		public void Destroyed(int score)
		{
			_count += score;
			_counter.text = _count.ToString();
		}

		private void OnDisable()
		{
			_timer.onTimerEnded -= SaveScore;
			if (!_timer.IsTimeEnded)
				SaveScore();
		}
		/// <summary>
		/// Запись полученных очков в HighScore
		/// </summary>
		private void SaveScore()
		{
			SaveController.Init();
			var arr = SaveController.Load("LeaderBoard");
			if (arr != null)
			{
				var lst = arr.ToList();
				lst.Insert(0,
					new
						LeaderBoardValues // Insert, вместо Add, потому что при выгрузке список сортируется, так что, минимальное значение будет самым последним
					{
						PlayerName = PlayerPrefs.GetString("CurrentPlayer"),
						PlayerScore = _count,
						PlayerTime = _timer.FormattedSecondsTime
					}
					);
				if (lst.Count > 8) // 8 - максимальное вхождение значений в LeaderBoard
					lst.RemoveRange(8, lst.Count - 8);
				SaveController.Save("LeaderBoard", lst.ToArray());
			}
			else
			{
				arr = new List<LeaderBoardValues>
				{
						new
						LeaderBoardValues
						{
							PlayerName = PlayerPrefs.GetString("CurrentPlayer"),
							PlayerScore = _count,
							PlayerTime = _timer.FormattedSecondsTime
						}
				};
				SaveController.Save("LeaderBoard", arr.ToArray());
			}
		}
	}
}
