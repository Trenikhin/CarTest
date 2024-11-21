namespace Game.Ui
{
	using Core;
	using UniRx;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class HudPresenter : MonoBehaviour
	{
		[SerializeField] UiHudView _view;
		[SerializeField] RaceFlow _raceFlow;
		
		void Start()
		{
			// Update cur count
			_raceFlow.RaceCount
				.Subscribe( c => _view.SetRaceCount( $"Круг: {c}" ) )
				.AddTo(this);

			// Restart Game
			_view.OnRestartButtonClicked
				.Subscribe( _ => SceneManager.LoadScene( 0 ) )
				.AddTo(this);
		}
	}
}