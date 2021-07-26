using System;
using Abstracts;
using UI;
using UnityEngine;

namespace Enemies
{
	/// <summary>
	/// Класс отвечаюший за возможность получать урон.
	/// </summary>
	public class Shootable : AbstractEnemy
	{
		[SerializeField] private EnemyData enemyData;
		private Scores _scores;
		private int _currentHealth;
		private Action<int> _takeDamage = delegate { };


		private void OnEnable()
		{
			_scores = FindObjectOfType<Scores>();
			_takeDamage += _scores.Destroyed;
		}

		private void Start()
		{
			Heal();
		}

		public override void TakeDamage(int damage)
		{
			_currentHealth -= damage;
			if (_currentHealth <= 0)
			{
				_takeDamage.Invoke(enemyData.ScorePoints);
				Die();
			}
		}

		public void Heal()
		{
			_currentHealth = enemyData.HealthPoints;
		}
		private void Die()
		{
			gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			_takeDamage -= _scores.Destroyed;
		}

	}
}
