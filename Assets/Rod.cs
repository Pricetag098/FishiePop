using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Pond pond;
    public GameObject line, reel;
    // Start is called before the first frame update
    public float rotSpeed;
    float rot;
    // Update is called once per frame
    void Update()
    {
		switch (pond.state)
		{
            case Pond.FishState.waiting:
                line.SetActive(true);
                break;
            case Pond.FishState.reeling:
                line.SetActive(false);
                rot += Input.GetAxis("Mouse ScrollWheel") * rotSpeed;
                reel.transform.localRotation = Quaternion.Euler(0,0,rot);
                break;
            case Pond.FishState.cast:
                line.SetActive(false);
                break;

            case Pond.FishState.caught:
                line.SetActive(true);
                break;
		}
    }
}
