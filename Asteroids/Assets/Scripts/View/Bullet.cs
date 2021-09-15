using UnityEngine;
using Asteroids.ObjectPool;


namespace Asteroids
{
    internal class Bullet : InteractiveObject
    {
        private Transform _rootPool;

        protected Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMO);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }

        public void ActiveBullet(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        public void BulletFly(Vector3 direction)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }

        protected override void Interaction()
        {
            ReturnToPool();
            base.Interaction();
        }

        protected override void SelfInteraction()
        {
            ReturnToPool();
        }
    }
}
