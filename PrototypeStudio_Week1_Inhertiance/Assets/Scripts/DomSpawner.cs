using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomSpawner : MonoBehaviour
{
    public int maxDomNumber;
    public List<GameObject> domList;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxDomNumber; i++)
        {
            GameObject Prey = Instantiate(Resources.Load("Prefab/Assets/DominantSpecies"), transform) as GameObject;
            domList.Add(Prey);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxDomNumber; i++)
        {
            if (domList[i] == null)
            {
                GameObject Prey = Instantiate(Resources.Load("Prefab/Assets/DominantSpecies"), transform) as GameObject;
                domList[i] = Prey;
            }
        }
    }
}
