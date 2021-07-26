using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemies
{
	/// <summary>
	/// Класс Кубанойд, самый злой монстр в игре.
	/// </summary>
	[RequireComponent(typeof(NavMeshAgent))]
	public class Cubanoid : MonoBehaviour
	{
		[SerializeField] private List<GameObject> moveList;
		private NavMeshAgent _agent;
		public event EventHandler OnCubanoidDied = delegate { };

		private void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			if (!_agent.hasPath)
			{
				_agent.SetDestination(GetRandomPosition());
			}
		}
		/// <summary>
		/// Метод для получения одной из точек, в массиве точек передвижения Кубанойда.
		/// </summary>
		/// <returns>Ссылка на случайную точку</returns>
		public Vector3 GetRandomPosition() =>
			moveList[Random.Range(0, moveList.Count)].transform.position;

		private void OnDisable()
		{
			OnCubanoidDied.Invoke(this, EventArgs.Empty);
		}
	}
}
