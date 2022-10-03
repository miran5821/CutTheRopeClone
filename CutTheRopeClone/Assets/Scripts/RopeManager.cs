using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D firstHook;
    [SerializeField] Ball ball;
    [SerializeField] int connectionNumber = 5;
    public GameObject[] connectionsPools;
    public int hingeIndex;
    void Start()
    {
        CreatRope();
    }

    public void CreatRope()
    {
        Rigidbody2D previousConnect = firstHook; // önceki baðlantý noktasý
        for (int i = 0; i < connectionNumber; i++)
        {
            connectionsPools[i].SetActive(true);
            HingeJoint2D hingeJoint2D = connectionsPools[i].GetComponent<HingeJoint2D>();
            hingeJoint2D.connectedBody = previousConnect;

            if (i < connectionNumber - 1)
                previousConnect = connectionsPools[i].GetComponent<Rigidbody2D>();
            else
                ball.TieTheLastChain(connectionsPools[i].GetComponent<Rigidbody2D>(),hingeIndex);

            
        }
    }
}
