using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IServices
{
    public interface ICouponService
    {
        bool CheckCode(string code);

        List<string>  GetCoupons();
    }
}
