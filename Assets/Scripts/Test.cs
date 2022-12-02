using UnityEngine;

public class SortingBasics : MonoBehaviour
{
    // Sort an array of integers (THIS CHANGES THE ARRAY)
    public void Sort(int[] values)
    {
        // Go through all numbers in array
        for (int j = 0; j < values.Length; j++)
        {
            // This finds the lowest number in array and puts it into min variable
            // NOTE: We start with j (was 0 before) because all values before j should be sorted already
            int s�kt = 5;
            int f�rsta = 0, mitten = 0, sista = 8 - 1;
            while (f�rsta <= sista)
            {
                mitten = (f�rsta + sista) / 2;
                if (s�kt < values[mitten])
                {
                    sista = mitten - 1;
                }
                else if (s�kt > values[mitten])
                {
                    f�rsta = mitten + 1;
                }
                else
                    break;
            }
        }
    }

    private void Start()
    {
        // Create an array
        int[] values = {2,4,8,7,6,5,10,4};
        // Call our sort function
        Sort(values);
        // Print all elements of the array (that are now sorted, hopefully)
        for (int i = 0; i < values.Length; i++)
            print(values[i]);
    }
}