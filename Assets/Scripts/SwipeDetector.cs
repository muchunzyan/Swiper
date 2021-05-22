using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    public Image BigSquare, LilSquare;
    public GameObject DirectionalFlare;

    List<GameObject> newParticles = new List<GameObject>();
    float particlesTimer;

    Vector2 fingerDownPos, fingerUpPos;
    float minDistanceForSwipe = 10f;

    public string SwipeDirectionStr;

    public GameManager gm;

    void Update()
    {
        if (gm.isPlaying)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUpPos = touch.position;
                    fingerDownPos = touch.position;

                    //Square.transform.localScale = new Vector3(0.89f, 0.89f, 0.89f);
                    BigSquare.rectTransform.sizeDelta = new Vector2(440, 440);
                    LilSquare.rectTransform.sizeDelta = new Vector2(363.5f, 363.5f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDownPos = touch.position;

                    //Square.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    BigSquare.rectTransform.sizeDelta = new Vector2(460, 460);
                    LilSquare.rectTransform.sizeDelta = new Vector2(380, 380);

                    DetectSwipe();
                }
            }

            if (particlesTimer < 0 && newParticles.Count != 0)
            {
                newParticles.RemoveAt(0);
            }
            particlesTimer -= Time.deltaTime;
        }
    }

    void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                SwipeDirectionStr = fingerDownPos.y - fingerUpPos.y > 0 ? "Up" : "Down";
            }
            else
            {
                SwipeDirectionStr = fingerDownPos.x - fingerUpPos.x > 0 ? "Right" : "Left";
            }
            fingerUpPos = fingerDownPos;

            gm.HandleSwipe(SwipeDirectionStr);
            ParticlesShoot(SwipeDirectionStr);
        }
    }

    bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    void ParticlesShoot(string swipeDirection)
    {
        if (swipeDirection == "Up")
            newParticles.Add(Instantiate(DirectionalFlare, new Vector3(0, -0.25f, 1), Quaternion.Euler(0, 0, 0)));
        else if (swipeDirection == "Left")
            newParticles.Add(Instantiate(DirectionalFlare, new Vector3(0, -0.25f, 1), Quaternion.Euler(0, 0, 90)));
        else if (swipeDirection == "Down")
            newParticles.Add(Instantiate(DirectionalFlare, new Vector3(0, -0.25f, 1), Quaternion.Euler(0, 0, 180)));
        else if (swipeDirection == "Right")
            newParticles.Add(Instantiate(DirectionalFlare, new Vector3(0, -0.25f, 1), Quaternion.Euler(0, 0, -90)));

        particlesTimer = 1f;
    }
}
