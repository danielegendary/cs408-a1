using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera: MonoBehaviour
{
        //set How far is the camera from the role
        public float distanceAway;
        //set How high the camera is above the character
        public float distanceUp;
        //set The speed of the camera movement
        public float smooth;
        //set target position
        private Vector3 targetPosition;
        //The position of the object the camera is following, in this case the position of the character's object
        Transform follow;
        // Use this for initialization
        void Start ()
        {
                //Get the position of the object to follow
                follow = GameObject.FindGameObjectWithTag ("Player").transform;
        }

        // Update is called once per frame
        void Update ()
        {
                //Get the position of the target to be moved by the camera
                targetPosition = follow.position + Vector3.up * distanceUp -follow.forward * distanceAway;
                //The camera moves from the current position to the target positiom
                transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
                //The camera is looking at the character object
                transform.LookAt (follow);
        }
}