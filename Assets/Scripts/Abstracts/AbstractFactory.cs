using UnityEngine;

namespace Abstracts
{
	/// <summary>
	/// Класс, реализующий фабричный метод.
	/// </summary>
	public abstract class AbstractFactory : MonoBehaviour
	{
		/// <summary>
		/// Метод спавнящий врага, наследующего AbstractEnemy
		/// </summary>
		/// <para>Принимает ссылку на врага, его позицию и вращение</para>
		/// <returns>Ссылку на экземпляр врага</returns>
		public abstract AbstractEnemy Spawn(AbstractEnemy enemy, Vector3 position, Quaternion rotation);
	}
}
