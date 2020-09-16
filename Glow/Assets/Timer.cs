using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	List<string> votes = new List<string>();

	void Start()
	{
		if (votes.Count > 0)
			votes.Clear();
	}

	private void Update()
	{
	}

	public void Voted(string s)
	{
		votes.Add(s);
	}
	public IEnumerator Count( // temp 
	float targetTime,
	System.Action<float> receiveTimeElapsed = null,
	System.Func<bool> actionCondition = null,
    System.Action conditionalAction = null,
    System.Action onCountStart = null,
    System.Action onCountEnd = null)
    {
        onCountStart?.Invoke();

		float timeElapsed = 0f;
		receiveTimeElapsed?.Invoke(timeElapsed);

		while (timeElapsed < targetTime)
		{
			if (actionCondition != null && actionCondition.Invoke())
				conditionalAction?.Invoke();

			yield return null;

			timeElapsed += Time.deltaTime;

			receiveTimeElapsed?.Invoke(timeElapsed);
		}

		if (actionCondition != null && actionCondition.Invoke())
			conditionalAction?.Invoke();

		onCountEnd?.Invoke();
	}

	private float _timeElapsed;
	private int _count;

	private void Awake()
	{
		this.StartCoroutine(
			this.Count(
				5f,
				(timeElapsed) =>
				{
					this._timeElapsed = timeElapsed;
					Debug.Log("Time Elapsed: " + this._timeElapsed);
				},
				() => { return this._timeElapsed >= (this._count + 1); },
				() =>
				{
					this._count++;

					Debug.Log("Countdown: " + this._count);
				},
				() => { Debug.Log("Countdown: " + this._count); },
				() => {
					Debug.Log("On countdown end");
					// 
				}
			)
		);
	}
}
