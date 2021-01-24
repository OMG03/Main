using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5
{
    public delegate void PersonKilledEventHander();

    public abstract class Person
    {
        private int lives;
        private event PersonKilledEventHander killed;

        public Person(string name, int lives = 0)
        {
            this.Name = name;
            this.lives = lives;
        }

        public string Name { get; set; }

        public abstract void OnAttacked(object sender);

        public void WhenKilled(PersonKilledEventHander hander)
        {
            this.killed = hander;
        }

        public virtual void TryToKill()
        {
            this.lives--;
            if (lives <= 0)
            {
                this.OnKilled();
            }
        }

        private void OnKilled()
        {
            this.killed?.Invoke();
        }
    }
}
