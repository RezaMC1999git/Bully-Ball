using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour  
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites; 
    
    //cached reference
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if(tag=="Breakable")
            level.CountBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if(tag=="Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length +1; 
            if(timesHit>=maxHits)
                DestroyBlock();
            else
            {
                ShowNextHitSprites();
            }
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles,1f);
    }
    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit -1;
        if(hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Missing Sprite!" + gameObject.name);
    }
}
