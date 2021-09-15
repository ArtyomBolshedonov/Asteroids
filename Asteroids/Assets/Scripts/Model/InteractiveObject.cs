using UnityEngine;


namespace Asteroids
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _damage;
        [SerializeField] protected long _scores;
        private bool _isInteractable;
        protected Player Player;

        private void Start()
        {
            Player = FindObjectOfType<Player>();
            _isInteractable = true;
        }

        public bool IsInteractable
        {
            get { return _isInteractable; }
            protected set
            {
                _isInteractable = value;
                gameObject.SetActive(_isInteractable);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Interaction();
            }
            else SelfInteraction();
        }

        protected virtual void Interaction()
        {
            Player.Health -= _damage;
        }

        protected abstract void SelfInteraction();
    }
}
