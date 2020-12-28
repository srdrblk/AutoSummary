using Business.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class CouponService 
    {
        private readonly char[] ValidCharacters = new char[] { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };
        private readonly int ValidCharacterCount = 23;
        private readonly int CouponLenght = 8;
        private readonly int CheckCharacterCount = 2;
        private readonly int OddNumber_CheckCharacterIndex = 7;
        private readonly int EvenNumber_CheckCharacterIndex = 6;

        private List<string> Coupons { get; set; }

        public CouponService()
        {
            Coupons = new List<string>();
            CreateCoupons();
        }
        private void CreateCoupons()
        {
            while (Coupons.Count < 20000)
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
            var ch = GetCharacter();
            coupon[0] = ch;

            for (int i = 1; i < CouponLenght - CheckCharacterCount; i++)
            {
                do
                {
                    ch = GetCharacter();

                } while (ch == coupon[i - 1] && IsConsecutive(coupon[i - 1],ch));
                coupon[i] = ch;
            }

            coupon[OddNumber_CheckCharacterIndex] = GetOddNumberCheckCharacter(coupon);
            coupon[EvenNumber_CheckCharacterIndex] = GetEvenNumberCheckCharacter(coupon);

            return coupon[OddNumber_CheckCharacterIndex] != coupon[EvenNumber_CheckCharacterIndex] ? new string(coupon) : CreateCoupon();
        }
        private bool IsConsecutive(char first,char second)
        {
            var firstIndex = Array.IndexOf(ValidCharacters, first);


            return (first + 1) != ValidCharacterCount ? ValidCharacters[firstIndex + 1]==second : false;//if Is not last index of ValidCharacters array then check Is Consecutive
        }
        private char GetOddNumberCheckCharacter(char[] coupon)
        {
            var total = 0;
            for (int i = 1; i < CouponLenght - CheckCharacterCount; i += 2)
            {
                total += (int)coupon[i];
            }
            return ValidCharacters[total % ValidCharacterCount];
        }
        private char GetEvenNumberCheckCharacter(char[] coupon)
        {
            var total = 0;
            for (int i = 0; i < CouponLenght - CheckCharacterCount; i += 2)
            {
                total += (int)coupon[i];
            }
            return ValidCharacters[total % ValidCharacterCount];
        }
        private char GetCharacter()
        {
            Random r = new Random();
            var rand = r.Next(1000);
            return ValidCharacters[rand % ValidCharacterCount];
        }

        /*check is valid methods*/

       
    }
}
