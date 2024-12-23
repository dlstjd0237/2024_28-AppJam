using UnityEngine;

namespace BIS.Entities
{
    [RequireComponent(typeof(LineRenderer))]
    public class EntityLineRenderer : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        private LineRenderer _lineRenderer;

        public void Initalize(Entity entity)
        {
            _entity = entity;
            _lineRenderer = GetComponent<LineRenderer>();
        }


      public  void PredictTrajectory(Vector3 startPos, Vector3 vel)
        {
            int step = 60;
            float deltaTime = Time.fixedDeltaTime;
            Vector3 gravity = Physics.gravity;

            Vector3 position = startPos;
            Vector3 velocity = vel;

            for (int i = 0; i < step; i++)
            {
                position += velocity * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
                velocity += gravity * deltaTime;

                print(position);
            }
        }
    }

}
