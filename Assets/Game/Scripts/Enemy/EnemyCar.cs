namespace Game.Core
{
	using UnityEngine;

	// Enemy Car facade
	public class EnemyCar : MonoBehaviour
	{
		[field: SerializeField] public CarAi Ai { get; set; }
	}
}