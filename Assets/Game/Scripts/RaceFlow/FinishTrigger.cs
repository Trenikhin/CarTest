namespace Game.Triggers
{
	using Core;
	using UniRx;
	using UnityEngine;

	/// <summary>
	/// Place this on finish
	/// </summary>
	public class FinishTrigger : MonoBehaviour
	{
		public readonly ReactiveCommand OnFinish = new ReactiveCommand();
		
		void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Car car))
				OnFinish.Execute();
		}
	}
}