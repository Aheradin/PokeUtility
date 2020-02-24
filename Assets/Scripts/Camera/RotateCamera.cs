using UnityEngine;

//Made by Adrian 'Aheradin' Armesto
//Date of Creation 24/02/2020 22:01

namespace PokeUtility {

	public class RotateCamera : MonoBehaviour {

        #region Variables

        //Serialized Variables
        [SerializeField] private float speed = 50;

        //Private Variables
        private Camera cam;

        #endregion

        #region Properties

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            cam = GetComponent<Camera>();
        }

        private void Start () {
			
		}
		
		private void Update () {
			if(Input.GetKey(KeyCode.J))
            {
               cam.transform.RotateAround((Vector3.zero), Vector3.up, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.L))
            {
                cam.transform.RotateAround((Vector3.zero), Vector3.up, -speed * Time.deltaTime);
            }
        }
		
		#endregion
		
		#region Public Methods
		
		#endregion
		
		#region Private Methods
		
		#endregion
	}
}
