using UnityEngine;

namespace Abstracts
{
	/// <summary>
	/// Класс, реализующий общее свойство врагов - получать урон
	/// </summary>
	public abstract class AbstractEnemy : MonoBehaviour
	{
		/// <summary>
		/// Метод - получить урон
		/// </summary>
		/// <para>Урон в виде целого числа</para>
		public abstract void TakeDamage(int damage);
	}
}
