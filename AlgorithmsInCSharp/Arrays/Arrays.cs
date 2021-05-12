using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsInCSharp.Arrays
{
    public static class ArraySamples
    {
        public static bool SingleDimensionalArrays()
        {
            //An array is an indexed collecion of elements of the same type (primitive or user-defined type)
            string[] textArray = new string[10];

            //You can also initialize the array directly in the instatiation of the array.
            int[] intArray = new int[] { 1, 2, 3, 4 };

            //Creating an array of a user-defined type
            SampleUserDefType[] sampleUserDefTypes = new SampleUserDefType[15];

            //Use the index position to set a value to an array element. If there is already a value set for an element, it will be replaced.
            textArray[2] = "Text Sampple";
            intArray[3] = 2;
            sampleUserDefTypes[1] = new SampleUserDefType() { TextProperty = "text", IntProperty = 42};

            //Use the index position to get a value from an array element
            string text = textArray[4];
            int number = intArray[3];
            SampleUserDefType userDefinedElement = sampleUserDefTypes[1];


            //To loop through an array, you can use the Length built-in property of the array or the GetUpperBound() method to get the length of a specific dimension of the array
            for (int i=0; i<textArray.Length; i++)
            {
                Console.WriteLine(textArray[i]);
            }

            for (int i = 0; i <= intArray.GetUpperBound(0); i++)
            {
                Console.WriteLine(intArray[i]);
            }

            for (int i = 0; i <= sampleUserDefTypes.GetUpperBound(0); i++)
            {
                //Checking for null before trying to access and read the property content
                Console.WriteLine(sampleUserDefTypes[i]?.TextProperty); 
            }

            return true;
        }
        
        public static bool MultidimensionalArrays()
        {
            //An array can have more dimensions, up to 32
            //This is a sample of an array with 2 rows and 3 elements each, also called a matrix
            string[,] textArray = new string[2, 3];

            //You can also initialize multidimensional arrays directly
            int[,] intArray = new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            //Use the index position to set a value to a multidimensional array element. If there is already a value set for an element, it will be replaced.
            intArray[0, 2] = 7; //Will replace 3 to 7

            //Use the index position to get a value from a multidimensional array element
            int number = intArray[1,0]; //4

            //To loop through a multidimensional array, you can use the GetUpperBound() method to get the length of a specific dimension of the array
            for (int row = 0; row <= intArray.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= intArray.GetUpperBound(1); column++)
                {
                    Console.WriteLine(intArray[row, column]);
                }
            }

            return true;
        }
        
        public static bool JaggedArrays()
        {
            //In multidimensional arrays, the structure need to have always the same number of elements (columns) for each row 
            //Jagged Arrays are arrays of arrays, where each element of the array can have a distinct array with different sizes
            int[][] jaggedArray = new int[2][];

            //Use the index position to set a value to a multidimensional array element. If there is already a value set for an element, it will be replaced.
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[2];
            jaggedArray[1][0] = 4;
            jaggedArray[1][1] = 5;


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }

            //You can also initialize Jagged arrays directly
            int[][] jaggedArray2 = new int[2][] {
                new int[]{ 1, 2, 3},
                new int[]{ 4, 5 }
            };

            return true;
        }

        public static bool ArrayListClass()
        {
            //ArrayList is a type of array that resizes automatically as needed when the number of elements increases
            //ArrayList stores elements of Object type, so it can store every object that derives from Object
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Test");
            arrayList.Add(new SampleUserDefType { IntProperty = 2 });

            foreach(object arr in arrayList)
            {
                Console.WriteLine(arr.GetType());
                if (arr is int)
                {
                    Console.WriteLine((int)arr);
                }
                else if (arr is string)
                {
                    Console.WriteLine(arr);
                }
                else if (arr is SampleUserDefType)
                {
                    Console.WriteLine((SampleUserDefType)arr);
                }
            }

            return true;
        }
    }


    public class SampleUserDefType
    {
        public string TextProperty { get; set; }
        public int IntProperty { get; set; }

        public override string ToString() => $"{IntProperty} - {TextProperty}";
        
        
    }
}
