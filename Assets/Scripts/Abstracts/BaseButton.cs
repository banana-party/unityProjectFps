using UnityEngine;
using UnityEngine.UI;

namespace Abstracts
{
	/// <summary>
	/// Базовый класс для создания скрипта кнопки
	/// </summary>
	[RequireComponent(typeof(Button))]
	public abstract class BaseButton : MonoBehaviour
	{
		protected Button Button;

		protected virtual void Awake()
		{
			Button = GetComponent<Button>();
		}

		protected virtual void OnEnable()
		{
			Button.onClick.AddListener(OnButtonClicked);
		}

		protected virtual void OnDisable()
		{
			Button.onClick.RemoveListener(OnButtonClicked);
		}
		/// <summary>
		/// On Clicked
		/// </summary>
		protected abstract void OnButtonClicked();
	}
}
