using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreySpawner : MonoBehaviour
{
    public int maxPreyNumber;
    public List<GameObject> preyList;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxPreyNumber; i++)
        {
            GameObject Prey = Instantiate(Resources.Load("Prefab/Assets/Prey"), transform) as GameObject;
            preyList.Add(Prey);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxPreyNumber; i++)
        {
            if (preyList[i] == null)
            {
                GameObject Prey = Instantiate(Resources.Load("Prefab/Assets/Prey"), transform) as GameObject;
                preyList[i] = Prey;
            }
        }
    }
}
