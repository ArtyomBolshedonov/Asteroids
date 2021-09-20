using Asteroids.Observer;
using Asteroids.Command;
using System.Collections.Generic;



namespace Asteroids
{
    internal sealed class EventController : IExecute
    {
        private readonly List<Enemy> _enemies;
        private readonly HitPanel _hitPanel;
        
        public EventController(GameStarter gameStarter)
        {
            _enemies = gameStarter.GetEnemies();
            _hitPanel = gameStarter.GetUI().HitPanel;
            _hitPanel.Hide();

            foreach (var item in _enemies)
            {
                Add(item);
            }
        }

        private void Add(IHit value)
        {
            value.OnHitChange += ValueOnHitChange;
        }

        private void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnHitChange;
        }

        private void ValueOnHitChange(Enemy enemy)
        {
            _hitPanel.HitInfo = enemy.name;
            _hitPanel.Active();
        }

        public void Execute(float deltaTime)
        {
            foreach (var item in _enemies)
            {
                if (!item.IsInteractable)
                {
                    item.Hit(item);
                    Remove(item);
                }
            }
        }
    }
}
