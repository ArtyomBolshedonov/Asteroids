using UnityEngine;


namespace Asteroids
{
    internal sealed class EnemyReference
    {
        private Asteroid _asteroid;
        private Meteor _meteor;
        private Comet _comet;
        private EnemyShip _enemyShip;
        
        internal Asteroid Asteroid
        {
            get
            {
                if (_asteroid == null)
                {
                    _asteroid = Resources.Load<Asteroid>("Asteroid");
                }
                return _asteroid;
            }
        }

        internal Meteor Meteor
        {
            get
            {
                if (_meteor == null)
                {
                    _meteor = Resources.Load<Meteor>("Meteor");
                }
                return _meteor;
            }
        }

        internal Comet Comet
        {
            get
            {
                if (_comet == null)
                {
                    _comet = Resources.Load<Comet>("Comet");
                }
                return _comet;
            }
        }

        internal EnemyShip EnemyShip
        {
            get
            {
                if (_enemyShip == null)
                {
                    _enemyShip = Resources.Load<EnemyShip>("EnemyShip");
                }
                return _enemyShip;
            }
        }
    }
}
