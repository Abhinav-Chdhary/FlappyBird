using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public MeshRenderer meshRenderer; //gets the component of Background
    public float terrainSpeed = 1f; //constant variable for effect of player moving forward

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(terrainSpeed * Time.deltaTime, 0);
        //moving the background as per the frame rate of the machine
    }
}
