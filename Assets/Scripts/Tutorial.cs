using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void TriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tutorial");
        gameObject.SetActive(false);
    }

}
