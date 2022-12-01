using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params IResult'a istedigimiz kadar arry girmemizi saglıyor
        {
            foreach (var logic in logics)
            {
                if (!logic.Succes)
                {
                    return logic;
                }
            }
            return null;
        }
        
    }
}
