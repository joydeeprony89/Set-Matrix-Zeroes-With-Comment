using System;

namespace Set_Matrix_Zeroes_With_Comment
{
  class Program
  {
    static void Main(string[] args)
    {
    }
  }

  public class Solution
  {
    //Traverse for the below inputs using pen and paper you will get more idea about the algo.
    //Input - [[1,2,3,4], [5,0,7,8], [0,10,11,12], [13,14,15,0]]
    //Input - [[1,0]]
    //Input - [[9,1,2,0],[3,4,5,2],[1,3,1,5]]
    //Input - [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
    public void SetZeroes(int[][] matrix)
    {
      // We will be solving this in memory without extra space,we will be using first row and first column to store the info of cells where it has 0.
      // Step - 1 - traverse throught the entire matrix and if a cell has 0, set the (first row and cth column)matrix[0][c] = 0
      // and (first column and rth row) matrix[r][0] to zero(except for the first row, for first row will have a separte variable).
      // Step 2 - traverse from r=1 and c =1, why from 1st row and 1st col, coz we have the info about cells having 0 in first row and first column from step 1.
      // while traversing for any matrix[r][c] check matrix[0][c] == 0 OR matrix[r][0] == 0 then set that cell to 0
      // Step 3 - as we have not traversed the first row and first column , now
      // Step 3.a - now set all the first column cells to 0 if matrix[0][0] == 0
      // Step 3.b - if the first cell is not 0 check if any column in the first row has 0, in that case the entire first row would be set to 0.

      bool firstRow = false;
      int r = matrix.Length;
      int c = matrix[0].Length;
      // Step 1
      for (int i = 0; i < r; i++)
      {
        for (int j = 0; j < c; j++)
        {
          if (matrix[i][j] == 0)
          {
            matrix[0][j] = 0;
            if (i > 0)
              matrix[i][0] = 0;
            else
              firstRow = true; // to indicate that first row has one of the cell has 0 and later will make entire first row to 0
          }
        }
      }

      // Step 2
      for (int i = 1; i < r; i++)
      {
        for (int j = 1; j < c; j++)
        {
          if (matrix[0][j] == 0 || matrix[i][0] == 0)
          {
            matrix[i][j] = 0;
          }
        }
      }

      // Step 3.a
      // when our input matrix first cell is 0, will be setting all the first column to 0
      if (matrix[0][0] == 0)
      {
        for (int i = 0; i < r; i++)
        {
          matrix[i][0] = 0;
        }
      }

      // Step 3.b
      // Finally check the first row has any 0 except the first cell.
      if (firstRow)
      {
        for (int j = 0; j < c; j++)
        {
          matrix[0][j] = 0;
        }
      }
    }
  }
}
