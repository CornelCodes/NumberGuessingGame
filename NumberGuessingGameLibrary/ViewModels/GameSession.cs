using NumberGuessingGameLibrary.Factories;
using NumberGuessingGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberGuessingGameLibrary.ViewModels
{
    public class GameSession
    {
        private Player _player;
        private RandomNumberFactory _rng;
        private int _currentRandomNumber;
        private int _currentGuess;
        private int _scoreToAdd = 5;
        private bool _gameRunning = false;

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public GameSession()
        {
            StartGame();
        }

        private void InitializeGameObjects()
        {
            Player = new Player();
            _rng = new RandomNumberFactory();

        }

        private void StartGame()
        {
            _gameRunning = true;
            InitializeGameObjects();
            ShowGameRules();
            while (_gameRunning)
            {
                Console.Clear();
                StartRound();
            }
        }

        private void StartRound()
        {
            Console.WriteLine($"Score: {Player.Score} Lives: {Player.Lives}");
            Console.WriteLine("Pick a number from 1 to 5");
            _currentRandomNumber = _rng.GetRandomNumber();
            _currentGuess = Int32.Parse(Console.ReadLine());
            CheckGuess();
        }

        private void ShowGameRules()
        {
            Console.WriteLine("Welcome to Random Number Guesser." +
                "\nYou have 3 lives and will be awarded points for each correct guess" +
                "\nYou will lose a life for each incorrect guess" +
                "\nYou will gain a life for every 10 points" +
                "\nPress Enter to start");
            Console.ReadLine();
        }

        private void CheckGuess()
        {
            if (_currentGuess == _currentRandomNumber)
            {
                Console.WriteLine("Correct!");
                Thread.Sleep(2000);
                Player.Score += _scoreToAdd;
                if(Player.Score > 0 && Player.Score % 10 == 0)
                {
                    Player.Lives += 1;
                }
            }
            else
            {
                Console.WriteLine($"Wrong! Correct number was {_currentRandomNumber}");
                Thread.Sleep(2000);
                Player.Lives--;
                if(Player.Lives == 0)
                {
                    EndGame();
                }
            }
        }

        private void EndGame()
        {
            Console.Clear();
            Console.WriteLine($"Game over\nFinal score:{Player.Score}");

            Player.Score = 0;
            Player.Lives = 3;

            _gameRunning = false;
        }

    }
}
