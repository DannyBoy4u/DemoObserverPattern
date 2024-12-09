using DemoObserverPattern.Subjects;
using System.Reactive;

namespace DemoObserverPattern.ObjectTypes
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;

        public PlayerAction Action { get; set; }
    }


    public enum PlayerAction
    {
        Attack = 1,
        Jump = 2,
        Roll = 3
    }
}
