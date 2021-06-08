using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoting : MonoBehaviour
{
    public float speed = 1f;

    float speedMultiplyer = 3;
    int noumberOfTowers;
    float rotationAngle;
    bool active = true;
    bool awakend = false;
    GameObject GameManager;
    TowerCounter CountingScript;

    [SerializeField]
    GameObject MissilePrefab;
    [SerializeField]
    GameObject TowerDormant;
    [SerializeField]
    Transform ShootingPoint;

    void Start()
    {
        speed += speedMultiplyer;
        GameManager = GameObject.Find("GameManager");
        CountingScript = GameManager.GetComponent<TowerCounter>();

        noumberOfTowers = CountingScript.NoumberOfTowers;

        if (noumberOfTowers == 1|| CountingScript.TowerMaxAmount)
        {
            StartCoroutine("TowerRotation");
            
        }
        else
        {
            StartCoroutine("StartDelay");
        }
    }

    private void Update()
    {
        if (CountingScript.TowerMaxAmount && !CountingScript.Awakend && !awakend)
        {
            StopAllCoroutines();
            StartCoroutine("TowerRotation");
            awakend = true;
        }
        if (!active)
        {
            Instantiate(TowerDormant, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Missile")
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        GameObject missile = Instantiate(MissilePrefab, ShootingPoint.position, ShootingPoint.rotation);
        Rigidbody2D MissileRB = missile.GetComponent<Rigidbody2D>();
        MissileRB.AddForce(ShootingPoint.up * speed, ForceMode2D.Impulse);
    }

    IEnumerator TowerRotation()
    {
        for(int i = 0; i < 12; i++)
        {
            rotationAngle = Random.Range(15, 45);
            transform.Rotate(0f, 0f, rotationAngle);
            Shoot();
            yield return new WaitForSeconds(.5f);
        }
        active = false;
    }

    IEnumerator StartDelay()
    {      
        yield return new WaitForSeconds(6f);
        StartCoroutine("TowerRotation");
    }
}
