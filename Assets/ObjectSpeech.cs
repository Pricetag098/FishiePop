using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpeech : MonoBehaviour
{
    public Pond pond;
    static GameObject textBox;
    static GameObject Text;

    //Unique to object
    public Text theText;

    public TextAsset textFile;
    public TextAsset playerText;
    //public Text AAAAAA;
    public string[] textLines;

    protected int currentline;


    public void Talking()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        currentline = Random.Range(0, 5);
        theText.text = textLines[currentline];
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TalkingPlayer();
        }
    }

    void TalkingPlayer()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        currentline = Random.Range(0, 10);
        theText.text = textLines[currentline];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pond.convoEnd();
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
    Fish theFish;
    public void BeginConvo(Fish fish)
	{
        state = ConvoState.playerTalk;
        theFish = fish;
	}


    public enum ConvoState
	{
        no,
        playerTalk,
        fishTalk
	}
    public ConvoState state;
	private void Update()
	{
		switch (state)
		{
            case ConvoState.no:
                break;

            case ConvoState.playerTalk:
                //called when player is talking



                break;

            case ConvoState.fishTalk:
                //called when fish is talking
                break;
		}
	}
}

