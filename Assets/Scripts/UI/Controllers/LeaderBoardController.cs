using System.Collections.Generic;
using System.Linq;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controllers
{
	/// <summary>
	/// Контроллер для вывода LeaderBoard из Json
	/// </summary>
	public class LeaderBoardController : MonoBehaviour
	{
		[SerializeField] private Transform template;
		private Transform _container;

		private void Awake()
		{
			_container = GetComponent<VerticalLayoutGroup>().transform;
			template.gameObject.SetActive(false);

			SaveController.Init();
			var leaderBoard = SaveController.Load("LeaderBoard");
			if (leaderBoard == null)
				return;
			for (int i = 0; i < 8; i++)
			{
				if (i >= leaderBoard.Count())
					break;
				Transform entryTransform = Instantiate(template, _container);
				RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
				entryRectTransform.anchoredPosition = new Vector2(0, -100 * i);
				entryTransform.gameObject.SetActive(true);

				entryTransform.GetChild(0).GetComponent<Text>().text = $"{i + 1}";
				entryTransform.GetChild(1).GetComponent<Text>().text = $"{leaderBoard.ElementAt(i).PlayerName}";
				entryTransform.GetChild(2).GetComponent<Text>().text = $"{leaderBoard.ElementAt(i).PlayerScore}";
				entryTransform.GetChild(3).GetComponent<Text>().text = $"{leaderBoard.ElementAt(i).PlayerTime}";
			}
		}
	}


}
