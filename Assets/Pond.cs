using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
	public float hookChance, reelSpeed;
    public GameObject rod;
	public GameObject hook;
	public GameObject reelIndBg;
	public GameObject reelIndFg;
	Fish caughtFish;

	public enum FishState
	{
		waiting,
		cast,
		reeling,
		caught

	}
	public FishState state;
    bool mOver = false;


	//reel timing
	float rTime = 0;
	float currentRTime = 0;


	public float reelValue = .5f;
	Vector2 castPos;
    // Start is called before the first frame update
    void Start()
    {
        rod.SetActive(false);
		reelIndBg.SetActive(false);
		reelIndBg.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		switch (state)
		{
			case FishState.waiting:
				rod.SetActive(mOver);
				if (mOver)
				{
					if (Input.GetMouseButtonDown(0))
					{
						Cast();
						state = FishState.cast;
					}
				}
				hook.SetActive(false);
				break;

			case FishState.cast:
				hook.SetActive(true);
				
				if(currentRTime>rTime)
				{
					CatchFish();
					state = FishState.reeling;
				}
				currentRTime += Time.deltaTime;
				break;

			case FishState.reeling:
				reelIndBg.SetActive(true);
				reelIndBg.SetActive(true);
				if (reelValue >= 1)
				{
					ReleaseFish();
				}
				if(reelValue <= 0)
				{
					NetFish();
				}
				reelIndFg.transform.localPosition = new Vector2(reelValue - 0.5f, 0);
				reelValue+= Time.deltaTime * caughtFish.reelSpeed;

				reelValue += (Input.GetAxis("Mouse ScrollWheel"))*Time.deltaTime * reelSpeed;

				Mathf.Clamp(reelValue, 0, 1);
				break;
		}

        
    }

	void Cast()
	{
		castPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

		currentRTime = 0;
		rTime = Random.value * hookChance;
		hook.transform.position = castPos;
	}

	void CatchFish()
	{
		caughtFish = FishDataStorage.fishList[Random.Range(0,FishDataStorage.fishList.Count-1)];
		
	}

	void ReleaseFish()
	{
		state = FishState.waiting;
		reelValue = 0.5f;
		hook.SetActive(false);
		reelIndBg.SetActive(false);
		reelIndBg.SetActive(false);
	}

	void NetFish()
	{
		state = FishState.caught;
		reelIndBg.SetActive(false);
		reelIndBg.SetActive(false);
		hook.SetActive(false);
	}
	
	private void OnMouseEnter()
	{
        mOver = true;

	}
	private void OnMouseExit()
	{
	    mOver = false;
	}
}
