using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Класс для заполнения полоски загрузки.
	/// </summary>
	[RequireComponent(typeof(Image))]
	public class ProgressBar : MonoBehaviour
	{
		private Image _progressBar;
		private Coroutine _coroutine;
		private static int _levelIndex; // TODO: Статичное поле, а значит необходимо вынести загрузку уровней в отдельный статичный класс.
		private void Start()
		{
			_progressBar = GetComponent<Image>();
			if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
			}
			_levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
			_coroutine = StartCoroutine(LoadNextSceneAsync());
		}
		IEnumerator LoadNextSceneAsync()
		{
			_progressBar.fillAmount = 0f;
			AsyncOperation loading = SceneManager.LoadSceneAsync(_levelIndex++);
			while (loading.progress < 1)
			{
				_progressBar.fillAmount = loading.progress;
				yield return new WaitForEndOfFrame();
			}
		}
	}
}
