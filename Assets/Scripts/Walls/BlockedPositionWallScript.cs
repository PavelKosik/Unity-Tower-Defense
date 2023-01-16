using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedPositionWallScript : MonoBehaviour
{
    public List<Vector3> blockedPosition;
    public float distanceBetweenWalls;
    // Start is called before the first frame update
    void Start()
    {
        blockedPosition = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PositionOpen(Vector3 positionToBePlacedAt)
    {
        // for the position to be blocked, there has to be some elements in blockedPosition array
        // else there is nothing to block the position
        if (blockedPosition.Count>0) {


            for (int i = 0; i < blockedPosition.Count; i++)
            {
                // we look at each position in the array and check if the positionToBePlacetAt is close enough
                // if it is close enough the blocked position it can't be placed there so the function returns false
                if ((positionToBePlacedAt.x - distanceBetweenWalls < blockedPosition[i].x && positionToBePlacedAt.x + distanceBetweenWalls > blockedPosition[i].x) && (positionToBePlacedAt.y - distanceBetweenWalls < blockedPosition[i].y && positionToBePlacedAt.y + distanceBetweenWalls > blockedPosition[i].y))
                {                  
                    return false;
                } 
            }
        }

        // the blockedPosition array is empty so we add positionToBePlacedAt to the array and return true
        else
        {           
            blockedPosition.Add(positionToBePlacedAt);
            return true;
        }

        // if the function doesn't return in the for loop it means that the positionToBePlacedAt isn't close enough
        // to any of the blocked positions so we can add it to blockedPosition array and return true
        blockedPosition.Add(positionToBePlacedAt);
        return true;
    }

    public void RemovePosition(Vector3 positionToRemove)
    {
        // when the walls gets destroyed the foor loop searches for the blockedPosition of the destroyed turret
        // and removes it from the array because the wall is no longer there so it shouldn't block the position
        for (int i=0;i<blockedPosition.Count;i++)
        {           
            // the number 2 is there to make sure the correct position is found and removed
            // even if it would not be exactly on the same position
            // because the wall gets snapped a bit after placing
            if ((positionToRemove.x - 2 < blockedPosition[i].x && positionToRemove.x + 2 > blockedPosition[i].x) && (positionToRemove.y - 2 < blockedPosition[i].y && positionToRemove.y + 2 > blockedPosition[i].y))
            {
                blockedPosition.RemoveAt(i);                
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i=0;i<blockedPosition.Count;i++)
        {
            Gizmos.DrawCube(blockedPosition[i], Vector3.one);
        }
    }
}
