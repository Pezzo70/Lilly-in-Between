using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsManager : MonoBehaviour
{
    public Transform[] spots;
    public GameObject heartPrefab;
    public bool startSpawn = false;
    private Stack<Transform> _tStack = new Stack<Transform>();
    private Coroutine coroutine = null;

    void Start()
    {
        ShuffleAndStack();
    }

    void Update()
    {
        if (!startSpawn) return;

        if (_tStack.Count > 0)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(SpawnHeart());
            }
        }
        else
        {
            ShuffleAndStack();
        }
    }

    private IEnumerator SpawnHeart()
    {
        Instantiate(heartPrefab, _tStack.Pop(), true);
        yield return new WaitForSeconds(3f);
        coroutine = null;
    }

    void ShuffleAndStack()
    {
        foreach (Transform spot in spots)
        {
            Transform t;
            do
            {
                t = spots[Random.Range(0, spots.Length)];
            } while (_tStack.Contains(t));

            _tStack.Push(t);
        }
    }
}
