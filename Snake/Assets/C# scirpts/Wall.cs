using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Manager m;
    // Start is called before the first frame update
    void Start()
    {

        m = FindObjectOfType<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m.stop = true;
            Debug.Log("y");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
