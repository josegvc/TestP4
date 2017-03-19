using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInput : MonoBehaviour
{
	public CharacterMovement characterMove { get; protected set; }

    [System.Serializable]
    public class InputSettings
    {
        public string verticalAxis = "Vertical";
        public string horizontalAxis = "Horizontal";
        public string aimButton = "Fire2";
        public string fireButton = "Fire1";
    }
    [SerializeField]
    public InputSettings input;

    [System.Serializable]
    public class OtherSettings
    {
        public float lookSpeed = 5.0f;
        public float lookDistance = 30.0f;
        public bool requireInputForTurn = true;
        public LayerMask aimDetectionLayers;
    }
    [SerializeField]
    public OtherSettings other;

    public Camera TPSCamera;

    public bool debugAim;
    public Transform spine;
    bool aiming;

    // Use this for initialization
    void Start()
    {
        characterMove = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterLogic();
        CameraLookLogic();
    }

    //Handles character logic
    void CharacterLogic()
    {
        if (!characterMove)
            return;

        characterMove.Animate(Input.GetAxis(input.verticalAxis), Input.GetAxis(input.horizontalAxis));
        
    }

    //Handles camera logic
    void CameraLookLogic()
    {
        if (!TPSCamera)
            return;
		
		other.requireInputForTurn = !aiming;

		if (other.requireInputForTurn) {
			if (Input.GetAxis (input.horizontalAxis) != 0 || Input.GetAxis (input.verticalAxis) != 0) {
				CharacterLook ();
			}
		}
		else {
			CharacterLook ();
		}
    }

    //Make the character look at a forward point from the camera
    void CharacterLook()
    {
        Transform mainCamT = TPSCamera.transform;
        Transform pivotT = mainCamT.parent;
        Vector3 pivotPos = pivotT.position;
        Vector3 lookTarget = pivotPos + (pivotT.forward * other.lookDistance);
        Vector3 thisPos = transform.position;
        Vector3 lookDir = lookTarget - thisPos;
        Quaternion lookRot = Quaternion.LookRotation(lookDir);
        lookRot.x = 0;
        lookRot.z = 0;

        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * other.lookSpeed);
        transform.rotation = newRotation;
    }
}
