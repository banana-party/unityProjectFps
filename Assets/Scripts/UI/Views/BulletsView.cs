using Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
	/// <summary>
	/// Класс, для отображения количества оставшихся пуль на экране
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class BulletsView : MonoBehaviour
	{
		[SerializeField] GameObject bulletControllerGO;
		private IGunBulletsController _bulletController;
		Text text;

		void Start()
		{
			text = GetComponent<Text>();
			_bulletController = bulletControllerGO.GetComponent<IGunBulletsController>();
			_bulletController.onBulletsChanged += RefreshClipAmmo;
			_bulletController.onBulletsRefreshed += RefreshAmmo;
			RefreshAmmo();
		}

		void OnDisable()
		{
			_bulletController.onBulletsChanged -= RefreshClipAmmo;
			_bulletController.onBulletsRefreshed -= RefreshAmmo;
		}

		void RefreshClipAmmo(int clipAmmo)
		{
			text.text = $"{clipAmmo}/{_bulletController.MaxBullets}";
		}

		void RefreshAmmo()
		{
			text.text = $"{_bulletController.CurrentBulletsInClip}/{_bulletController.MaxBullets}";
		}

		void RefreshAmmo(string ammo)
		{
			text.text = ammo;
		}
	}
}
