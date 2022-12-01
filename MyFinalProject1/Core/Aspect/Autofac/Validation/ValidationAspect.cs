using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//validatorType aslında bir IValidator mu diye bakıyor eger değilse buraya girer
            {
                throw new System.Exception("Bu bir dogrulama sınıfı degil");
            }

            _validatorType = validatorType;//ProductValidator
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //13. ders 55 dk da anlatıyor
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//_validatorType ,Ivalidator tipinde newle diyor çalışma anında oluşturmak için
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ProductValidator base git ,base generic argümanınn tipini bul (Product)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//invocation.Arguments (yani Add metoduna git parametrelere bak) git  add  parametrelirini gez eşitmi diye bak
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
