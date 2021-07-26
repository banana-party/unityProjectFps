using UnityEngine;

namespace UI.Controllers
{
	/// <summary>
	/// Контроллер для отображения частей главного меню
	/// </summary>
	public class MainMenuController : MonoBehaviour
	{
		[SerializeField] private GameObject menuCanvas;
		[SerializeField] private GameObject leaderboardCanvas;

		private void Start()
		{
			ShowMenu();
		}

		public void ShowLeaderboard()
		{
			menuCanvas.SetActive(false);
			leaderboardCanvas.SetActive(true);
		}
		public void ShowMenu()
		{
			menuCanvas.SetActive(true);
			leaderboardCanvas.SetActive(false);
		}
	}
}
