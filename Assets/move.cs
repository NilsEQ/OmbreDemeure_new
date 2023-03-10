using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class move : MonoBehaviour
{
    public SteamVR_Action_Boolean WalkAction;
    private Vector3 myVec;
    public GameObject myObj;
    public float speed = 1.0f;
    public float thres1;
    public float thres2;

    bool walk = false;

    [SerializeField] DataCollector mydata;

    [SerializeField] int size = 20;
    List<float> myspeeds = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            myspeeds.Add(0.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vr = mydata.VelocityR.magnitude;
        float vl = mydata.VelocityL.magnitude;
        myspeeds.RemoveAt(0);
        myspeeds.Add((vr + vl) / 2.0f);

        if (WalkAction.GetState(SteamVR_Input_Sources.Any))
        {

            float relatspeed = average(myspeeds);


            if (vr > thres1 && vl > thres1)
            {
                walk = true;
            }

            if (relatspeed < thres2)
            {
                walk = false;
            }

  

            if (walk)
            {

                myVec = myObj.transform.forward;
                myVec.y = 0.0f;
                myVec = Vector3.Normalize(myVec);
                transform.position += myVec * speed * relatspeed;
            }

        };
    }


    float average(List<float> myspeeds)
    {
        float sum = 0;
        for(int i = 0; i < size; i++)
        {
            sum += myspeeds[i];
        }

        return sum / (float)size;
    }
}
