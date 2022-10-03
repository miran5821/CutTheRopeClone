using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Ball ball;
    [SerializeField] GameObject[] ropeCenters;
    Level levelScript;
    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject nextLevelPanel, endGamePanel;
    [SerializeField] GameObject levelsParent;
    
    private void Start()
    {
        levelScript = FindObjectOfType<Level>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Center1"))
                {
                    RopeTransactions(hit, 1);
                }
                else if (hit.collider.CompareTag("Center2"))
                {
                    RopeTransactions(hit, 2);
                }
                else if (hit.collider.CompareTag("Center3"))
                {
                    RopeTransactions(hit, 3);
                }
                else if (hit.collider.CompareTag("Center4"))
                {
                    RopeTransactions(hit,4);
                }
            }
        }
    }

    void RopeTransactions(RaycastHit2D hit,int index)
    {
        hit.collider.gameObject.SetActive(false);
        //ball.hingeControl[2].enabled = false;
        foreach (var item in ropeCenters)
        {
            if (item.GetComponent<RopeManager>().hingeIndex == index)
            {
                foreach (var item2 in item.GetComponent<RopeManager>().connectionsPools)
                {
                    item2.SetActive(false);
                }
            }
        }
    }

    public void BallFailed()
    {
        levelScript.currentBallCount--;
        if (levelScript.currentBallCount ==0)
        {
            if (levelScript.targetObjectCount > 0)
            {
                //kaybetti
                endGamePanel.SetActive(true);
                
            }
            else if (levelScript.targetObjectCount == 0)
            {
                //kazandý
                nextLevelPanel.SetActive(true);
            }
        }
        else
        {
            if (levelScript.targetObjectCount == 0)
            {
                //kazandý
                nextLevelPanel.SetActive(true);
            }
        }
        
    }
    public void TargetHit()
    {
        levelScript.targetObjectCount--;
        if (levelScript.currentBallCount == 0 && levelScript.targetObjectCount ==0)
        {
            //kazandý
            nextLevelPanel.SetActive(true);
        }
        else if (levelScript.currentBallCount == 0 && levelScript.targetObjectCount >0)
        {
            //kaybetti
            endGamePanel.SetActive(true);
        }
    }
    int index = 0;
    public void NextLevel()
    {
        if (index > 3)
            index = 0;
        else
            index++;
        levels[index-1].gameObject.SetActive(false);
        levels[index].gameObject.SetActive(true);
        levelScript = FindObjectOfType<Level>();
        nextLevelPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StopGame()
    {
        endGamePanel.SetActive(true);
    }
}
