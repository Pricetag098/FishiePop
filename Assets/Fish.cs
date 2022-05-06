using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
	public string name = "";
    public float reelSpeed = 0;
	public int affection = 0;
	public GameObject hookIco;
	public Sprite portrait;
	public TextAsset dialog;
    public Fish(float rs,string recorcePath)
	{
		reelSpeed = rs;
		hookIco = Resources.Load(recorcePath+"/FishBody") as GameObject;
		portrait = Resources.Load(recorcePath + "/Portrait") as Sprite;
		dialog = Resources.Load(recorcePath + "/Dialog") as TextAsset;

		Debug.Log(dialog == null);
	}


}
