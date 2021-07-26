using Abstracts;
using UnityEngine;

namespace Spawners
{
	/// <summary>
	/// Класс, реализующий фабричный метод, спавнящий врагов с использованием системы пулинга
	/// </summary>
	public class FactoryPoolingSpawner : AbstractFactory
	{
		public override AbstractEnemy Spawn(AbstractEnemy enemy, Vector3 position, Quaternion rotation)
		{
			enemy.transform.position = position;
			enemy.transform.rotation = rotation;
			enemy.gameObject.SetActive(true);
			return enemy;
		}
	}
}
