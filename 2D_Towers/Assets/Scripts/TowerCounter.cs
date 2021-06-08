using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCounter : MonoBehaviour
{
    public int NoumberOfTowers = 1;
    public bool TowerMaxAmount = false;
    public bool Awakend = false;

    void Update()
    {
        if (NoumberOfTowers == 100)
        {
            TowerMaxAmount = true;
        }
        if(TowerMaxAmount && !Awakend)
        {
            StartCoroutine("DisableAwakening");
        }
    }
    IEnumerator DisableAwakening()
    {
        yield return new WaitForSeconds(1f);
        Awakend = true;
    }
}
