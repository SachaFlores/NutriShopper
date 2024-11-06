using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PrefabGoodItem;
    public GameObject PrefabBadItem;
    public List<Transform> SpawnerPoints;
    void Start()
    {
        foreach (var item in SpawnerPoints)
        {
            float r = Random.Range(0, 6);
            if (r == 0)
            {
                Instantiate(PrefabGoodItem, item.position, item.rotation);
            }
            else if (r == 1 || r == 2) 
            {
                Instantiate(PrefabBadItem, item.position, item.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
