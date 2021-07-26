using Abstracts;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
	/// <summary>
	/// Класс отвечающий за нажатие кнопки "главное меню" во время паузы.
	/// </summary>
	public class MainMenuButton : BaseButton
	{
		protected override void OnButtonClicked()
		{
			SceneManager.LoadScene(0);
		}
	}
}
