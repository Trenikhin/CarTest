namespace Game.Core
{
	using UniRx;
	using UnityEngine;

	public class EnemyManager : MonoBehaviour
	{
		[Header("Enemy Settings")]
		[SerializeField] float _speed = 100;
		[SerializeField] float _lapAcceleration;
		
		[Header("Usages")]
		[SerializeField] RaceFlow _raceFlow;
		[SerializeField] EnemyCar _enemyCar;
		[SerializeField] PathSaver _pathSaver;
		[SerializeField] Car _target;
		
		void Start()
		{
			_raceFlow
				.OnRaceStarted
				.Where( _ => _raceFlow.RaceCount.Value > 1 )
				.Subscribe( _ => SpawnEnemy() )
				.AddTo(this);
		}

		void SpawnEnemy()
		{
			_enemyCar.Ai.Setup( _pathSaver, _speed + (_lapAcceleration * _raceFlow.RaceCount.Value) );
			_enemyCar.gameObject.SetActive(true);
			_pathSaver.RefreshPath();
		}
	}
}