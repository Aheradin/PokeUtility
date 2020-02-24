using UnityEngine;
using System;

//Made by Adrian 'Aheradin' Armesto
//Date of Creation 24/02/2020 22:52

namespace PokeUtility {

	public class BlockMeshAdder : MonoBehaviour {

        #region Variables

        //Serialized Variables
        [SerializeField] private float rayDistance = 1000.0f;
        [SerializeField] private GameObject newBlock;

        //Private Variables

        private Camera cam;

        #endregion

        #region Properties

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            cam = Camera.main;
        }

        private void Start ()
        {
			
		}
		
		private void Update ()
        {
			if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, rayDistance))
                {
                    Vector3 blockPos = hit.point + hit.normal / 2.0f;

                    blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
                    blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
                    blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

                    GameObject block = (GameObject)Instantiate(newBlock, blockPos, Quaternion.identity);
                    block.transform.parent = this.transform;
                    Combine(block);
                }
            }
		}
		
		#endregion
		
		#region Public Methods
		
		#endregion
		
		#region Private Methods
		
        private void Combine(GameObject block)
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];
            Destroy(this.gameObject.GetComponent<MeshCollider>());

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);
                i++;
            }

            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine, true);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.Optimize();

            transform.GetComponent<MeshFilter>().mesh = mesh;

            this.gameObject.AddComponent<MeshCollider>();
            transform.gameObject.SetActive(true);

            Destroy(block);

        }

		#endregion
	}
}
