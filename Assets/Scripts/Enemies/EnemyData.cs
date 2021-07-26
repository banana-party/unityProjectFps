using UnityEngine;

namespace Enemies
{
	/// <summary>
	/// Класс сохраняющий в себе данные о жизнях и очках за убийство врага
	/// </summary>
	[CreateAssetMenu(menuName = "Enemy Data", fileName = "Enemy Data")]
	public class EnemyData : ScriptableObject
	{
		[SerializeField] private int healthPoints;
		[SerializeField] private int scorePoints;
		public int HealthPoints => healthPoints;
		public int ScorePoints => scorePoints;
	}
}
