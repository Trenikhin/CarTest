namespace Game.Core
{
	using System.Collections.Generic;
	using UnityEngine;

	// Player car follower
	public class CarAi : MonoBehaviour
	{
		int _pointIndex = 0;
		float _speed;
		
		List<(Vector3 pos, Quaternion rotation)> _path = new List<(Vector3 pos, Quaternion rotation)>();

		public void Setup( PathSaver path, float speed )
		{
			_path = new List<(Vector3 pos, Quaternion rotation)>(path);
			_pointIndex = 0;
			_speed = speed;
		}

		void Update()
		{
			FollowPath();
		}

		void FollowPath()
		{
			if (_pointIndex < _path.Count)
			{
				var point = _path[_pointIndex];
				
				transform.position = Vector3.Lerp(transform.position, point.pos, _speed * Time.deltaTime);
				
				Quaternion targetRotation = Quaternion.Euler(point.rotation.eulerAngles);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
				
				if (Vector3.Distance(transform.position, point.pos) < 0.1f)
				{
					_pointIndex++;
				}
			}
		}
	}
}