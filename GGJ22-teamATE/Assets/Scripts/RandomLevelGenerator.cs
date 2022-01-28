using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public List<GameObject> m_chunks;

    public float m_chunkWidth = 20f;

    public float m_yPos = -4.1f;
    public float m_zPos = 4.08f;

    public float m_minimumGeneratedLength = 200f;

    public Vector3 m_nextPos;

    private float m_generatedPoint;
    private List<GameObject> m_liveChunks = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        var pox = transform.position.x;
        m_generatedPoint = pox - m_minimumGeneratedLength;
        var generateTo = pox + m_minimumGeneratedLength;

        m_nextPos = new Vector3(m_generatedPoint, m_yPos, m_zPos);

        while (m_generatedPoint < m_minimumGeneratedLength)
        {
            GenerateChunk();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Err");
        if (transform.position.x + m_minimumGeneratedLength > m_generatedPoint)
        {
            GenerateChunk();
            RemoveFirstChunk();
        }
    }
    
    private void GenerateChunk()
    {
        var rand = Random.Range(0, m_chunks.Count - 1);
        var instance = GameObject.Instantiate(m_chunks[rand], m_nextPos, Quaternion.identity);
        m_liveChunks.Add(instance);
        m_generatedPoint += m_chunkWidth;
        m_nextPos.x = m_generatedPoint;
    }

    private void RemoveFirstChunk()
    {
        var chunk = m_liveChunks[0];
        m_liveChunks.Remove(chunk);
        Destroy(chunk);
    }
}
