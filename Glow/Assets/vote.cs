using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vote : MonoBehaviour
{
    public bool isCounting;
    public float timer = 100;
    List<string> votes = new List<string>();
    void Start()
    {
        if (votes.Count > 0)
            votes.Clear();
    }

    private void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if(timer < 0)
        {
			Sort();
            Debug.Log("cast votes");
        }
    }

    public void Voted(string s)
    {
        votes.Add(s);
    }

    private void Sort()
    {
    }

}
