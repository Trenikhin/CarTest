namespace Game.Triggers
{
	using Core;
	using UnityEngine;

	/// <summary>
	/// // Need to activate / deactivate finish trigger to avoid bad behaviour
	/// </summary>
	public class FinishActivator : MonoBehaviour
	{
		[SerializeField] FinishTrigger _finishTrigger;
		[SerializeField] bool _activate;
		
		void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Car _))
			{
				_finishTrigger.gameObject.SetActive(_activate);
			}
		}
	}
}