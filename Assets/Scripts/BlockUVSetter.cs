using UnityEngine;

//Made by Adrian 'Aheradin' Armesto
//Date of Creation 25/02/2020 18:04

namespace PokeUtility 
{
    [ExecuteInEditMode]
	public class BlockUVSetter : MonoBehaviour 
	{

        #region Variables

        //Serialized Variables
        [SerializeField] private float tileSize = 32;
        [SerializeField] private int tilePosX = 1;
        [SerializeField] private int tilePosY = 1;

		//Private Variables

		#endregion
		
		#region Properties
		public float TileSize { get { return tileSize; } }
		public float TilePosX { get { return tilePosX; } }
		public float TilePosY { get { return tilePosY; } }
		#endregion
		
		#region MonoBehaviour

		private void Start () 
		{
            CalculateUVs();
		}
		
		private void Update () 
		{
		}
		
		#endregion
		
		#region Public Methods
		
		#endregion
		
		#region Private Methods
		
        private void CalculateUVs()
        {
            if (tileSize < 1) return; 
            float tilePercentage = 1 / tileSize;

            float uMin = tilePercentage * tilePosX;
            float uMax = tilePercentage * (tilePosX + 1);

            float vMin = tilePercentage * tilePosY;
            float vMax = tilePercentage * (tilePosY + 1);

            Vector2[] blockUVs = new Vector2[24];

            blockUVs[0] = new Vector2(uMin, vMin); 
            blockUVs[1] = new Vector2(uMax, vMin); 
            blockUVs[2] = new Vector2(uMin, vMax); 
            blockUVs[3] = new Vector2(uMax, vMax); 
            blockUVs[4] = new Vector2(uMin, vMax); 
            blockUVs[5] = new Vector2(uMax, vMax); 
            blockUVs[6] = new Vector2(uMin, vMax); 
            blockUVs[7] = new Vector2(uMax, vMax); 
            blockUVs[8] = new Vector2(uMin, vMin); 
            blockUVs[9] = new Vector2(uMax, vMin); 
            blockUVs[10] = new Vector2(uMin, vMin); 
            blockUVs[11] = new Vector2(uMax, vMin); 
            blockUVs[12] = new Vector2(uMin, vMin); 
            blockUVs[13] = new Vector2(uMin, vMax); 
            blockUVs[14] = new Vector2(uMax, vMax); 
            blockUVs[15] = new Vector2(uMax, vMin); 
            blockUVs[16] = new Vector2(uMin, vMin); 
            blockUVs[17] = new Vector2(uMin, vMax); 
            blockUVs[18] = new Vector2(uMax, vMax); 
            blockUVs[19] = new Vector2(uMax, vMin); 
            blockUVs[20] = new Vector2(uMin, vMin); 
            blockUVs[21] = new Vector2(uMin, vMax); 
            blockUVs[22] = new Vector2(uMax, vMax); 
            blockUVs[23] = new Vector2(uMax, vMin);

            gameObject.GetComponent<MeshFilter>().sharedMesh.uv = blockUVs;

        }

		#endregion
	}
}
