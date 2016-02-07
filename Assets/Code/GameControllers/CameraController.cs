using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour
{
    public Vector3 myPosition;
    public Transform myPlayer;
    public float fishStart = 0f;
    public float fishEnd = 0.3f;
    public float fishStartOld;
    public float fishSpeed = 1.5f;
    public float lerpSpeed = 0f;
    public int pressCounter = 0;

    // Use this for initialization
    void Start()
    {


    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
       
        transform.position = new Vector3(myPlayer.position.x + myPosition.x, myPosition.y, myPosition.z);
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (pressCounter != 0)
            {
                fishStartOld = fishStart;
                fishStart = fishEnd;
                fishEnd = fishStartOld;
            }
            StartCoroutine(FishEyeLerp());
            pressCounter++;

        }
       
    }
    IEnumerator FishEyeLerp()
    {
        lerpSpeed = 0f;

        while (lerpSpeed < 1)
        {
            lerpSpeed += Time.deltaTime;
            GetComponent<Fisheye>().strengthX = Mathf.Lerp(fishStart, fishEnd, lerpSpeed);
          //  GetComponent<Fisheye>().strengthY = Mathf.Lerp(fishStart, fishEnd, lerpSpeed);
            yield return null;
        }
       
    }
}
 