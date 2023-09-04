using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public MonsterMovement monster;
    private EnvironmentInteractable environmentInteractable;
    public bool canHug = true;

    public void Start()
    {
        environmentInteractable = GetComponent<EnvironmentInteractable>();
    }

    public IEnumerator WaitToHugBear()
    {
        canHug = false;
        environmentInteractable.SetInteractEnabled(false);
        yield return new WaitForSeconds(5f);
        environmentInteractable.SetInteractEnabled(true);
        canHug = true;
    }

    public void MonsterToRandom() 
    {
        monster.SetPositionToRandomPoint();
    }
}
