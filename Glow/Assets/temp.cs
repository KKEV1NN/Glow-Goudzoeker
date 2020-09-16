using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<Vote>()._vote("A");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.GetComponent<Vote>()._vote("B");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            gameObject.GetComponent<Vote>()._vote("C");
        }
    }
}
