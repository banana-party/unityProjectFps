using Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
	/// <summary>
	/// Класс отвечаюший за отображение таймера
	/// </summary>
	public class TimerView : MonoBehaviour
	{
		[SerializeField] private GameObject timerController;
		[SerializeField] private GameObject gameOverScreen;
		ITimerController _timerController;
		Text _levelTime;
		Text _gameOver;

		private void Start()
		{
			_timerController = timerController.GetComponent<ITimerController>();
			_timerController.onTimerStarted += OnTimerStarted;
			_timerController.onTimerChanged += OnTimerChanged;
			_timerController.onTimerEnded += OnTimerEnded;
			_levelTime = GetComponent<Text>();
			_gameOver = gameOverScreen.GetComponent<Text>();
		}
		private void OnTimerStarted()
		{
			_levelTime.gameObject.SetActive(true);
		}

		private void OnTimerChanged(string inputTime)
		{
			_levelTime.text = inputTime;
		}
		private void OnTimerEnded()
		{
			_levelTime.gameObject.SetActive(false);
			_gameOver.gameObject.SetActive(true);
		}
		private void OnDestroy()
		{
			_timerController.onTimerStarted -= OnTimerStarted;
			_timerController.onTimerChanged -= OnTimerChanged;
			_timerController.onTimerEnded -= OnTimerEnded;
		}
	}
}
