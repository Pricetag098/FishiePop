using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
	public string name = "";
    public float reelSpeed = 0;
	public int affection = 0;
	public Sprite hookIco;
	public Sprite portrait;
	public TextAsset dialog;
    public Fish(float rs,string recorcePath)
	{
		reelSpeed = rs;
		hookIco = Resources.Load(recorcePath+"Hook") as Sprite;
		portrait = Resources.Load(recorcePath + "Portrait") as Sprite;
		dialog = Resources.Load(recorcePath + "Dialog") as TextAsset;
	}


}
