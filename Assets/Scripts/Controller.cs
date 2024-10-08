using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public float xInput, gravityPower = 1, score = 0, timer, TimeStart, timerLength;
    public bool heldDown = false, gameStart = false;
    public TMP_Text scoreText, timerText, finalScore;

    public GameObject startScreen, endScreen, inGame;

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    Rigidbody2D body;
    public GameObject gravityController;
    // Start is called before the first frame update
    void Start()
    {
        //gameStart = true;
        
        body = gravityController.GetComponent<Rigidbody2D>();
        // scoreText = GetComponent<TMP_Text>();
    }
    public void PlaySpecificClip(int index)
{
    if (index >= 0 && index < audioClips.Length)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
    else
    {
        Debug.LogWarning("Clip index out of range.");
    }
}

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
        scoreText.text = score.ToString();

        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.z * Mathf.Deg2Rad), Mathf.Cos(transform.rotation.z * Mathf.Deg2Rad)) - new Vector2(0, gravityPower);

        if (Input.GetButtonDown("Jump"))
        {
            heldDown = true;
PlaySpecificClip(0);
	    


        }

        //Debug.Log(transform.forward);
        if (Input.GetButtonUp("Jump"))
        {

            heldDown = false;
        }

        if (heldDown && gravityPower > -20)
        {
            gravityPower -= .1f;
            Debug.Log(gravityPower);
        }
        else if (!heldDown && gravityPower < 10)
        {
            gravityPower += .1f;
        }
        xInput = Input.GetAxis("Horizontal");
        if (xInput != 0)
        {

            Debug.Log(xInput);
            transform.Rotate(0, 0, (transform.rotation.z - xInput) / 10);
        }
        
            timer = Time.time - TimeStart;
            float timerDiff = timerLength - timer;
            timerText.text = timerDiff.ToString();
            if (timerDiff < 0){
                gameStart = false;
                GameEnd();

                
            }


        }
    }
    public void GameEnd(){
        endScreen.SetActive(true);
        inGame.SetActive(false);
        finalScore.text = score.ToString();
    }
    public void StartGame()
    {
        TimeStart = Time.time;
        startScreen.SetActive(false);
        inGame.SetActive(true);
        gameStart=true;
        endScreen.SetActive(false);
    }

}
