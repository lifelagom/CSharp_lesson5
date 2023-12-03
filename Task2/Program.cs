// Задайте двумерный массив. Напишите программу, 
// которая поменяет местами первую и последнюю строку массива.

// ввод данных
int ReadInt(string text) {
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}
// создаем массив
int[,] GenerateMatrix(int row, int col, int leftRange, int rightRange) {
    int[,] tempMatrix = new int[row,col];
    Random rand = new Random();
    for(int i = 0; i < tempMatrix.GetLength(0); i++){
        for(int j = 0; j < tempMatrix.GetLength(1); j++) {
            tempMatrix[i,j] = rand.Next(leftRange, rightRange+1);
        }
    }
    return tempMatrix;
}
// вывод массива
void PrintMatrix(int[,] matrixForPrint) {
    for(int i = 0; i < matrixForPrint.GetLength(0); i++){
        for(int j = 0; j < matrixForPrint.GetLength(1); j++) {
            Console.Write(matrixForPrint[i,j]+"\t");
        }
        Console.WriteLine();
    }
}
// обмен первой и последней строки массива
void ChangeMatrix(int[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); i += matrix.GetLength(0)-1) {
        for(int j = 0; j < matrix.GetLength(1); j++) {
            int temp = matrix[i, j];
            matrix[i, j] = matrix[matrix.GetLength(0)-1,j];
            matrix[matrix.GetLength(0)-1,j] = temp;
        }
    }
}

int rows = ReadInt("Введите количество строк в массиве: ");
int cols = ReadInt("Введите количество столбцов в массиве: ");
int[,] matrix = GenerateMatrix(rows, cols, 0, 9);
PrintMatrix(matrix);
Console.WriteLine(" => ");
ChangeMatrix(matrix);
PrintMatrix(matrix);