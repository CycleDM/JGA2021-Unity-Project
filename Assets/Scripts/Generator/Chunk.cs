using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour 
{
    public enum BlockType
    {
        None = 0,
        Garden,
        Building,
        Road,
    }

    // For restoring chunk data
    public static List<Chunk> chunks = new List<Chunk>();
    public static int width = 32;
    public static int height = 64;

    // Block informations
    BlockType[,,] blockMap;

    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start () 
    {
        // Init
        this.transform.localScale = new Vector3((float)width, 2.0f, (float)width);

        // Add self
        chunks.Add(this);

        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();

        InitMap();
    }

    // Initialize
    void InitMap()
    {

    }

    // Update is called once per frame
    void Update () 
    {

    }
}