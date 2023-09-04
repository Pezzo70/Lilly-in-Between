using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public MonsterMovement monster;
    private bool canHug = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canHug)
            {
                canHug = false;
                monster.SetPositionToRandomPoint();
                StartCoroutine(WaitToHugBear());
            }
        }
    }


    public IEnumerator WaitToHugBear()
    {
        yield return new WaitForSeconds(2f);
        canHug = true;
    }
}
