using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            //GameManager.Instance.TargetHit();
            StartCoroutine(Controller());
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            //GameManager.Instance.BallFailed();
            StartCoroutine(Controller2());
        }
    }
    IEnumerator Controller()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.TargetHit();
    }
    IEnumerator Controller2()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.BallFailed();
    }
}
