using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Vote : MonoBehaviour
{
	public bool isCounting;
	public float timer = 10;
	List<string> votes = new List<string>();

	public Text aCount;
	public Text bCount;
	public Text cCount;

	public int A;
	public int B;
	public int C;

	private void Update()
	{
		// Debug.Log(timer);
		timer -= Time.deltaTime;
		

		if (timer < 0)
		{
			Sort();
			CheckHighest();
			Debug.Log("cast votes");
		}
	}

	public void _vote(string s)
	{
		votes.Add(s);
	}

	private void CheckHighest()
	{
		int mostvotes = A;
		if (B > mostvotes)
		{
			mostvotes = B;

			// do animation b 
			Debug.Log("animation B");
		}
		if (C > mostvotes)
		{
			mostvotes = C;

			Debug.Log("animation C");
			// do animation c
		}
		else
		{
			Debug.Log("animation A");
			//do animation A
		}

		// if (D > mostvotes){ mostvotes = D; // do animation D } 
		A = 0;
		B = 0;
		C = 0;
	}

	private void Sort()
	{
		foreach (string word in votes)
		{
			if (word == "A")
				A += 1;
				
			aCount.text = A.ToString();
			if (word == "B")
				B += 1;
				
			bCount.text = B.ToString();
			if (word == "C")
				C += 1;
				
			cCount.text = C.ToString();
		}

		timer = 10;
		if (votes.Count > 0)
			votes.Clear();
	}

}
