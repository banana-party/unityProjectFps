using Abstracts;
using UI.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
	/// <summary>
	/// Кнопка в меню для отображения LeaderBoard
	/// </summary>
	public class LeaderBoardButton : BaseButton, IPointerEnterHandler, IPointerExitHandler
	{
		private MainMenuController _menuController;
		private void Start()
		{
			_menuController = FindObjectOfType<MainMenuController>();
		}

		protected override void OnButtonClicked()
		{
			_menuController.ShowLeaderboard();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			transform.localScale = new Vector3(1.3f, 1.3f);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			transform.localScale = new Vector3(1f, 1f);
		}

	}
}
