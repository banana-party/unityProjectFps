using System;
using Abstracts;
using UnityEngine;

namespace Controllers
{
	/// <summary>
	/// Класс, являющийся контроллером для подсчета количества пуль у персонажа
	/// </summary>
	public class GunBulletsController : MonoBehaviour, IGunBulletsController
	{
		[SerializeField] private int maxBullets = 16;
		[SerializeField] private int maxBulletsInClip = 8;
		public bool IsEmpty { get; private set; } // Возможно, это лишнее свойсво
		public int MaxBullets { get => maxBullets; set { } }
		public int CurrentBulletsInClip { get; set; }
		public Action<int> onBulletsChanged { get; set; } = delegate { };
		public Action<string> onBulletsRefreshed { get; set; } = delegate { };
		public Action onBulletsEnded { get; set; } = delegate { };

		private void Awake() //Используется Awake, т.к. Start этого скрипта срабатывал позже скрипта BulletsView из за чего отображалось 0 паторнов, когда фактически они были.
		{
			CurrentBulletsInClip = maxBulletsInClip;
			IsEmpty = false;
		}

		/// <summary>
		/// Метод, уменьшающий количества пуль при выстреле
		/// </summary>
		public void Shoot()
		{
			if (CurrentBulletsInClip <= 0)
			{
				onBulletsEnded.Invoke();
				return;
			}
			onBulletsChanged.Invoke(--CurrentBulletsInClip);
		}
		/// <summary>
		/// Метод, отвечающий за подсчет пуль при перезарядке
		/// </summary>
		public void Reload()
		{
			var tmp = maxBulletsInClip - CurrentBulletsInClip;
			if (maxBullets >= tmp)
			{
				maxBullets -= tmp;
				CurrentBulletsInClip += tmp;
			}
			else
			{
				CurrentBulletsInClip += maxBullets;
				maxBullets = 0;
				IsEmpty = true;
			}
			onBulletsRefreshed.Invoke($"{CurrentBulletsInClip}/{MaxBullets}");
		}
	}
}
