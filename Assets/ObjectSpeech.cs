using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpeech : MonoBehaviour
{
    static GameObject textBox;
    static GameObject Text;
    //public RawImage img;
    public SpriteRenderer sr;
    public Text theText;
    public Pond pond;
    public TextAsset textFile;
    public TextAsset playerTextAss;
    public Text AAAAAA;
    public string[] textLines;

    protected int currentline;

    bool spoke = false;

    public void BeginConvo ()
    {
        state = ConvoState.player;
    }
    public void EndConvo ()
    {
        state = ConvoState.no;
        pond.convoEnd();
    }

    void Talking()
    {
        if (!spoke)
        {
            if (textFile != null)
            {
                textLines = (textFile.text.Split('\n'));
            }

            currentline = Random.Range(0, textLines.Length);
            theText.text = textLines[currentline];
            spoke = true;
            //img.texture = pond.caughtFish.portrait.texture;
            sr.sprite = pond.caughtFish.portrait;
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spoke = false;
                EndConvo();

            }
        
        
    }

    void TalkingPlayer()
    {
        if (!spoke)
        {
            if (textFile != null)
            {
                textLines = (playerTextAss.text.Split('\n'));
            }

            currentline = Random.Range(0, textLines.Length);
            theText.text = textLines[currentline];
            spoke = true;
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spoke = false;
                state = ConvoState.fish;
            }
        
       
    }

    void IdleTalking() //Only for the player
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        currentline = Random.Range(0, 9);
        theText.text = textLines[currentline];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public enum ConvoState
	{
        no,
        player,
        fish
	}
    public ConvoState state;

	private void Update()
	{
		switch (state)
		{
            case ConvoState.no:
                break;
            case ConvoState.player:
                TalkingPlayer();
                break;
            case ConvoState.fish:
                Talking();
                break;
		}
	}
}

