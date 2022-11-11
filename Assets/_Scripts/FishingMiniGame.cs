using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FishingMiniGame : MonoBehaviour
{
    [Header("Fishing Area")] 
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottomBounds;

    [Header("Fish Settings")] 
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 3f; //smooth out fish movement
    [SerializeField] float fishTimeRandomizer = 3f; //how often the fish moves
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    [Header("Hook Settings")] 
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;
    private float hookPosition;
    private float hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] private float hookPower;
    [SerializeField] private float progressBarDecay;
    private float catchProgress;

    public PlayerMovement player;



    private void Start()
    {
        //So we dont loose the game right away
        catchProgress = .3f;
    }

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }

    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale; //Update the Y value of the parent object


        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if (catchProgress >= 1)
            {
                ScoreScript.scoreValue += 1;
                //won the game
                Debug.Log("You caught a fish!");
                //Do win logic here
                player.PlayerIsFishing = false;
                catchProgress = 0;
                
                
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if (catchProgress <= 0)
            {
                //we lost
                Debug.Log("You lost the fish");
                //Loose logic here
            }
        }

        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            //Increase our pull velocity
            hookPullVelocity += hookSpeed * Time.deltaTime; //raises our hook
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;
        
        //Making sure the hook doesent get stuck
        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }
        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2); //Keep hook within bounds
        hook.position = Vector3.Lerp(bottomBounds.position, topBounds.position, hookPosition);
    }

    private void MoveFish()
    {
        //Based on timer, pick random position
        //move fish to that position smoothly
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0)
        {
            //pick a new target position
            //and reset timer
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomBounds.position, topBounds.position, fishPosition);
    }
}
