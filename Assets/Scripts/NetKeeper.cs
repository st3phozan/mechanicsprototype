using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetKeeper : MonoBehaviour
{
    public float score = 0;

    public List<GameObject> ball = new List<GameObject>();

    public Controller ctrl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "ball")
        {
            //gameRestarted = true;
            ctrl.score += 1;
ctrl.PlaySpecificClip(1);


        }

    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "ball")
        {
            //gameRestarted = true;
            ctrl.score -= 1;


        }

    }
}
