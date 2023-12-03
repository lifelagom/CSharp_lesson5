// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

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
// сумма элементов строки
int SumString(int[,] matrix, int i) {
    int sumString = 0;
    for(int j = 0; j < matrix.GetLength(1); j++) {
        sumString += matrix[i,j];
    }
    return sumString;
}
// поиск строки с минимальной суммой элементов
int FindStringMin(int[,] matrix) {
    int minString = 0;
    for(int i = 0; i < matrix.GetLength(0)-1; i ++) {
        if (SumString(matrix, i)<SumString(matrix, i+1)) {
           minString = i; 
        }
    }
    return minString;
}

int rows = ReadInt("Введите количество строк в массиве: ");
int cols = ReadInt("Введите количество столбцов в массиве: ");
int[,] matrix = GenerateMatrix(rows, cols, 0, 9);
PrintMatrix(matrix);
Console.WriteLine(" => ");
Console.WriteLine($"Строка с индексом {FindStringMin(matrix)}");