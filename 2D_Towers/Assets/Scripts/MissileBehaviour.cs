using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject TowerActive;

    float startingTime;
    float travelTime;
    GameObject GameManager;
    TowerCounter CountingScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Tower")
        {
            CountingScript.NoumberOfTowers--;
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        CountingScript = GameManager.GetComponent<TowerCounter>();

        startingTime = Time.time;
        travelTime = Random.Range(.25f, 1f);
    }

    void Update()
    {
        if (Time.time > startingTime + travelTime)
        {
            if (!CountingScript.TowerMaxAmount)
            {
                Instantiate(TowerActive, transform.position, transform.rotation = new Quaternion(0f, 0f, 0f, 0f));
                CountingScript.NoumberOfTowers++;
            }
            Destroy(gameObject);
        }
    }
}
