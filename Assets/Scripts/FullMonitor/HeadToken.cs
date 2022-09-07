using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
//Class meant to be used to control all head tokens.
public class HeadToken : MonoBehaviour
{
    public IndividualToken[] ts;
    public MonitorImages monitorImages;
    [SerializeField]
    private Transform[] waypoints;
    private string[] nameOrder;

    [SerializeField]
    private Transform tempWaypoint; //to be used when swapping.

    private int tokClickedNum;
    private bool firstClick = false;

    // Start is called before the first frame update
    void Start()
    {
        ts = shuffleTokens(ts, ts.Length);

        for (int i = 0; i < ts.Length; i++){
            ts[i].transform.position = waypoints[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (!firstClick) {
            checkIfFirstClicked(ts);
        } else {
            checkIfSecondClicked(ts);
        }
       
    }

    //credit: code from geeksforgeeks. modified by Hugo Barahona
    // n is size of array
    IndividualToken[] shuffleTokens(IndividualToken[] toks, int n)
    {
        Random r = new Random();
         
        for (int i = n - 1; i > 0; i--)
        {  
            // Pick a random index
            // from 0 to i
            int j = r.Next(0, i+1);
             
            // Swap 
            IndividualToken temp = toks[i];
            toks[i] = toks[j];
            toks[j] = temp;
        }
        return toks;
    }
    // For First Click
    void checkIfFirstClicked(IndividualToken[] toks){
        for (int i = 0; i < toks.Length; i++){
            if (toks[i].tokenClicked == true){
                toks[i].tokenClicked = false;
                firstClick = true;
                tokClickedNum = i;
                for (int e = 0; e < toks.Length; e++){
                    if(e != tokClickedNum){
                        toks[e].otherTokenClicked = true;
                        toks[e].borderAnim = true;
                    }
                }
                monitorImages.GetComponent<Renderer>().enabled = false;
                //Debug.Log(toks[i].characterName + " was clicked.");
            }
        }
    }
    // For Second Click
    void checkIfSecondClicked(IndividualToken[] toks){
        for (int i = 0; i < toks.Length; i++){
            if (toks[i].secondClick == true){
                //swapping positions of transform
                tempWaypoint.transform.position = toks[i].transform.position;
                toks[i].transform.position = toks[tokClickedNum].transform.position;
                toks[tokClickedNum].transform.position = tempWaypoint.transform.position;

                //swapping position within the IndividualToken Array.
                IndividualToken temp = toks[i];
                toks[i] = toks[tokClickedNum];
                toks[tokClickedNum] = temp;
                
                for (int e = 0; e < toks.Length; e++){
                    toks[e].otherTokenClicked = false;
                    toks[e].secondClick = false;
                    toks[e].borderEnd = true;  
                }

                firstClick = false;
                monitorImages.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
