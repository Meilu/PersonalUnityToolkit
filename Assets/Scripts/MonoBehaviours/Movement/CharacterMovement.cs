using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MonoBehaviours.Movement
{
    public class CharacterMovement : CreatureMovement
    {
        public GameObject tilemapGameObject;
        public GameObject digParticlesPrefab;
        private Tilemap _tilemap;
        
        
        private List<Vector3> _tileHitPositions;
        private LayerMask _floorLayerMask;
        
        private void Start()
        {
            base.Start();
            _tileHitPositions = new List<Vector3>();
            _floorLayerMask = LayerMask.NameToLayer ("Floor");
            
            if (tilemapGameObject != null)
            {
                _tilemap = tilemapGameObject.GetComponent<Tilemap>();
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveVertical();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Dig();
            }
            
            var horizontalMovement = Input.GetAxis(CapsuleDirection2D.Horizontal.ToString());
            MoveHorizontal(horizontalMovement);
        }

        private void Dig()
        {
            var position = transform.position;
            var direction = Vector2.down;
            float distance = 10.0f;
            
            // Cast a ray downwards and see what we hit.
            var hit = Physics2D.Raycast(position, direction, distance);
            
            // Somehow we are not on the ground.
            if (hit.collider == null)
                return;

            var point = hit.point;
            var tilePos = _tilemap.WorldToCell(point);
            _tilemap.SetTile(tilePos, null);
            var digParticles = Instantiate (digParticlesPrefab);
            digParticles.transform.position = transform.position;

        }
    }
}