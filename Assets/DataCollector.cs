using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour
{

    [SerializeField] GameObject LeftC;
    [SerializeField] GameObject RightC;

    public Vector3 PositionL;
    public Vector3 VelocityL;
    public Vector3 AccelerationL;

    public Vector3 PositionR;
    public Vector3 VelocityR;
    public Vector3 AccelerationR;
    public float AccNorm;


    // Start is called before the first frame update
    void Start()
    {
        PositionL = new Vector3(0.0f, 0.0f, 0.0f);
        VelocityL = new Vector3(0.0f, 0.0f, 0.0f);
        AccelerationL = new Vector3(0.0f, 0.0f, 0.0f);

        PositionR = new Vector3(0.0f, 0.0f, 0.0f);
        VelocityR = new Vector3(0.0f, 0.0f, 0.0f);
        AccelerationR = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_PositionL = LeftC.transform.localPosition;
        Vector3 new_VelocityL = (new_PositionL - PositionL) / Time.deltaTime;
        AccelerationL = (new_VelocityL - VelocityL) / Time.deltaTime;
        VelocityL = new_VelocityL;
        PositionL = new_PositionL;

        Vector3 new_PositionR = RightC.transform.localPosition;
        Vector3 new_VelocityR = (new_PositionR - PositionR) / Time.deltaTime;
        AccelerationR = (new_VelocityR - VelocityR) / Time.deltaTime;
        VelocityR = new_VelocityR;
        PositionR = new_PositionR;
        AccNorm = VelocityR.magnitude;
    }
}
