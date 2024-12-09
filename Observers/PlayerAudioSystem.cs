
using DemoObserverPattern.ObjectTypes;
using System.Media;
using System.Reactive.Subjects;
namespace DemoObserverPattern.Observers;
    public class PlayerAudioSystem : IObserver<PlayerAction>
    {
        
        void IObserver<PlayerAction>.OnCompleted()
        {

        }

        void IObserver<PlayerAction>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<PlayerAction>.OnNext(PlayerAction action)
        {
            switch (action)
            {
                case PlayerAction.Attack:
                PlayAudioFile("PlayerAttack.wav");
                    break;

                case PlayerAction.Jump:
                    break;

                case PlayerAction.Roll:
                    break;
            }
        }


    void PlayAudioFile(string relativePath)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        
        // Check if the file exists
        if (File.Exists(filePath))
        {
            SoundPlayer soundPlayer = new();
            soundPlayer.SoundLocation = filePath;
            soundPlayer.Play();
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
        }
    }
    }

