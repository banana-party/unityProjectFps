using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Spawners
{
	/// <summary>
	/// Класс-спавнер Кубанойдов, после их смерти
	/// </summary>
	[RequireComponent(typeof(FactoryPoolingSpawner))]
	public class CubanoidSpawner : MonoBehaviour
	{
		[SerializeField] private List<Cubanoid> cubanoids;
		[SerializeField] private float respawnTime = 3f;
		private Coroutine _spawnCoroutine;

		void Start()
		{
			if (_spawnCoroutine != null)
			{
				StopCoroutine(_spawnCoroutine);
			}

			foreach (var cooba in cubanoids)
			{
				cooba.OnCubanoidDied += OnCubanoidDied;
			}
		}

		private void OnCubanoidDied(object sender, EventArgs e)
		{
			_spawnCoroutine = StartCoroutine(Respawn(sender as Cubanoid));
		}

		IEnumerator Respawn(Cubanoid cooba)
		{
			yield return new WaitForSeconds(respawnTime);
			cooba.gameObject.SetActive(true);
			cooba.transform.position = cooba.GetRandomPosition();
			cooba.GetComponent<Shootable>().Heal();
		}

		private void OnDisable()
		{
			foreach (var cooba in cubanoids)
			{
				cooba.OnCubanoidDied -= OnCubanoidDied;
			}
		}
	}
}
