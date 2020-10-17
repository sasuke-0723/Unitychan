using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject unitychan;

    void Start()
    {
        unitychan = Resources.Load("Prefabs/Unitychan") as GameObject;
        Instantiate(unitychan, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {

    }
}
