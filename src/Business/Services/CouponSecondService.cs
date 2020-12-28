using Business.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class CouponSecondService : ICouponService
    {
        private readonly char[] ValidCharacters = new char[] { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };
        private readonly int ValidCharacterCount = 23;
        private readonly int CouponLenght = 8;
        private readonly int CheckCharacterCount = 1;
        private readonly char[] ZeroIndexChars = new char[] { 'A', '2', 'C', '3', 'D' };
        private readonly char[] FirstIndexChars = new char[] { 'F', '5', 'G', '7', 'H' };
        private readonly char[] SecondIndexChars = new char[] { 'L', '4', 'M', '3', 'N' };
        private readonly char[] ThirdIndexChars = new char[] { 'E', '7', 'R', '2', 'T' };
        private readonly char[] FourIndexChars = new char[] { 'Y', '4', 'Z', '5' };
        private readonly char[] FiveIndexChars = new char[] { 'K', '7', 'P', '3' };
        private readonly char[] SixIndexChars = new char[] { 'T', '2', 'X', 'E' };
        private readonly char[] SevenIndexChars = new char[] { 'A', 'C', 'D',  'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R',  'Y', 'Z', '3', '4', '5', '7', '9' };//Check Index


        private List<string> Coupons { get; set; }

        public CouponSecondService()
        {
            Coupons = new List<string>();
            CreateCoupons();
        }
        private void CreateCoupons()
        {
            while (Coupons.Count < 1000)
            {
                var coupon = CreateCoupon();
                if (!Coupons.Contains(coupon))
                {
                    Coupons.Add(coupon);
                }
            }
        }
        private string CreateCoupon()
        {
            char[] coupon = new char[CouponLenght];
 
            coupon[0] = GetCharacter(ZeroIndexChars);
            coupon[1] = GetCharacter(FirstIndexChars);
            coupon[2] = GetCharacter(SecondIndexChars);
            coupon[3] = GetCharacter(ThirdIndexChars);
            coupon[4] = GetCharacter(FourIndexChars);
            coupon[5] = GetCharacter(FiveIndexChars);
            coupon[6] = GetCharacter(SixIndexChars);


            coupon[7] = CreateCheckCharacter(coupon);
            return new string(coupon);
        }
        private char CreateCheckCharacter(char[] coupon)
        {
            var diffBetweenOddAndEvenValues = Math.Abs(SumOfOddNumber(coupon) - SumOfEvenNumber(coupon));
          return  SevenIndexChars[diffBetweenOddAndEvenValues % SevenIndexChars.Length];

        }
        private int SumOfOddNumber(char[] coupon)
        {
            var total = 0;
            for (int i = 1; i < CouponLenght - CheckCharacterCount; i += 2)
            {
                total += (int)coupon[i];
            }
            return total ;
        }
        private int SumOfEvenNumber(char[] coupon)
        {
            var total = 0;
            for (int i = 0; i < CouponLenght - CheckCharacterCount; i += 2)
            {
                total += (int)coupon[i];
            }
            return total;
        }

        private char GetCharacter(char[] arr)
        {
            Random r = new Random();
            var rand = r.Next(1000);
            return arr[rand % arr.Length];
        }

        /*check is valid methods*/

        public bool CheckCode(string code)
        {
            var coupon = code.ToCharArray();
          return  Array.Exists(ZeroIndexChars, element => element == coupon[0]) &&
                Array.Exists(FirstIndexChars, element => element == coupon[1]) &&
                Array.Exists(SecondIndexChars, element => element == coupon[2]) &&
                Array.Exists(ThirdIndexChars, element => element == coupon[3]) &&
                Array.Exists(FourIndexChars, element => element == coupon[4]) &&
                Array.Exists(FiveIndexChars, element => element == coupon[5]) &&
                Array.Exists(SixIndexChars, element => element == coupon[6]) &&
               coupon[7] == CreateCheckCharacter(coupon);

        }
        public List<string> GetCoupons()
        {
            return Coupons;
        }
    }
}
