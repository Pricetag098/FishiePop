using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLoader : MonoBehaviour
{

	[System.Serializable]
	class FishData
	{
		public List<Fish> fishList = new List<Fish>();
	}
	FishData fishData = new FishData();

	// Start is called before the first frame update
	void Start()
    {
		
        CreateNewFish();
        Save();
    }

	public void Save()
	{
		string jsonSave = JsonUtility.ToJson(fishData);
		System.IO.File.WriteAllText(Application.persistentDataPath + "/FishSave.txt", jsonSave);
		Debug.Log(jsonSave);
	}

	public static void Load()
	{
		FishDataStorage.fishList = JsonUtility.FromJson<List<Fish>>(System.IO.File.ReadAllText(Application.persistentDataPath + "/FishSave.txt"));
	}

	public static void CreateNewFish()
	{
		FishDataStorage.fishList.Add(new Fish(0.1f, "Guppy"));
		//Debug.Log(fishList.Count);
	}
}
