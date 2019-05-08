using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Sneaking
{
    public class Enemy
    {
        public char Status { get; set; }

        public int RowIndex { get; set; }

        public int ColIndex { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var matrix = new char[input][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            var directions = Console.ReadLine().ToCharArray();
            var directionsQueue = new Queue<char>(directions);
            var mainHeroCoords = new int[2];
            var enemies = new List<Enemy>();
            var levelBossCoords = new int[2];

            FindEnemies(matrix, mainHeroCoords, enemies, levelBossCoords);

            StartTheGame(matrix, mainHeroCoords, enemies, levelBossCoords, directionsQueue);
        }

        public static void StartTheGame(char[][] matrix, int[] mainHeroCoords, List<Enemy> enemies, int[] levelBossCoords, Queue<char> directionsQueue)
        {
            while (directionsQueue.Count > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    var currentEnemy = enemies[i];

                    switch (currentEnemy.Status)
                    {
                        case 'b':
                            var row = currentEnemy.RowIndex;
                            var col = currentEnemy.ColIndex;
                            if (currentEnemy.ColIndex + 1 <= matrix[row].Length - 1)
                            {
                                matrix[currentEnemy.RowIndex][currentEnemy.ColIndex] = '.';
                                enemies[i].ColIndex++;
                                matrix[currentEnemy.RowIndex][currentEnemy.ColIndex] = 'b';
                                break;
                            }
                            else
                            {
                                if (currentEnemy.ColIndex == matrix[row].Length - 1)
                                {
                                    enemies[i].Status = 'd';
                                    matrix[currentEnemy.RowIndex][currentEnemy.ColIndex] = 'd';

                                    if (row == mainHeroCoords[0])
                                    {
                                        if (col > mainHeroCoords[1])
                                        {
                                            matrix[mainHeroCoords[0]][mainHeroCoords[1]] = 'X';
                                            Console.WriteLine($"Sam died at {mainHeroCoords[0]}, {mainHeroCoords[1]}");
                                            PrintMatrix(matrix);
                                            return;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        case 'd':
                            row = enemies[i].RowIndex;
                            col = enemies[i].ColIndex;

                            if (currentEnemy.ColIndex > 0)
                            {
                                matrix[row][col] = '.';
                                enemies[i].ColIndex--;
                                matrix[row][enemies[i].ColIndex] = 'd';
                                break;
                            }
                            else
                            {
                                if (currentEnemy.ColIndex == 0)
                                {
                                    enemies[i].Status = 'b';
                                    matrix[row][col] = 'b';

                                    if (row == mainHeroCoords[0])
                                    {
                                        if (col < mainHeroCoords[1])
                                        {
                                            matrix[mainHeroCoords[0]][mainHeroCoords[1]] = 'X';
                                            Console.WriteLine($"Sam died at {mainHeroCoords[0]}, {mainHeroCoords[1]}");
                                            PrintMatrix(matrix);
                                            return;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                    }
                }

                var currendHeroMove = directionsQueue.Dequeue();
                var heroRow = mainHeroCoords[0];
                var heroCol = mainHeroCoords[1];

                switch (currendHeroMove)
                {
                    case 'W':
                        break;
                    case 'L':
                        matrix[heroRow][heroCol] = '.';
                        heroCol--;
                        mainHeroCoords[1]--;
                        matrix[heroRow][heroCol] = 'S';
                        break;
                    case 'R':
                        matrix[heroRow][heroCol] = '.';
                        heroCol++;
                        mainHeroCoords[1]++;
                        matrix[heroRow][heroCol] = 'S';
                        break;
                    case 'D':
                        matrix[heroRow][heroCol] = '.';
                        heroRow++;
                        mainHeroCoords[0]++;
                        matrix[heroRow][heroCol] = 'S';
                        break;
                    case 'U':
                        matrix[heroRow][heroCol] = '.';
                        heroRow--;
                        mainHeroCoords[0]--;
                        matrix[heroRow][heroCol] = 'S';
                        break;
                }


                var rowEnemy = enemies.FirstOrDefault(x => x.RowIndex == mainHeroCoords[0]);

                if (rowEnemy == null)
                {
                    if (levelBossCoords[0] == mainHeroCoords[0])
                    {
                        matrix[heroRow][heroCol] = 'S';
                        Console.WriteLine("Nikoladze killed!");
                        var bossRow = levelBossCoords[0];
                        var bossCol = levelBossCoords[1];
                        matrix[bossRow][bossCol] = 'X';

                        PrintMatrix(matrix);
                        return;
                    }
                    else
                    {
                        matrix[heroRow][heroCol] = 'S';
                        continue;
                    }
                }
                else
                {
                    var enemyCol = rowEnemy.ColIndex;
                    var enemyIndex = enemies.IndexOf(rowEnemy);

                    if (rowEnemy.Status == 'b')
                    {
                        if (heroCol == enemyCol)
                        {
                            matrix[heroRow][heroCol] = 'S';
                            enemies.RemoveAt(enemyIndex);
                        }
                        else
                        {
                            if (enemyCol < heroCol)
                            {
                                matrix[heroRow][heroCol] = 'X';
                                Console.WriteLine($"Sam died at {heroRow}, {heroCol}");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[heroRow][heroCol] = 'S';
                                continue;
                            }
                        }
                    }
                    else if (rowEnemy.Status == 'd')
                    {
                        if (heroCol == enemyCol)
                        {
                            matrix[heroRow][heroCol] = 'S';
                            enemies.RemoveAt(enemyIndex);
                        }
                        else
                        {
                            if (enemyCol > heroCol)
                            {
                                matrix[heroRow][heroCol] = 'X';
                                Console.WriteLine($"Sam died at {heroRow}, {heroCol}");
                                PrintMatrix(matrix);
                                return;
                            }
                            else
                            {
                                matrix[heroRow][heroCol] = 'S';
                                continue;
                            }
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        public static void FindEnemies(char[][] matrix, int[] mainHeroCoords, List<Enemy> enemies, int[] levelBossCoords)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var currentCharacter = matrix[i][j];

                    switch (currentCharacter)
                    {
                        case 'N':
                            levelBossCoords[0] = i;
                            levelBossCoords[1] = j;
                            break;
                        case 'b':
                            var enemy = new Enemy()
                            {
                                Status = 'b',
                                RowIndex = i,
                                ColIndex = j
                            };
                            enemies.Add(enemy);
                            break;
                        case 'd':
                            enemy = new Enemy()
                            {
                                Status = 'd',
                                RowIndex = i,
                                ColIndex = j
                            };
                            enemies.Add(enemy);
                            break;
                        case 'S':
                            mainHeroCoords[0] = i;
                            mainHeroCoords[1] = j;
                            break;
                    }
                }
            }
        }
    }
}
