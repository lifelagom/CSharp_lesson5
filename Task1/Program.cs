// Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента 
// или же указание, что такого элемента нет.

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
// поиск элемента массива
void PrintElement(int[,] matrix, int rowPoz, int colPoz) {
    Console.WriteLine($"({rowPoz},{colPoz}) => {matrix[rowPoz,colPoz]}");
}

int rows = ReadInt("Введите количество строк в массиве: ");
int cols = ReadInt("Введите количество столбцов в массиве: ");
int[,] matrix = GenerateMatrix(rows, cols, 1, 9);
PrintMatrix(matrix);
int rowPoz = ReadInt("Введите позицию элемента в строке: ");
int colPoz = ReadInt("Введите позицию элемента в столбце: ");
PrintElement(matrix, rowPoz, colPoz);