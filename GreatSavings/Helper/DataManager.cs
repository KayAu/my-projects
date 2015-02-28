using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GreatSavings.Helper
{
    public static class DataManager
    {
        public static byte[] ConvertImageToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public static int GetRandonNum()
        {
            StringBuilder builder = new StringBuilder();

            //Define the range of random numbers, from which
            //the routine should choose
            int smallestNumber = 1;
            int biggestNumber = 10;

            //Determine the amount of random numbers
            int amountOfRandomNumbers = 6;

            //Create a list of numbers from which the routine
            //shall choose the result numbers
            List<int> possibleNumbers = new List<int>();
            for (int i = smallestNumber; i <= biggestNumber; i++)
                possibleNumbers.Add(i);

            //Create a list, which shall hold the result numbers
            List<int> resultList = new List<int>();

            //Initialize a random number generator
            Random rand = new Random();

            //For-loop which picks each round a unique random number
            for (int i = 0; i < amountOfRandomNumbers; i++)
            {
                //Generate random number
                int randomNumber = rand.Next(1, possibleNumbers.Count) - 1;

                //Use random number as index for the possible number list
                resultList.Add(possibleNumbers[randomNumber]);

                //Remove the chosen result number from possible numbers list
                possibleNumbers.RemoveAt(randomNumber);
            }


            foreach (int num in resultList)
            {
                builder.Append(num);
            }


            return Convert.ToInt32(builder.ToString());
        }
    }
}