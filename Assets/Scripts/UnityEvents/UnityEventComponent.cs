using UnityEngine;
using UnityEngine.Events;

namespace UnityDoodats.UnityEvents
{
	/// <summary>
	/// Standalone unity event component for chaining UnityEvents
	/// </summary>
	public class UnityEventComponent : MonoBehaviour
	{
		[Header("Call Invoke() from another UnityEvent")]
		public UnityEvent OnEvent;

		public void Invoke () { OnEvent.Invoke(); }
	}
}
