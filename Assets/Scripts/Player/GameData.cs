using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс сохраняющий в себе данные о скорости передвижения персонажа и чувствительности камеры
	/// </summary>

	[CreateAssetMenu(menuName = "Game Data", fileName = "Game Data")]
	public class GameData : ScriptableObject
	{
		[SerializeField] private float movementSpeed;
		[SerializeField] private float mouseSensitivity;
		public float MovementSpeed => movementSpeed;
		public float MouseSensitivity => mouseSensitivity;

	}
}
