// Задайте двумерный массив из целых чисел. Напишите программу, которая 
// удалит строку и столбец, на пересечении которых расположен наименьший 
// элемент массива. Под удалением понимается создание нового двумерного 
// массива без строки и столбца

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
// поиск наименьшего элемента массива 
int[] FindMinElement(int[,] matrix) {
    int[] array = [0,0];
       for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++) {
            if (matrix[i,j]<matrix[array[0],array[1]]) {
                array[0] = i;
                array[1] = j;
            }
        }
    }
    return array;
}
// удаление строки и столбца из массива
int[,] ChangeMatrix(int[,] matrix) {
    int[,] newMatrix = new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];
    int[] array = FindMinElement(matrix);
    for(int i = 0; i < newMatrix.GetLength(0); i++){
        if (i<array[0]) {
            for(int j = 0; j < newMatrix.GetLength(1); j++) {
                if (j<array[1]) {
                    newMatrix[i,j] = matrix[i,j];
                } else {
                    newMatrix[i,j] = matrix[i,j+1];
                }            
            }
        } else {
            for(int j = 0; j < newMatrix.GetLength(1); j++) {
                if (j<array[1]) {
                    newMatrix[i,j] = matrix[i+1,j];
                } else {
                    newMatrix[i,j] = matrix[i+1,j+1];
                }            
            }
        }
    }
    return newMatrix;
}
// основной код
int rows = ReadInt("Введите количество строк в массиве: ");
int cols = ReadInt("Введите количество столбцов в массиве: ");
int[,] matrix = GenerateMatrix(rows, cols, 0, 9);
PrintMatrix(matrix);
Console.WriteLine(" => ");
int[,] newMatrix = ChangeMatrix(matrix);
PrintMatrix(newMatrix);