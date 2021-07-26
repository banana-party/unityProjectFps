using System;
using System.Collections;
using Abstracts;
using UnityEngine;

namespace Controllers
{
	/// <summary>
	/// Класс отвечаюший за таймер, который запускается в начале игры.
	/// </summary>
	public class TimerController : MonoBehaviour, ITimerController
	{
		[SerializeField] private int secondsTime;
		private Coroutine _timerCoroutine;

		public string FormattedSecondsTime => FormatTime(secondsTime);
		public Action onTimerStarted { get; set; } = delegate { };
		public Action<string> onTimerChanged { get; set; } = delegate { };
		public Action onTimerEnded { get; set; } = delegate { };
		public bool IsTimeEnded { get; private set; }

		private void Start()
		{
			IsTimeEnded = false;
			if (_timerCoroutine != null)
			{
				StopCoroutine(_timerCoroutine);
			}
			_timerCoroutine = StartCoroutine(TimerCoRoutine());
		}

		private IEnumerator TimerCoRoutine()
		{
			onTimerStarted.Invoke();
			int seconds = secondsTime;
			while (seconds > 0)
			{
				onTimerChanged.Invoke(FormatTime(seconds));
				yield return new WaitForSeconds(1.0f);
				seconds -= 1;
			}
			onTimerEnded.Invoke();
			IsTimeEnded = true;
		}

		private string FormatTime(int time) =>
			TimeSpan.FromSeconds(time).ToString();

	}
}