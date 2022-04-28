using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLoader : MonoBehaviour
{
	private void Start()
	{
		FishDataStorage.fishList.Add(new Fish(0.1f, "Guppy"));
		FishDataStorage.fishList.Add(new Fish(0.05f, "Goldy"));
		FishDataStorage.fishList.Add(new Fish(0.15f, "Pirhanna"));
	}
	
}
