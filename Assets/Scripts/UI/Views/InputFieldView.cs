using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Класс отвечающий за соединение логики кнопки "Start Game" и InputField'a
	/// </summary>
	[RequireComponent(typeof(InputField))]
	public class InputFieldView : MonoBehaviour
	{
		private InputField _input;
		private StartGameButton _button;

		private void Awake()
		{
			_input = GetComponent<InputField>();
			_button = FindObjectOfType<StartGameButton>();
		}
		protected virtual void OnEnable()
		{
			_input.onValueChanged.AddListener(_button.ButtonEnable);
			_input.onValueChanged.AddListener(_button.ButtonDisable);
		}

		protected virtual void OnDisable()
		{
			_input.onValueChanged.RemoveListener(_button.ButtonEnable);
			_input.onValueChanged.RemoveListener(_button.ButtonDisable);
		}
	}
}
