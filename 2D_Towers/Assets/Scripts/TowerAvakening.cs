using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAvakening : MonoBehaviour
{
    [SerializeField]
    GameObject TowerActive;

    GameObject GameManager;
    TowerCounter CountingScript;
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        CountingScript = GameManager.GetComponent<TowerCounter>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Missile")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (CountingScript.TowerMaxAmount && !CountingScript.Awakend)
        {
            AwakeAtMax();
        }
    }

    void AwakeAtMax()
    {
            Instantiate(TowerActive, transform.position, transform.rotation);
            Destroy(gameObject);
    }
}
