using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<GameObject> playerObjects = new List<GameObject>();
    public List<Player> players = new List<Player>();
    public bool stop = false;
    public GameObject UI;
    public Text appleC;
    public Text SizeC;
    public int appleCount;
    public int sizeCount;
    public GameObject apple;
    public GameObject CountGroup;
    public bool appleHave;
    public GameObject greenBlock;
    public GameObject moreGreenBlock;
    public GameObject wallBlock;
    public int appleBool;
    public GameObject player;
    public int playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        Get();
        Test1();
        CreateObject();
        SetPlayerNum();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            Stop();
            
        }

        SetText();
        AlwayesSet();

        if (appleBool == 2)
        {
            CreateWall();
            Test2();

            appleBool = 0;
        }
    }

    public void Get()
    {
        for (int i = 0; i < playerObjects.Count; i++)
        {
            players.Add(playerObjects[i].GetComponent<Player>());
        }

    }

    public void Stop()
    {
        UI.gameObject.SetActive(true);
        CountGroup.gameObject.SetActive(false);
    }

    public void SetText()
    {
        appleC.text = appleCount.ToString();
        SizeC.text = sizeCount.ToString();
    }

    public void SetApple()
    {
        GameObject g = Instantiate(apple, new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11)), Quaternion.identity);
        Debug.Log(g.transform.position);

    }

    public void AlwayesSet()
    {
        if (appleHave == true)
        {
            return;
        }
        else
        {
            SetApple();
            appleHave = true;
            appleBool += 1;
        }
    }

    public void Test1()
    {
        float num1 = 2.5f;
        num1 = Mathf.Round(num1);
        Debug.Log(num1);
    }


    public void CreateObject()
    {
        int row = 11;
        int column = 11;

        for (int j = -10; j < row; j++)
        {
            for (int i = -10; i < column; i++)
            {
                if (i % 2 == 0 || j % 2 == 0)
                {
                    GameObject obj = Instantiate(greenBlock, new Vector3(j, 0, i), Quaternion.identity);
                }
                else
                {
                    GameObject obj = Instantiate(moreGreenBlock, new Vector3(j, 0, i), Quaternion.identity);
                }


            }

        }
    }

    public void CreateWall()
    {
        if (appleBool == 2)
        {
            GameObject g = Instantiate(wallBlock, new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11)), Quaternion.identity);
            Debug.Log("puted wall");
        }
        else
        {
            return;
        }
    }

    public void SetPlayer()
    {
        var item = players[players.Count - 1];
        GameObject p = item.gameObject;
        Player _p = p.GetComponent<Player>();
        Vector3 vec = p.transform.position;


        if (appleBool == 2)
        {
            Debug.Log("a");

            if (_p.playerMode == 1)//front
            {
                SetPlayerObj(player, vec.x, 1, vec.z - 1);
            }
            if (_p.playerMode == 3)//back
            {
                SetPlayerObj(player, vec.x, 1, vec.z + 1);
            }
            if (_p.playerMode == 2)//right
            {
                SetPlayerObj(player, vec.x - 1, 1, vec.z);
            }
            if (_p.playerMode == 4)//left
            {
                SetPlayerObj(player, vec.x + 1, 1, vec.z);
            }
            else
            {
                Debug.Log("bad");
            }
        }
    }

    public void SetPlayerObj(GameObject obj, float x, float y, float z)
    {
        GameObject g = Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
        players.Add(g.GetComponent<Player>());

    }

    public void Test2()
    {
        if (appleBool == 2)
        {
            Debug.Log('a');
        }
    }

    public void Test3()
    {

    }

    public void SetPlayerNum()
    {
        for (int i = 0; i <= players.Count; i++)
        {
            players[i].playerNumber = i;
        }
    }

    public void SetAllPlayer()
    {
        for (int i = 0; i <= players.Count; i++)
        {
            if (i != 0)
            {
                Vector3 vec = players[i - 1].gameObject.transform.position;
                Player _p = players[i - 1];

                if (_p.playerMode == 1)//front
                {
                    players[i].gameObject.transform.position = new Vector3 (vec.x, 1, vec.z - 1);
                }
                if (_p.playerMode == 3)//back
                {
                    players[i].gameObject.transform.position = new Vector3(vec.x, 1, vec.z + 1);
                }
                if (_p.playerMode == 2)//right
                {
                    players[i].gameObject.transform.position = new Vector3(vec.x - 1, 1, vec.z);
                }
                if (_p.playerMode == 4)//left
                {
                    players[i].gameObject.transform.position = new Vector3(vec.x + 1, 1, vec.z);
                }
            }
            else
            {
                return;
            }
        }
    }

    public void SetOtherObject()
    {
        for (int i = 0; i <= players.Count; i++)
        {
            if(i != 0)
            {
                Vector3 vec = players[i - 1].gameObject.transform.position;
                Player _p = players[i - 1];
                players[i].gameObject.transform.position = vec;
            }
        }
    }
}
