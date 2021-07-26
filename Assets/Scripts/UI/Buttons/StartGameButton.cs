using Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
	/// <summary>
	/// Кнопка Start Game
	/// </summary>
	public class StartGameButton : BaseButton, IPointerEnterHandler, IPointerExitHandler
	{
		private TextMeshProUGUI _textMesh;
		private readonly Color _enableColor = new Color(1f, 0f, 0f);
		private readonly Color _disableColor = new Color(0.482f, 0f, 0f);
		private string _playerName;
		private void Start()
		{
			_textMesh = Button.GetComponent<TextMeshProUGUI>();
			Button.enabled = false;
			_textMesh.color = _disableColor;
		}

		protected override void OnButtonClicked()
		{
			PlayerPrefs.SetString("CurrentPlayer", _playerName.ToLower());
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (Button.enabled)
				transform.localScale = new Vector3(1.3f, 1.3f);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (Button.enabled)
				transform.localScale = new Vector3(1f, 1f);
		}

		public void ButtonEnable(string text)
		{
			if (string.IsNullOrEmpty(text))
				return;
			Button.enabled = true;
			_textMesh.color = _enableColor;
			_playerName = text;
		}
		public void ButtonDisable(string text)
		{
			if (!string.IsNullOrEmpty(text))
				return;
			Button.enabled = false;
			_textMesh.color = _disableColor;
		}
	}
}
