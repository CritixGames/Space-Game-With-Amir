using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Input Variables
    float xThrow;
    float yThrow;

    [SerializeField] float controlSpeed = 10f; //movement speed

    [SerializeField] float xRange = 5f; //clamp x range
    [SerializeField] float yRange = 5f; //clamp x range

    //Pitch Variables
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    //Yaw Variables
    [SerializeField] float positionYawFactor = -5f;
    //Roll Variables
    [SerializeField] float controlRollFactor = -20;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        //Movement OLD INPUT SYSTEM
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //offset of movement = speed variable * input * Frame independent code
        float xoffset = controlSpeed * xThrow * Time.deltaTime;
        float rawXPOS = transform.localPosition.x + xoffset;//new x position = old one + offset

        //clamp to make sure player doesn't go off screen (X AXIS)
        float clampedXPos = Mathf.Clamp(rawXPOS, -xRange, xRange);

        //offset of movement = speed variable * input * Frame independent code
        float yoffset = controlSpeed * yThrow * Time.deltaTime;
        float rawYPOS = transform.localPosition.y + yoffset;//new y position = old one + offset

        //clamp to make sure player doesn't go off screen (Y AXIS)
        float clampedYPos = Mathf.Clamp(rawYPOS, -yRange, yRange);

        //finding player ship starting position and/or setting to new position
        transform.localPosition =
           new Vector3(
           clampedXPos,
           clampedYPos,
           transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;  //Pitch Rotation
        float yaw = transform.localPosition.x * positionYawFactor; //Yaw Rotation
        float roll = xThrow * controlRollFactor; //Roll Rotation
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
