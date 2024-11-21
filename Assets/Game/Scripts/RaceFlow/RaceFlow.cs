namespace Game.Core
{
	using Triggers;
	using UniRx;
	using UnityEngine;

	public class RaceFlow : MonoBehaviour
	{
		[SerializeField] FinishTrigger _finishTrigger;
		[SerializeField] PathSaver _pathSaver;
		
		ReactiveProperty<int> _raceCount = new ReactiveProperty<int>(0);
		
		public IReadOnlyReactiveProperty<int> RaceCount => _raceCount;
		
		public readonly ReactiveCommand OnRaceFinished = new ReactiveCommand();
		public readonly ReactiveCommand OnRaceStarted = new ReactiveCommand();
		
		
		void Start()
		{
			StartRace();
			
			_finishTrigger.OnFinish
				.Subscribe( _ =>
				{
					FinishRace();
					StartRace();
				})
				.AddTo(this);
		}
		
		void StartRace()
		{
			_raceCount.Value++;
			OnRaceStarted.Execute();
			_pathSaver.enabled = true;
		}

		void FinishRace()
		{
			_pathSaver.enabled = false;
			OnRaceFinished?.Execute();
		}
	}
}