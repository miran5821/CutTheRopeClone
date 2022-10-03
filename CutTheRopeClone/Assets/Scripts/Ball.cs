using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float chainDistance;
    public Dictionary<int, HingeJoint2D> hingeControl = new Dictionary<int, HingeJoint2D>();
    public void TieTheLastChain(Rigidbody2D lastChain,int hingeIndex)//son zinciri baðla
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        hingeControl.Add(hingeIndex,joint);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = lastChain;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0, -chainDistance);
    }
}
