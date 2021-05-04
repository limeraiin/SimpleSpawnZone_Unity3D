using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZone : MonoBehaviour
{
	[SerializeField]private GameObject target;
	[SerializeField] private int spawnCount;
    void OnDrawGizmos ()
    {
	     
	    Gizmos.color=new Color(0.62f, 1f, 0.45f,0.4f);
	    Gizmos.DrawCube(transform.position,transform.localScale);
    }

    private void Start()
    {
	    StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
	    var scale = transform.localScale;
	    for (int i = 0; i < spawnCount; i++)
	    {
		    var randX = Random.Range(scale.x / 2,-scale.x / 2);
		    var randY = Random.Range(scale.y / 2,-scale.y / 2);
		    var randZ = Random.Range(scale.z / 2,-scale.z / 2);
		    var spawnPos=new Vector3(randX,randY,randZ);
		    Instantiate(target, spawnPos, Quaternion.identity);
		    yield return new WaitForSecondsRealtime(0.2f);
	    }
    }
}
