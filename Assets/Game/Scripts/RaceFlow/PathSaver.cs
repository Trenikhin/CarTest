namespace Game.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	
	public class PathSaver : MonoBehaviour, IEnumerable<(Vector3 pos, Quaternion rotation)>
	{
		[SerializeField] Transform _target;
		[SerializeField] GameObject _test;
		
		List< (Vector3 pos, Quaternion rotation) > _path = new List<(Vector3, Quaternion)>();
		
		public void FixedUpdate()
		{
			_path.Add( (_target.position, _target.rotation) );
		}

		public void RefreshPath()
		{
			_path.Clear();
		}

		public IEnumerator<(Vector3 pos, Quaternion rotation)> GetEnumerator()
		{
			foreach (var point in _path)
				yield return ((point.pos, point.rotation));
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}