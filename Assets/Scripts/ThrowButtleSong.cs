using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowButtleSong : MonoBehaviour
{
    public GameObject punchSound;
    public GameObject ouchSound;

    public IEnumerator OnTriggerEnter2D(Collider2D others)
    {
        punchSound.SetActive(true);
        yield return new WaitForSeconds(1);
        punchSound.SetActive(false);
        //yield return new WaitForSeconds(0);
        ouchSound.SetActive(true);
        yield return new WaitForSeconds(1);
        ouchSound.SetActive(false);
    }
   
}
