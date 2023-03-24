using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f; //movement speed

    [SerializeField] float xRange = 5f; //clamp x range
    [SerializeField] float yRange = 5f; //clamp x range

    // Update is called once per frame
    void Update()
    {
        //Movement OLD INPUT SYSTEM
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        //offset of movement = speed variable * input * Frame independent code
        float xoffset = controlSpeed*xThrow*Time.deltaTime; 
        float rawXPOS = transform.localPosition.x + xoffset;//new x position = old one + offset

        //clamp to make sure player doesn't go off screen (X AXIS)
        float clampedXPos = Mathf.Clamp(rawXPOS,-xRange,xRange);

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
}
