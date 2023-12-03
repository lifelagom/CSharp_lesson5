// ввод данных
using System.Diagnostics.CodeAnalysis;

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
// квадраты четных элементов
void ChangeMatrix(int[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); i+=2){
        for(int j = 0; j < matrix.GetLength(1); j+=2) {
            matrix[i, j] = (int)Math.Pow(matrix[i,j], 2);
        }
    }
}
// сумма главной диагонали
int SumMainDiagonal(int[,] matrix) {
    int sum = 0;
    for(int i = 0; i < matrix.GetLength(0) && i< matrix.GetLength(1); i++){
        sum += matrix[i, i];
    }
    return sum;
}
// Среднее арифметическое строк массива
double[] FindAverageInRows(int[,] matrix) {
    double[] averageArray = new double[matrix.GetLength(0)];
    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++) {
            averageArray[i] += matrix[i,j];
        }
        averageArray[i] = Math.Round(averageArray[i] / matrix.GetLength(1), 3);
    }
    return averageArray;
}

void PrintArray(double[] array) {
    Console.WriteLine("["+string.Join(" | ", array)+"]");
}

int rows = ReadInt("Введите количество строк в массиве: ");
int cols = ReadInt("Введите количество столбцов в массиве: ");
int[,] matrix = GenerateMatrix(rows, cols, -9, 9);
PrintMatrix(matrix);
Console.WriteLine();
//ChangeMatrix(matrix);
//PrintMatrix(matrix);
//Console.WriteLine(SumMainDiagonal(matrix));
double[] averageArray = FindAverageInRows(matrix);
PrintArray(averageArray);