
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public List<GameObject> enemiesActive = new List<GameObject>();
    public GameObject spawn;
    public Vector3 Spawnpos;

    private float[] Summons = { 10, 20, 0, 0 } ;
    private float wave;
    private int ronde = 1;
    public enum difficulty { easy, normal, hard, impossible };
    public static difficulty diff = difficulty.easy;
    public float random = 0;
    private float interval = 0;
 

    void Start()
    {
        Spawnpos = spawn.transform.position;
        enemyHandler.MyDeathHandler += Died;
        InvokeRepeating("OnWave", 10f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

  


    }

    void Died()
    {
        Summons[3]++;

    }

    void Diff(difficulty pick)
    {
       
    }

    public void easybutton()
    {
        diff = difficulty.easy;
    }




    void OnWave()
    {
        if(Summons[1] > Summons[2])
        {
            if(Summons[0] > Summons[2])
            {
                enemiesActive.Add(Instantiate(enemyPrefabs[0], Spawnpos, transform.rotation, transform));
                Summons[2]++;
            }
            else
            {
                random = UnityEngine.Random.Range(1, 10);
                if (random > 5)
                {
                    enemiesActive.Add(Instantiate(enemyPrefabs[0], Spawnpos, transform.rotation, transform));
                   ;
                }
                Summons[2]++;



            }

        }


    }
}
