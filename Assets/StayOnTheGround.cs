using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnTheGround : MonoBehaviour
{

    GameObject myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(myCam.transform.position);
        transform.position = pos;
    }
}
