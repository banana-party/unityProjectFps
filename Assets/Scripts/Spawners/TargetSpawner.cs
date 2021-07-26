using System.Collections;
using System.Collections.Generic;
using Abstracts;
using UnityEngine;

namespace Spawners
{
	/// <summary>
	/// Класс отвечаюший за спавн целей и содержание в себе точки их появления, конечной точки и их характеристик (скорость, задержка межу спавном)
	/// Использует FactoryPoolingSpawner
	/// </summary>
	[RequireComponent(typeof(FactoryPoolingSpawner))]
	public class TargetSpawner : MonoBehaviour
	{
		[SerializeField] private List<AbstractEnemy> enemies;
		[SerializeField] private GameObject spawnPoint;
		[SerializeField] private GameObject destroyPoint;
		[Range(1, 5)] [SerializeField] private float spawnDelay;
		[SerializeField] private float movementSpeed;
		private Coroutine _spawnCoroutine;

		public float TargetSpeed { get; private set; }
		public Vector3 DestroyPosition => destroyPoint.transform.position;
		private FactoryPoolingSpawner _poolingSpawner;

		void Start()
		{
			_poolingSpawner = GetComponent<FactoryPoolingSpawner>();
			if (_spawnCoroutine != null)
				StopCoroutine(_spawnCoroutine);
			TargetSpeed = movementSpeed * Time.fixedDeltaTime;
			_spawnCoroutine = StartCoroutine(Spawn());
		}

		private IEnumerator Spawn()
		{
			while (true)
			{
				float rand = Random.Range(-2.5f, 2.5f);
				var spawnPos = new Vector3
				{
					x = spawnPoint.transform.position.x,
					y = spawnPoint.transform.position.y + rand,
					z = spawnPoint.transform.position.z
				};
				_poolingSpawner.Spawn(enemies.Find(i => !i.gameObject.activeInHierarchy), spawnPos, Quaternion.identity);
				yield return new WaitForSeconds(spawnDelay);
			}
		}
	}
}