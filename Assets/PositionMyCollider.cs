using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMyCollider : MonoBehaviour
{

    public Transform Head;
    public Transform feet;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Head.transform.position.x, feet.transform.position.y, Head.transform.position.z);
    }
}
