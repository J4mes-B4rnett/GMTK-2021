using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FlagPole : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int flagCellID;
    public List<TileBase> animationFrames;
    public float timeBetweenframes;

    void Start()
    {
        StartCoroutine(AnimateFlag(timeBetweenframes));
    }

    IEnumerator AnimateFlag(float t)
    {
        tilemap.SetTile(flagCellID, animationFrames[0]);
        yield return new WaitForSeconds(t);
        tilemap.SetTile(flagCellID, animationFrames[1]);
        yield return new WaitForSeconds(t);
        tilemap.SetTile(flagCellID, animationFrames[2]);
        yield return new WaitForSeconds(t);
        tilemap.SetTile(flagCellID, animationFrames[3]);
        yield return new WaitForSeconds(t);
        StartCoroutine(AnimateFlag(t));
    }
}