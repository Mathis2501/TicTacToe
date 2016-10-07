using System;
using TicTacToe.UnitTests;

namespace TicTacToe.Services
{
    public class GameWinnerService : IGameWinnerService
    {
        public GameWinnerService()
        {
            
        }
        // Start Settings

        

        // End Setting

        // Start Varibles

       

        char[,] _gameBoard = new char[3, 3] { {' ', ' ', ' '},
                                         {' ', ' ', ' '},
                                         {' ', ' ', ' '}};
        bool game;
        int actioncounter;
        string choice;
        bool running = true;
        char player = ' ';
        int[] piececounter = new int[2] { 0, 0 }; // slot 0 is for x, and slot 1 is for o
        char startingPlayer;

        // End Varibles

        // Start Program

        static void Main()
        {
            GameWinnerService ticTacToe = new GameWinnerService();
            ticTacToe.run();
        }

        private void run()
        {
            while (running == true)
            {
                ShowMenu();
                choice = GetUserChoiceForMenu();
                switch (choice)
                {
                    case "1":
                        SetStartingPlayer('X');
                        game = true;
                        actioncounter = 0;
                        piececounter[0] = 0;
                        piececounter[1] = 0;
                        ShowBlankBoard();
                        ShowBoard();
                        Console.WriteLine("Player " + startingPlayer + " starts");
                        while (game == true)
                        {
                            ChosePiecePos();

                            ShowBoard();

                            if (Validate(_gameBoard) == player)
                            {
                                GameOver();
                            }
                            SwapPlayer();

                            if (CheckIfPlayerHasThreePieces() == true)
                            {
                                MovePiece();
                            }

                            actioncounter++;
                        }
                        break;
                    case "9":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong or you chose a invalid number / charecter");
                        break;
                }
            }

        }
        // End Program

        // Start Methods

        private void SwapPlayer()
        {
            if (player == 'x')
            {
                player = 'o';
                Console.WriteLine("Players o's Turn");
            }
            else
            {
                player = 'x';
                Console.WriteLine("Player x's Turn");
            }
        }

        private void ChosePiecePos()
        {
            int tempx = 0;
            int tempy = 0;
            int xcord = 0;
            int ycord = 0;

            Console.WriteLine("What is the x cordinat of the place you wish to place at?");
            Console.WriteLine("x: ");
            Int32.TryParse(Console.ReadLine(), out tempx);

            if (0 <= tempx && tempx <= 2)
            {
                xcord = tempx;
            }
            else
            {
                Console.WriteLine("Invalid x number or charecter, try again");
                Console.ReadLine();
                ChosePiecePos();
            }

            Console.WriteLine("What is the y cordinat of the place you wish to place at?");
            Console.WriteLine("y: ");
            Int32.TryParse(Console.ReadLine(), out tempy);

            if (0 <= tempy && tempy <= 2)
            {
                ycord = tempy;
            }
            else
            {
                Console.WriteLine("Invalid y number or charecter, try again");
                Console.ReadLine();
                ChosePiecePos();
            }

            if (_gameBoard[xcord, ycord] == ' ')
            {
                _gameBoard[xcord, ycord] = player;
            }
            else
            {
                Console.WriteLine("That slot already has a piece in it, try another");
                ChosePiecePos();
            }


            if (_gameBoard[xcord, ycord] == player)
            {
                if (player == 'x')
                {
                    if (0 <= piececounter[0] && piececounter[0] <= 2)
                    {
                        piececounter[0]++;
                    }
                }
                if (player == 'o')
                {
                    if (0 <= piececounter[1] && piececounter[1] <= 2)
                    {
                        piececounter[1]++;
                    }
                }
            }

        }

        private bool CheckIfPlayerHasThreePieces()
        {
            switch (player)
            {
                case 'x':
                    if (piececounter[0] == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 'o':
                    if (piececounter[1] == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;

            }
        }

        public char Validate(char[,] gameBoard)
        {
            if (CheckIfPlayerHasThreePieces() == true)
            {
                if ((_gameBoard[0, 0] == _gameBoard[1, 0] && _gameBoard[0, 0] == _gameBoard[2, 0]
                    || _gameBoard[0, 1] == _gameBoard[1, 1] && _gameBoard[0, 1] == _gameBoard[2, 1]
                    || _gameBoard[0, 2] == _gameBoard[1, 2] && _gameBoard[0, 2] == _gameBoard[2, 2]
                    || _gameBoard[0, 0] == _gameBoard[0, 1] && _gameBoard[0, 0] == _gameBoard[0, 2]
                    || _gameBoard[1, 0] == _gameBoard[1, 1] && _gameBoard[1, 0] == _gameBoard[1, 2]
                    || _gameBoard[2, 0] == _gameBoard[2, 1] && _gameBoard[2, 0] == _gameBoard[2, 2]
                    || _gameBoard[2, 0] == _gameBoard[1, 1] && _gameBoard[2, 0] == _gameBoard[0, 2]
                    || _gameBoard[0, 0] == _gameBoard[1, 1] && _gameBoard[0, 0] == _gameBoard[2, 2]))
                {
                    return player;
                }
                else
                {
                    return player;
                }
            }
            else
            {
                return player;
            }
        }

        private void ShowBoard()
        {
            Console.WriteLine(" " + _gameBoard[0, 0] + " | " + _gameBoard[1, 0] + " | " + _gameBoard[2, 0] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + _gameBoard[0, 1] + " | " + _gameBoard[1, 1] + " | " + _gameBoard[2, 1] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + _gameBoard[0, 2] + " | " + _gameBoard[1, 2] + " | " + _gameBoard[2, 2] + " ");
        }

        private void ShowBlankBoard()
        {
            Console.WriteLine(" 0,0 | 1,0 | 2,0 ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine(" 0,1 | 1,1 | 2,1 ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine(" 0,2 | 1,2 | 2,2 ");
            Console.WriteLine("Remember these cordinates as they are used to play the game");
        }

        public void SetStartingPlayer(char startPlayer)
        {
            player = startPlayer;
        }

        private string GetUserChoiceForMenu()
        {
            Console.WriteLine("Type your choice: ");
            string temp = Console.ReadLine();
            return temp;
        }

        private void ShowMenu()
        {
            Console.WriteLine("1 = New Tic Tac Toe Game");
            Console.WriteLine("9 = Exit");
        }

        private void MovePiece()
        {
            int tempx;
            int tempy;
            int xcord = 0;
            int ycord = 0;

            Console.WriteLine("You have 3 pieces on the _gameBoard already");
            Console.WriteLine("What is the x cordinat of the piece you wish to move?");
            Console.WriteLine("x: ");
            Int32.TryParse(Console.ReadLine(), out tempx);

            if (0 <= tempx && tempx <= 2)
            {
                xcord = tempx;
            }
            else
            {
                Console.WriteLine("Invalid x number or charecter, try again");
                MovePiece();
            }

            Console.WriteLine("What is the y cordinat of the peice you wish to move?");
            Console.WriteLine("y: ");
            Int32.TryParse(Console.ReadLine(), out tempy);

            if (0 <= tempy && tempy <= 2)
            {
                ycord = tempy;
            }
            else
            {
                Console.WriteLine("Invalid y number or charecter, try again");
                MovePiece();
            }

            if (_gameBoard[xcord, ycord] == player)
            {
                _gameBoard[xcord, ycord] = ' ';
            }
            else
            {
                Console.WriteLine("That slot is empty or not yours, try another");
                MovePiece();
            }


            if (_gameBoard[xcord, ycord] == player)
            {
                if (player == 'x')
                {
                    if (0 <= piececounter[0] && piececounter[0] <= 2)
                    {
                        piececounter[0]--;
                    }
                }
                if (player == 'o')
                {
                    if (0 <= piececounter[1] && piececounter[1] <= 2)
                    {
                        piececounter[1]--;
                    }
                }
            }
        }

        private void GameOver()
        {
            Console.WriteLine("Player " + player + " have won the game");
            Console.WriteLine("The game had " + actioncounter + " actions");
            game = false;
            Console.ReadLine();
        }
        // End Methods

        // Start Overides

        // End Overides
        
        
    }
}
