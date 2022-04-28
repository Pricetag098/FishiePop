using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpeech : MonoBehaviour
{
    static GameObject textBox;
    static GameObject Text;

    public Text theText;
    public Pond pond;
    public TextAsset textFile;
    public Text AAAAAA;
    public string[] textLines;

    protected int currentline;

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
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        currentline = Random.Range(0, 5);
        theText.text = textLines[currentline];
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndConvo();
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
           state |= ConvoState.fish;
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

