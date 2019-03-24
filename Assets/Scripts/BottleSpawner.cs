using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject bottle15;
    public GameObject bottle2;
    public GameObject bottle3;
    public GameObject bottle5;

    public void BottleSpawn(int bottleType)
    {
        switch (bottleType)
        {
            case 1: Instantiate(bottle15, this.transform, false); break;
            case 2: Instantiate(bottle2, this.transform, false); break;
            case 3: Instantiate(bottle3, this.transform, false); break;
            case 4: Instantiate(bottle5, this.transform, false); break;
        }
    }
}
