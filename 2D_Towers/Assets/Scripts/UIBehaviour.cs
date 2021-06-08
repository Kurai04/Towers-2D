using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public Text noumberOfTowers;
    GameObject gameManager;
    TowerCounter towerCounter;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        towerCounter = gameManager.GetComponent<TowerCounter>();

        noumberOfTowers = GetComponent<Text>();
    }

    void Update()
    {
        noumberOfTowers.text = "Towers: " + towerCounter.NoumberOfTowers.ToString();
    }
}
