using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpeech : MonoBehaviour
{
    static GameObject textBox;
    static GameObject Text;

    public Text theText;

    public TextAsset textFile;
    public Text AAAAAA;
    public string[] textLines;

    protected int currentline;


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
                break;
            case ConvoState.fish:
                break;
		}
	}
}

