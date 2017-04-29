// Не съм сменял текстовете в играта, не от мързел или недоглеждане, а защото те са дизайнерско решение :)
// На 43-ти ред имаше бъг който не засичаше, ако посочиш ред или колона с 1 по-голям от размерите на полето, хвърляше unhandled exception

namespace MinesGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
	{
		public static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] gameField = EmptyGameField();
			char[,] bombsLocations = PlaceBombs();
			int currentPlayerScore = 0;
			bool hasExploded = false;
			List<PlayerScore> bestScores = new List<PlayerScore>(6);
			int selectedRow = 0;
			int selectedColumn = 0;
			bool isStart = true;
			const int MAX_CORRECT_CELLS_COUNT = 35;
			bool isEnd = false;

			do
			{
				if (isStart)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					RevealBoard(gameField);
					isStart = false;
				}

				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out selectedRow) &&
					    int.TryParse(command[2].ToString(), out selectedColumn) &&
						selectedRow < gameField.GetLength(0) && selectedColumn < gameField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						TopScoresChart(bestScores);
						break;

					case "restart":
						gameField = EmptyGameField();
						bombsLocations = PlaceBombs();
						RevealBoard(gameField);
						hasExploded = false;
						isStart = false;
						break;

					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;

					case "turn":
						if (bombsLocations[selectedRow, selectedColumn] != '*')
						{
							if (bombsLocations[selectedRow, selectedColumn] == '-')
							{
								NextTurn(gameField, bombsLocations, selectedRow, selectedColumn);
								currentPlayerScore++;
							}

							if (MAX_CORRECT_CELLS_COUNT == currentPlayerScore)
							{
								isEnd = true;
							}
							else
							{
								RevealBoard(gameField);
							}
						}
						else
						{
							hasExploded = true;
						}

						break;

					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}

				if (hasExploded)
				{
					RevealBoard(bombsLocations);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + 
                        "Daj si niknejm: ", currentPlayerScore);

					string nickname = Console.ReadLine();
					PlayerScore currentPlayerFinalScore = new PlayerScore(nickname, currentPlayerScore);
					if (bestScores.Count < 5)
					{
						bestScores.Add(currentPlayerFinalScore);
					}
					else
					{
						for (int i = 0; i < bestScores.Count; i++)
						{
							if (bestScores[i].PlayerPoints < currentPlayerFinalScore.PlayerPoints)
							{
								bestScores.Insert(i, currentPlayerFinalScore);
								bestScores.RemoveAt(bestScores.Count - 1);
								break;
							}
						}
					}

					bestScores.Sort((PlayerScore playerCurrent, PlayerScore playerNext) => playerNext.PlayerName.CompareTo(playerCurrent.PlayerName));
					bestScores.Sort((PlayerScore playerCurrent, PlayerScore playerNext) => playerNext.PlayerPoints.CompareTo(playerCurrent.PlayerPoints));
					TopScoresChart(bestScores);

					gameField = EmptyGameField();
					bombsLocations = PlaceBombs();
					currentPlayerScore = 0;
					hasExploded = false;
					isStart = true;
				}

				if (isEnd)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					RevealBoard(bombsLocations);
					Console.WriteLine("Daj si imeto, batka: ");
					string playerName = Console.ReadLine();
					PlayerScore playerScore = new PlayerScore(playerName, currentPlayerScore);
					bestScores.Add(playerScore);
					TopScoresChart(bestScores);
					gameField = EmptyGameField();
					bombsLocations = PlaceBombs();
					currentPlayerScore = 0;
					isEnd = false;
					isStart = true;
				}
			}
			while (command != "exit");

			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void TopScoresChart(List<PlayerScore> scores)
		{
			Console.WriteLine("\nTo4KI:");
			if (scores.Count > 0)
			{
				for (int i = 0; i < scores.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, 
                        scores[i].PlayerName, scores[i].PlayerPoints);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void NextTurn(char[,] gameField,
			char[,] bombsLocations, int row, int column)
		{
			char surroundingBombsCount = SurroundingBombsCount(bombsLocations, row, column);
			bombsLocations[row, column] = surroundingBombsCount;
			gameField[row, column] = surroundingBombsCount;
		}

		private static void RevealBoard(char[,] board)
		{
			int rows = board.GetLength(0);
			int columns = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < columns; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] EmptyGameField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int rows = 5;
			int columns = 10;
			char[,] gameField = new char[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					gameField[i, j] = '-';
				}
			}

			List<int> randomNumbers = new List<int>();
			while (randomNumbers.Count < 15)
			{
				Random random = new Random();
				int randomNumber = random.Next(50);
				if (!randomNumbers.Contains(randomNumber))
				{
					randomNumbers.Add(randomNumber);
				}
			}

			foreach (int number in randomNumbers)
			{
				int column = number / columns;
				int row = number % columns;

				if (row == 0 && number != 0)
				{
					column--;
					row = columns;
				}
				else
				{
					row++;
				}

				gameField[column, row - 1] = '*';
			}

			return gameField;
		}

		private static void SurrowndingBombsCalculator(char[,] gameField)
		{
			int column = gameField.GetLength(0);
			int row = gameField.GetLength(1);

			for (int i = 0; i < column; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (gameField[i, j] != '*')
					{
						char surroundingBombsCount = SurroundingBombsCount(gameField, i, j);
						gameField[i, j] = surroundingBombsCount;
					}
				}
			}
		}

		private static char SurroundingBombsCount(char[,] gameField, int column, int row)
		{
			int count = 0;
			int rows = gameField.GetLength(0);
			int columns = gameField.GetLength(1);

			if (column - 1 >= 0)
			{
				if (gameField[column - 1, row] == '*')
				{ 
					count++; 
				}
			}

			if (column + 1 < rows)
			{
				if (gameField[column + 1, row] == '*')
				{ 
					count++; 
				}
			}

			if (row - 1 >= 0)
			{
				if (gameField[column, row - 1] == '*')
				{ 
					count++;
				}
			}

			if (row + 1 < columns)
			{
				if (gameField[column, row + 1] == '*')
				{ 
					count++;
				}
			}

			if ((column - 1 >= 0) && (row - 1 >= 0))
			{
				if (gameField[column - 1, row - 1] == '*')
				{ 
					count++; 
				}
			}

			if ((column - 1 >= 0) && (row + 1 < columns))
			{
				if (gameField[column - 1, row + 1] == '*')
				{ 
					count++; 
				}
			}

			if ((column + 1 < rows) && (row - 1 >= 0))
			{
				if (gameField[column + 1, row - 1] == '*')
				{ 
					count++; 
				}
			}

			if ((column + 1 < rows) && (row + 1 < columns))
			{
				if (gameField[column + 1, row + 1] == '*')
				{ 
					count++; 
				}
			}

			return char.Parse(count.ToString());
		}

        public class PlayerScore
        {
            private string playerName;
            private int playerPoints;
            
            public PlayerScore()
            {
            }

            public PlayerScore(string name, int points)
            {
                this.playerName = name;
                this.playerPoints = points;
            }

            public string PlayerName
            {
                get { return this.playerName; }
                set { this.playerName = value; }
            }

            public int PlayerPoints
            {
                get { return this.playerPoints; }
                set { this.playerPoints = value; }
            }
        }
    }
}
