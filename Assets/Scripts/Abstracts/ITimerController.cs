using System;

namespace Abstracts
{
	/// <summary>
	/// Интерфейс, отвечающий за реализацию таймера
	/// </summary>
	public interface ITimerController
	{
		Action onTimerStarted { get; set; }
		Action<string> onTimerChanged { get; set; }
		Action onTimerEnded { get; set; }
	}
}
