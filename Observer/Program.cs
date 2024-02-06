using System;
using System.Collections.Generic;

// Subject interface
public interface IRandomNumberGenerator
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete subject class
public class RandomNumberGenerator : IRandomNumberGenerator
{
    private List<IObserver> _observers = new List<IObserver>();
    private Random _random = new Random();
    private int _randomNumber;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_randomNumber);
        }
    }

    public int GetRandomNumber()
    {
        return _random.Next(1, 11); 
    }

    public void GenerateNumber()
    {
        _randomNumber = GetRandomNumber();
        Notify(); 
    }
}

// Observer interface
public interface IObserver
{
    void Update(int randomNumber);
}

// Concrete observer class
public class Player : IObserver
{
    private RandomNumberGenerator _generator;

    public Player(RandomNumberGenerator generator)
    {
        _generator = generator;
    }

    public void Update(int randomNumber)
    {
        Play();
    }

    public void Play()
    {
        int guess;
        do
        {
            Console.Write("Enter your guess (between 1 and 10): ");
            guess = int.Parse(Console.ReadLine());

            if (guess == _generator.GetRandomNumber())
            {
                Console.WriteLine("Congratulations! You guessed the number!");
                return;
            }
            else
            {
                Console.WriteLine("Try again.");
            }
        } while (true);
    }
}

class Program
{
    static void Main(string[] args)
    {
        RandomNumberGenerator generator = new RandomNumberGenerator();
        Player player = new Player(generator);

        generator.Attach(player);

        generator.GenerateNumber();
    }
}
