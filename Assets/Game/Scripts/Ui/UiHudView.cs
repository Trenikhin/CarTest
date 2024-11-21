namespace Game.Ui
{
	using System;
	using TMPro;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;

	public class UiHudView : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI _raceCountText;
		[SerializeField] Button _restartButton;

		public IObservable<Unit> OnRestartButtonClicked => _restartButton.OnClickAsObservable();
		
		public void SetRaceCount(string raceCount) => _raceCountText.text = raceCount;
	}
}