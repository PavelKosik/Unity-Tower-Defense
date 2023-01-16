using System.IO;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        public bool attacking;
        public EnemyAttackWallsScript enemyAttackWallsScript;
        public EnemyBehavior enemyBehavior;
        void Start() {

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            enemyAttackWallsScript = GetComponent<EnemyAttackWallsScript>();
            enemyBehavior = GetComponent<EnemyBehavior>();
        }

        void Update()
        {
            if (pathCreator != null && attacking == false && enemyBehavior.alive)
            {
                if (enemyAttackWallsScript.arrived<=0) {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

                    //point enemy is going to stand on next frame
                    Vector3 pointOnPath = pathCreator.path.GetPointAtDistance(distanceTravelled + (speed * Time.deltaTime), endOfPathInstruction);
                    Ray ray = new Ray(transform.position, pointOnPath - transform.position);


                    Quaternion lookRotation = Quaternion.LookRotation(transform.forward, ray.direction);
                    transform.rotation = lookRotation;
                }

                else
                {
                    enemyAttackWallsScript.arrived -= Time.deltaTime*speed;
                }
            }

         
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}