// See https://aka.ms/new-console-template for more information
using DemoObserverPattern.ObjectTypes;
using DemoObserverPattern.Observers;
using DemoObserverPattern.Subjects;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        StartGame();
    }
    public static void StartGame()
    {
        var player = new Player("Daniel");
        var playerTracker = new PlayerActionTracker();
        var playerAudioSystem = new PlayerAudioSystem();

        playerTracker.Subscribe(playerAudioSystem);

        Thread.Sleep(1000);
        player.Action = PlayerAction.Attack;
        playerTracker.OnNext(player.Action);
        Thread.Sleep(100000);
    }
}