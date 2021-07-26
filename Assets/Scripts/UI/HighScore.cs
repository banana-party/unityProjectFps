using TMPro;
using UnityEngine;

namespace UI
{
	/// <summary>
	/// Класс для отображения HighScore в главном меню. Кажется, больше не нужен
	/// </summary>
	public class HighScore : MonoBehaviour
	{
		private TextMeshProUGUI _highScore;
		void Start()
		{
			_highScore = GetComponent<TextMeshProUGUI>();
			_highScore.text += $" {PlayerPrefs.GetInt("HighScore", 0)}";
		}
	}
}
