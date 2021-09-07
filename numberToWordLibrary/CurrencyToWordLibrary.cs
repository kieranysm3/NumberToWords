using System;

namespace CurrencyToWordLibrary
{
    public class CurrencyConverter
    {
        public static String CurrencyConversion(decimal num1)
         //this function takes in a decimal and converts it to words and returns it in the form of a string
        {
            //These initialized strings will be used to insert optional words as required by the currency value. if there is decimal(.) = and, (-) = "Negative"
            String  point, isNegative = "";

            if (num1 < 0)
            //if number is less than zero convert it to a positive number and register that it the currency value was negative.
            {
                isNegative = "Negative ";
                num1 *= -1;
            }
            if (num1 > 10000)
                //check if the number is within the upper bound of the converter
            {
                return "Sorry Currency Value exceeds ceiling of converter";
            }
            else
            //the value given is a valid decimal but i need to ensure it is convertable. e.g remove trailing zeros.
            //round it to 2 decimal places
            {
                num1 = Math.Round(num1, 2);
                //split string  by the decimal point if it exists so convert it to string
                string stringResult = num1.ToString();
                //now i have a decimal with at least 2 dp
                String Final;
                if (stringResult.Contains("."))
                    {
                    point = " and ";
                    string[] string2 = stringResult.Split(".");
                    if (string2[0].Equals("0"))
                    {
                        Final = (isNegative + ConvertWholeNumber(string2[1]) + " Cents");

                    }
                    else
                    {
                        //Console.WriteLine(ConvertWholeNumber(string2[0]) + " Dollars");
                        //Console.WriteLine(ConvertWholeNumber(string2[1]) + " Cents");
                        Final = (isNegative + ConvertWholeNumber(string2[0]) + " Dollars" + point + ConvertWholeNumber(string2[1]) + " Cents");
                    }
                    return Final;
                }
                else
                {
                    //Number has no decimal value
                    Console.WriteLine(ConvertWholeNumber(stringResult) + " Dollars");
                    Final = (isNegative + ConvertWholeNumber(stringResult) + " Dollars");
                    return Final;
                }
            }
        }
        private static String Tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                       name = Tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                decimal dblAmt = (Convert.ToDecimal(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundreds,thousands,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = Tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    { 
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }   
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }




    }
}