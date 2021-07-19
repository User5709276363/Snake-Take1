using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber = 1;

    public float time = 1f;

    public float speed;

    public Manager m;

    public int playerMode = 1; //1:front  2:right  3:back  4:left


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Call005", 0.1f ,0.1f);
        m = FindObjectOfType<Manager>();
        speed = 0.1f;
    }


    void Call005()//0.05s 1run
    {
        if(m.stop == true)
        {
            return;
        }
        else
        {
           transform.Translate(0, 0, speed);
            m.SetOtherObject();
        }
    }

    private void FixedUpdate()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Invoke("Wkey", playerNumber);
        }

        if (Input.GetKeyDown("s"))
        {
            Invoke("Skey", playerNumber);
        }

        if (Input.GetKeyDown("a"))
        {
            Invoke("Akey", playerNumber);
        }

        if (Input.GetKeyDown("d"))
        {
            Invoke("Dkey", playerNumber);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Destroy(other.gameObject);
            m.appleCount += 1;
            m.appleHave = false;
        }
    }

    public void NumWillGood()
    {
        Vector3 obj = this.gameObject.transform.position;
        
        obj.x = Mathf.Round(obj.x);
        obj.z = Mathf.Round(obj.z);
        float x = obj.x;
        float y = obj.y;
        float z = obj.z;
        this.gameObject.transform.position = new Vector3(x, y, z);
    }

    void Wkey()
    {
        transform.eulerAngles = (new Vector3(0, 0, 0));
        NumWillGood();
        playerMode = 1;
    }

    void Skey()
    {
        transform.eulerAngles = (new Vector3(0, -180, 0));
        NumWillGood();
        playerMode = 3;
    }

    void Dkey()
    {
        transform.eulerAngles = (new Vector3(0, 90, 0));
        NumWillGood();
        playerMode = 2;
    }

    void Akey()
    {
        transform.eulerAngles = (new Vector3(0, -90, 0));
        NumWillGood();
        playerMode = 4;
    }

    
}
